using UnityEngine;

public class ReasureChest : MonoBehaviour
{
	public Animator animator;
	public string boolParameter = "IsOpen";

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			animator.SetBool(boolParameter, true);
		}

		if (Input.GetKeyUp(KeyCode.Space))
		{
			animator.SetBool(boolParameter, false);
		}
	}
}