using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PuzzleManager1 : MonoBehaviour
{
	[SerializeField] private GameObject[] puzzlePieces;
	[SerializeField] private Transform[] correctPositions;

	private bool allSnapped = false;

	private void Start()
	{
		for (int i = 0; i < puzzlePieces.Length; i++)
		{
			PuzzlePiece1 pieceScript = puzzlePieces[i].GetComponent<PuzzlePiece1>();
			pieceScript.SetCorrectPosition(correctPositions[i]);

			puzzlePieces[i].transform.position = GetRandomPosition();
		}
	}

	private void Update()
	{
		if (!allSnapped && AreAllPiecesSnapped())
		{
			allSnapped = true;
			Debug.Log("���ׂẴs�[�X���������ʒu�ɃX�i�b�v����܂����B3�b��ɃV�[����؂�ւ��܂��B");
			StartCoroutine(ReturnToGameScene());
		}
	}

	private Vector3 GetRandomPosition()
	{
		return new Vector3(Random.Range(-6f, 6f), Random.Range(-4f, 4f), 0);
	}

	public bool AreAllPiecesSnapped()
	{
		foreach (GameObject piece in puzzlePieces)
		{
			PuzzlePiece1 script = piece.GetComponent<PuzzlePiece1>();
			if (!script.IsSnapped()) return false;
		}
		return true;
	}

	private IEnumerator ReturnToGameScene()
	{
		yield return new WaitForSeconds(3f);
		SceneManager.LoadScene("GameScene"); // �J�ڐ�̃V�[�����ɕύX���Ă�������
	}
}
