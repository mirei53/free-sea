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

		// �A�j���[�V�����؂�ւ�
		animator.SetBool("isMoving", Mathf.Abs(moveInput) > 0);

		// A/D�L�[�ŉ�]�iW/S�ł͉�]���Ȃ��j
		transform.Rotate(Vector3.up * turnInput * rotationSpeed * Time.deltaTime);

		// ���݂̌����ɑ΂��đO�i�E���
		Vector3 moveDirection = transform.forward * moveInput;
		rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);
	}
}
