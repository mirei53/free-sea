using UnityEngine;

public class MovingCamera : MonoBehaviour
{
	public Transform target; // �v���C���[��Transform
	public Vector3 offset = new Vector3(0f, 5f, -10f); // �v���C���[�̔w��ɔz�u
	public float smoothSpeed = 0.125f;

	void LateUpdate()
	{
		// �v���C���[�̌����ɍ��킹�ăI�t�Z�b�g����]
		Vector3 rotatedOffset = target.rotation * offset;

		// �ڕW�ʒu���v�Z
		Vector3 desiredPosition = target.position + rotatedOffset;

		// �X���[�Y�ɒǏ]
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;

		// �v���C���[����Ɍ���
		transform.LookAt(target);
	}
}
