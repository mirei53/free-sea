using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager1 : MonoBehaviour
{

	[SerializeField] private GameObject[] puzzlePieces;	   // パズルピース（9個）
	[SerializeField] private Transform[] correctPositions; // 正しい位置（9個）

	private void Start()
	{
		// 各ピースに正しい位置を設定し、ランダムな位置に移動
		for (int i = 0; i < puzzlePieces.Length; i++)
		{
			PuzzlePiece1 pieceScript = puzzlePieces[i].GetComponent<PuzzlePiece1>();
			pieceScript.SetCorrectPosition(correctPositions[i]);

			// ランダムな位置に移動
			puzzlePieces[i].transform.position = GetRandomPosition();
		}
	}

	// ランダムな位置を生成（画面内に収まるように調整）
	private Vector3 GetRandomPosition()
	{
		return new Vector3(Random.Range(-6f, 6f), Random.Range(-4f, 4f), 0);
	}
}
