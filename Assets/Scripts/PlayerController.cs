using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 5f;
	public float rotationSpeed = 100f;
	public float verticalSpeed = 3f;

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

		// �㉺�ړ��iSpace�ŏ㏸�ALeftShift�ŉ��~�j
		float verticalInput = 0f;
		if (Input.GetKey(KeyCode.Space)) verticalInput = 1f;
		if (Input.GetKey(KeyCode.LeftShift)) verticalInput = -1f;

		// �A�j���[�V�����؂�ւ�
		bool isMoving = Mathf.Abs(moveInput) > 0 || verticalInput != 0;
		animator.SetBool("isMoving", isMoving);

		// ��]�iA/D�L�[�ō��E�ɉ�]�j
		transform.Rotate(Vector3.up * turnInput * rotationSpeed * Time.deltaTime);

		// �ړ��i�O�� + �㉺�j
		Vector3 moveDirection = transform.forward * moveInput + Vector3.up * verticalInput;
		rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);
	}
}
