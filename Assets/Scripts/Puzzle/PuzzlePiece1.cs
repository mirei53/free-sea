using UnityEngine;

public class PuzzlePiece1 : MonoBehaviour
{
	[SerializeField] private Transform correctPosition;  // 正しい位置
	[SerializeField] private float snapThreshold = 0.5f; // スナップ距離

	private bool isSnapped = false;
	private bool isDragging = false;
	private Vector3 offset;

	void Update()
	{
		// マウスボタンを押したとき
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out RaycastHit hit))
			{
				if (hit.transform == transform && !isSnapped)
				{
					isDragging = true;
					offset = transform.position - hit.point;
				}
			}
		}

		// マウスボタンを離したとき
		if (Input.GetMouseButtonUp(0))
		{
			isDragging = false;

			// スナップ判定
			if (Vector3.Distance(transform.position, correctPosition.position) < snapThreshold)
			{
				transform.position = correctPosition.position;
				isSnapped = true;

				// コライダーを無効化して固定
				Collider col = GetComponent<Collider>();
				if (col != null) col.enabled = false;
			}
		}

		// ドラッグ中の移動
		if (isDragging && !isSnapped)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out RaycastHit hit))
			{
				Vector3 targetPos = hit.point + offset;
				transform.position = new Vector3(targetPos.x, targetPos.y, correctPosition.position.z); // Z軸固定
			}
		}
	}

	// PuzzleManagerから正しい位置を設定するためのメソッド
	public void SetCorrectPosition(Transform target)
	{
		correctPosition = target;
	}

	// 正しく配置されたかどうかを外部から確認するためのメソッド
	public bool IsSnapped()
	{
		return isSnapped;
	}
}
