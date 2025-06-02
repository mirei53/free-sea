using System.Collections;
using UnityEngine;

public class Fish : MonoBehaviour
{
	// ���̈ړ����x
	[SerializeField] float speed = 1f;

	// ��]���ɉ�����g���N�̋���
	[SerializeField] float rotationSpeed = 0.1f;

	// ��]�̊Ԋu�i�b�j
	[SerializeField] float rotationInterval = 3f;

	// Rigidbody �R���|�[�l���g�ւ̎Q��
	Rigidbody rb;

	void Start()
	{
		// Rigidbody ���擾
		rb = GetComponent<Rigidbody>();

		// ��]�����̃R���[�`�����J�n
		StartCoroutine(RotateFishRoutine());
	}

	// ���Ԋu�Ń����_���ȕ����ɉ�]����R���[�`��
	IEnumerator RotateFishRoutine()
	{
		// ��]�p�^�[���̔z��i�����̕����̑g�ݍ��킹�j
		Vector3[][] torquePatterns = new Vector3[][]
		{
			new[] { Vector3.down, Vector3.right },
			new[] { Vector3.up, Vector3.right },
			new[] { Vector3.down, Vector3.left },
			new[] { Vector3.up, Vector3.right },
			new[] { Vector3.up },
			new[] { Vector3.down }
		};

		while (true)
		{
			// �w�莞�ԑҋ@
			yield return new WaitForSeconds(rotationInterval);

			// �����_���ȃp�^�[����I��
			int index = Random.Range(0, torquePatterns.Length);

			// �I�΂ꂽ�����Ƀg���N��������
			foreach (var dir in torquePatterns[index])
			{
				rb.AddTorque(dir * rotationSpeed, ForceMode.Impulse);
			}
		}
	}

	void Update()
	{
		// �O���Ɉ�葬�x�ňړ�
		rb.velocity = transform.forward * speed;

		// �p�������肳���邽�߂̕␳�g���N��������
		ApplyCorrectionTorque(Vector3.left);
		ApplyCorrectionTorque(Vector3.forward);
	}

	// �w�肳�ꂽ���[�J�������ɑ΂��Ďp���␳�g���N��������
	void ApplyCorrectionTorque(Vector3 localDirection)
	{
		// ���[�J�����������[���h�����ɕϊ�
		Vector3 worldDir = transform.TransformVector(localDirection);

		// ���������̐����𒊏o���Đ��K��
		Vector3 horizontal = new Vector3(worldDir.x, 0, worldDir.z).normalized;

		// �p���␳�̂��߂̃g���N��������
		rb.AddTorque(Vector3.Cross(worldDir, horizontal) * 4, ForceMode.Force);
	}

	// �Փˎ��̏���
	void OnCollisionEnter(Collision collision)
	{
		// "Box" �^�O�̃I�u�W�F�N�g�ɏՓ˂����ꍇ
		if (collision.collider.CompareTag("Box"))
		{
			// ������ɃW�����v
			rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);

			// �i�s�����𔽓]
			transform.rotation = Quaternion.LookRotation(-transform.forward);
		}
	}
}
