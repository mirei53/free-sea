using UnityEngine;
using System.Linq;

public class PlayerAnimationController : MonoBehaviour
{
	[SerializeField] private Animator animator;

	private readonly KeyCode[] movementKeys = {
		KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D,
		KeyCode.Space, KeyCode.LeftShift
	};

	void Update()
	{
		bool isKeyHeld = movementKeys.Any(Input.GetKey);

		animator.SetBool("Swimming", isKeyHeld);
		animator.SetBool("Water", !isKeyHeld);
	}
}
