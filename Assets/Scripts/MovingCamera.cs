using UnityEngine;

public class MovingCamera : MonoBehaviour
{
	public Transform target; // �v���C���[��Transform
	public float smoothSpeed = 0.1f;
	public float lookUpOffset = 1.5f; // �ǂꂾ��������邩

	private Vector3 initialOffset;

	void Start()
	{
		// �����ʒu����v���C���[�ւ̑��΃I�t�Z�b�g���L�^
		initialOffset = Quaternion.Inverse(target.rotation) * (transform.position - target.position);
	}

	void LateUpdate()
	{
		// �v���C���[�̌����ɍ��킹�ăI�t�Z�b�g����]
		Vector3 rotatedOffset = target.rotation * initialOffset;

		// �ڕW�ʒu���v�Z
		Vector3 desiredPosition = target.position + rotatedOffset;

		// �X���[�Y�ɒǏ]
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;

		// �v���C���[�̏����������
		Vector3 lookAtPoint = target.position + Vector3.up * lookUpOffset;
		transform.LookAt(lookAtPoint);
	}
}
