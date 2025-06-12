using UnityEngine;
using System.Collections; // �R���[�`���iIEnumerator�j���g�����߂ɕK�v

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
		isOpen = !isOpen; // ��Ԃ�؂�ւ���
		animator.SetBool("IsOpen", isOpen);
	}
}