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
		moveAudio = GetComponent<AudioSource>(); // AudioSource を取得
	}

	void Update()
	{
		float moveInput = Input.GetAxisRaw("Vertical");   // W/S
		float turnInput = Input.GetAxisRaw("Horizontal"); // A/D

		// 上下移動（Spaceで上昇、LeftShiftで下降）
		float verticalInput = 0f;
		if (Input.GetKey(KeyCode.Space)) verticalInput = 1f;
		if (Input.GetKey(KeyCode.LeftShift)) verticalInput = -1f;

		// アニメーション切り替え
		bool isMoving = Mathf.Abs(moveInput) > 0 || verticalInput != 0 || Mathf.Abs(turnInput) > 0;
		animator.SetBool("isMoving", isMoving);

		// サウンド再生制御
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

		// 回転（A/Dキーで左右に回転）
		transform.Rotate(Vector3.up * turnInput * rotationSpeed * Time.deltaTime);

		// 移動（前後 + 上下）
		Vector3 moveDirection = transform.forward * moveInput + Vector3.up * verticalInput;
		rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);
	}
}
