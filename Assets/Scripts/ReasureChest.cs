using UnityEngine;
using System.Collections; // �R���[�`���iIEnumerator�j���g�����߂ɕK�v

public class ReasureChest : MonoBehaviour
{
	public Animator targetAnimator; // �A�j���[�V�����Ώ�
	public string boolParameterName = "IsOpen"; // Animator��bool�p�����[�^��

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			targetAnimator.SetBool(boolParameterName, true);
		}
	}
}