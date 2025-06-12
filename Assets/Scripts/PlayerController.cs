using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 5f;
	public float rotationSpeed = 100f;

	private Rigidbody rb;
	private Animator animator;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
	}

	void Update()
	{
		float moveInput = Input.GetAxisRaw("Vertical");   // W/S
		float turnInput = Input.GetAxisRaw("Horizontal"); // A/D

		// アニメーション切り替え
		animator.SetBool("isMoving", Mathf.Abs(moveInput) > 0);

		// A/Dキーで回転（W/Sでは回転しない）
		transform.Rotate(Vector3.up * turnInput * rotationSpeed * Time.deltaTime);

		// 現在の向きに対して前進・後退
		Vector3 moveDirection = transform.forward * moveInput;
		rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);
	}
}
