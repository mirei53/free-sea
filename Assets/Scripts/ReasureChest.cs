using UnityEngine;
using System.Collections; // コルーチン（IEnumerator）を使うために必要

public class ReasureChest : MonoBehaviour
{
	private Animator animator;
	private bool isOpen = false;

	void Start()
	{
		animator = GetComponent<Animator>();
	}

	void OnMouseDown()
	{
		isOpen = !isOpen; // 状態を切り替える
		animator.SetBool("IsOpen", isOpen);
	}
}