using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 3f;
	public float gravity = -9.81f;
	private Vector3 velocity;
	private Animator animator;
	private CharacterController controller;

	void Start()
	{
		controller = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	void Update()
	{
		if (controller == null || animator == null) return;

		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		Vector3 move = new Vector3(h, 0, v);
		move = transform.TransformDirection(move);

		if (move.magnitude > 0.1f)
		{
			animator.SetBool("Swimming", true);
		}
		else
		{
			animator.SetBool("Swimming", false);
		}

		// 重力処理
		if (controller.isGrounded && velocity.y < 0)
		{
			velocity.y = -2f; // 地面に張り付けるための小さな値
		}

		velocity.y += gravity * Time.deltaTime;

		// 移動と重力を合成
		controller.Move((move * moveSpeed + velocity) * Time.deltaTime);
	}
}
