using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodePuzzle : MonoBehaviour
{
	public string correctCode = "1621";
	public GameObject gate; // 出口のゲート

	public void CheckCode(string input)
	{
		if (input == correctCode)
		{
			UnlockGate();
		}
	}

	void UnlockGate()
	{
		gate.GetComponent<Collider>().enabled = false;
		// アニメーションやエフェクトもここで再生可能
	}

}
