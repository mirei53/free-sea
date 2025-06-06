using System.Collections;
using UnityEngine;

public class Fish : MonoBehaviour
{
	[SerializeField] float speed = 1f;                  // ���̈ړ����x
	[SerializeField] float rotationSpeed = 30f;         // ��]���̃g���N�̋���
	[SerializeField] float rotationInterval = 3f;       // ��]�̊Ԋu�i�b�j

	Rigidbody rb;

	void Start()
	{
		// Rigidbody �ݒ�
		rb = GetComponent<Rigidbody>();
		rb.useGravity = false;                                             // �d�͂𖳌���
		rb.collisionDetectionMode = CollisionDetectionMode.Continuous;    // �Փˌ��o������
		rb.interpolation = RigidbodyInterpolation.Interpolate;            // ���炩�ȓ����ɕ��

		// ��]�����̃R���[�`�����J�n
		StartCoroutine(RotateFishRoutine());
	}

	// ���Ԋu�Ń����_���ɉ�]����R���[�`��
	IEnumerator RotateFishRoutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(rotationInterval);

			// Y�������Ƀ����_���ȃg���N��������i������]�j
			float randomY = Random.Range(-1f, 1f);
			//z�������Ƀ����_���ȃg���N��ǉ�
			rb.AddTorque(Vector3.up * randomY * rotationSpeed, ForceMode.Impulse);
		}
	}

	// �������Z�Ɋ�Â��ړ�����
	void FixedUpdate()
	{
		// �O���Ɉ�葬�x�ňړ�
		rb.velocity = transform.forward * speed;
	}

	// �Փˎ��̏���
	void OnCollisionEnter(Collision collision)
	{
		// �Փ˂������肪 BoxCollider �������Ă��邩�m�F
		if (collision.collider is BoxCollider)
		{
			// �i�s�����𔽓]�iRigidbody ���g���ĉ�]�j
			Quaternion newRotation = Quaternion.LookRotation(-transform.forward);
			rb.MoveRotation(newRotation);
		}
	}
}
