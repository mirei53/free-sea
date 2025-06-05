using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerController : MonoBehaviour
{
	[SerializeField] private Transform cameraTransform;

	private Animator animator;
	private Vector3 inputDirection;

	void Start()
	{
		animator = GetComponent<Animator>();
		animator.applyRootMotion = true; // Root Motion ��L����
	}

	void Update()
	{
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		// �J�����̌�������Ɉړ��������v�Z
		Vector3 camForward = cameraTransform.forward;
		Vector3 camRight = cameraTransform.right;
		camForward.y = 0f;
		camRight.y = 0f;
		camForward.Normalize();
		camRight.Normalize();

		inputDirection = (camForward * v + camRight * h).normalized;

		// �A�j���[�V�����؂�ւ�
		bool isMoving = inputDirection.magnitude > 0.1f;
		animator.SetBool("Swimming", isMoving);
		animator.SetBool("Water", !isMoving);
	}

	void OnAnimatorMove()
	{
		if (inputDirection.magnitude > 0.1f)
		{
			// �A�j���[�V������ Root Motion ���J���������ɍ��킹�Ĉړ�
			Vector3 rootMotion = animator.deltaPosition;
			Vector3 move = inputDirection * rootMotion.magnitude;
			transform.position += move;
		}
	}
}
