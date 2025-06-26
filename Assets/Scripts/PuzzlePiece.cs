using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
	public float correctRotation = 0f; // �������p�x
	public float rotationThreshold = 5f; // ���e�덷
	private bool isLocked = false;

	void Update()
	{
		if (isLocked) return;

		// ��F�N���b�N�ŉ�]�i90�x���j
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
			Debug.Log("�s�[�X���������p�x�ɂȂ�܂����I");
		}
	}
}