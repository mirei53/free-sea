using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaAnimation : MonoBehaviour
{
	private Animator animator;

	void Start()
	{
		animator = GetComponent<Animator>();
		//animator.Play("Sea"); // �� �A�j���[�V�������ɒu�������Ă�������
	}
}
