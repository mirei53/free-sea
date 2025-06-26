using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager1 : MonoBehaviour
{

	[SerializeField] private GameObject[] puzzlePieces;	   // �p�Y���s�[�X�i9�j
	[SerializeField] private Transform[] correctPositions; // �������ʒu�i9�j

	private void Start()
	{
		// �e�s�[�X�ɐ������ʒu��ݒ肵�A�����_���Ȉʒu�Ɉړ�
		for (int i = 0; i < puzzlePieces.Length; i++)
		{
			PuzzlePiece1 pieceScript = puzzlePieces[i].GetComponent<PuzzlePiece1>();
			pieceScript.SetCorrectPosition(correctPositions[i]);

			// �����_���Ȉʒu�Ɉړ�
			puzzlePieces[i].transform.position = GetRandomPosition();
		}
	}

	// �����_���Ȉʒu�𐶐��i��ʓ��Ɏ��܂�悤�ɒ����j
	private Vector3 GetRandomPosition()
	{
		return new Vector3(Random.Range(-6f, 6f), Random.Range(-4f, 4f), 0);
	}
}
