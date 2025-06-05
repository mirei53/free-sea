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
		animator.applyRootMotion = true; // Root Motion を有効に
	}

	void Update()
	{
		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		// カメラの向きを基準に移動方向を計算
		Vector3 camForward = cameraTransform.forward;
		Vector3 camRight = cameraTransform.right;
		camForward.y = 0f;
		camRight.y = 0f;
		camForward.Normalize();
		camRight.Normalize();

		inputDirection = (camForward * v + camRight * h).normalized;

		// アニメーション切り替え
		bool isMoving = inputDirection.magnitude > 0.1f;
		animator.SetBool("Swimming", isMoving);
		animator.SetBool("Water", !isMoving);
	}

	void OnAnimatorMove()
	{
		if (inputDirection.magnitude > 0.1f)
		{
			// アニメーションの Root Motion をカメラ方向に合わせて移動
			Vector3 rootMotion = animator.deltaPosition;
			Vector3 move = inputDirection * rootMotion.magnitude;
			transform.position += move;
		}
	}
}
