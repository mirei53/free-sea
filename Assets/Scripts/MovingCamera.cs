using UnityEngine;

public class MovingCamera : MonoBehaviour
{
	[SerializeField] private Transform playerBody;
	[SerializeField] private Vector3 offset = new Vector3(0f, 2f, -4f);
	[SerializeField] private float mouseSensitivity = 100f;

	private float xRotation = 0f;

	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	void Update()
	{
		HandleMouseLook();
	}
	void LateUpdate()
	{
		FollowPlayer();
	}
	void HandleMouseLook()
	{
		float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);

		// èCê≥â”èäÅFQuaternion.Euler Çê≥ÇµÇ≠égóp
		transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
		playerBody.Rotate(Vector3.up * mouseX);
	}
	void FollowPlayer()
	{
		transform.position = playerBody.position + playerBody.TransformDirection(offset);
	}
}
