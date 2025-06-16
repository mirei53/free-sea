using UnityEngine;
using System.Collections; // コルーチン（IEnumerator）を使うために必要

public class ReasureChest : MonoBehaviour
{
	public Animator targetAnimator; // アニメーション対象
	public string boolParameterName = "IsOpen"; // Animatorのboolパラメータ名

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			targetAnimator.SetBool(boolParameterName, true);
		}
	}
}