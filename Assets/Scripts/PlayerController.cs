using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 5f;
	public float rotationSpeed = 100f;
	public float verticalSpeed = 3f;

	private Rigidbody rb;
	private Animator animator;
	private AudioSource moveAudio;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		animator = GetComponent<Animator>();
		moveAudio = GetComponent<AudioSource>(); // AudioSource ���擾
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
		bool isMoving = Mathf.Abs(moveInput) > 0 || verticalInput != 0 || Mathf.Abs(turnInput) > 0;
		animator.SetBool("isMoving", isMoving);

		// �T�E���h�Đ�����
		if (isMoving)
		{
			if (!moveAudio.isPlaying)
			{
				moveAudio.Play();
			}
		}
		else
		{
			if (moveAudio.isPlaying)
			{
				moveAudio.Stop();
			}
		}

		// ��]�iA/D�L�[�ō��E�ɉ�]�j
		transform.Rotate(Vector3.up * turnInput * rotationSpeed * Time.deltaTime);

		// �ړ��i�O�� + �㉺�j
		Vector3 moveDirection = transform.forward * moveInput + Vector3.up * verticalInput;
		rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);
	}
}
