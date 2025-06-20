using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodePuzzle : MonoBehaviour
{
	public string correctCode = "1621";
	public GameObject gate; // �o���̃Q�[�g

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
		// �A�j���[�V������G�t�F�N�g�������ōĐ��\
	}

}
