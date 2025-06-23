using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
	public float correctRotation = 0f; // 正しい角度
	public float rotationThreshold = 5f; // 許容誤差
	private bool isLocked = false;

	void Update()
	{
		if (isLocked) return;

		// 例：クリックで回転（90度ずつ）
		if (Input.GetMouseButtonDown(0))
		{
			transform.Rotate(0, 0, 90);
			CheckRotation();
		}
	}

	void CheckRotation()
	{
		float currentZ = transform.eulerAngles.z;
		float diff = Mathf.Abs(Mathf.DeltaAngle(currentZ, correctRotation));

		if (diff <= rotationThreshold)
		{
			isLocked = true;
			Debug.Log("ピースが正しい角度になりました！");
		}
	}
}