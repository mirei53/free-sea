using System.Collections;
using UnityEngine;

public class Fish : MonoBehaviour
{
	// 魚の移動速度
	[SerializeField] float speed = 1f;

	// 回転時に加えるトルクの強さ
	[SerializeField] float rotationSpeed = 0.1f;

	// 回転の間隔（秒）
	[SerializeField] float rotationInterval = 3f;

	// Rigidbody コンポーネントへの参照
	Rigidbody rb;

	void Start()
	{
		// Rigidbody を取得
		rb = GetComponent<Rigidbody>();

		// 回転処理のコルーチンを開始
		StartCoroutine(RotateFishRoutine());
	}

	// 一定間隔でランダムな方向に回転するコルーチン
	IEnumerator RotateFishRoutine()
	{
		// 回転パターンの配列（複数の方向の組み合わせ）
		Vector3[][] torquePatterns = new Vector3[][]
		{
			new[] { Vector3.down, Vector3.right },
			new[] { Vector3.up, Vector3.right },
			new[] { Vector3.down, Vector3.left },
			new[] { Vector3.up, Vector3.right },
			new[] { Vector3.up },
			new[] { Vector3.down }
		};

		while (true)
		{
			// 指定時間待機
			yield return new WaitForSeconds(rotationInterval);

			// ランダムなパターンを選択
			int index = Random.Range(0, torquePatterns.Length);

			// 選ばれた方向にトルクを加える
			foreach (var dir in torquePatterns[index])
			{
				rb.AddTorque(dir * rotationSpeed, ForceMode.Impulse);
			}
		}
	}

	void Update()
	{
		// 前方に一定速度で移動
		rb.velocity = transform.forward * speed;

		// 姿勢を安定させるための補正トルクを加える
		ApplyCorrectionTorque(Vector3.left);
		ApplyCorrectionTorque(Vector3.forward);
	}

	// 指定されたローカル方向に対して姿勢補正トルクを加える
	void ApplyCorrectionTorque(Vector3 localDirection)
	{
		// ローカル方向をワールド方向に変換
		Vector3 worldDir = transform.TransformVector(localDirection);

		// 水平方向の成分を抽出して正規化
		Vector3 horizontal = new Vector3(worldDir.x, 0, worldDir.z).normalized;

		// 姿勢補正のためのトルクを加える
		rb.AddTorque(Vector3.Cross(worldDir, horizontal) * 4, ForceMode.Force);
	}

	// 衝突時の処理
	void OnCollisionEnter(Collision collision)
	{
		// "Box" タグのオブジェクトに衝突した場合
		if (collision.collider.CompareTag("Box"))
		{
			// 上方向にジャンプ
			rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);

			// 進行方向を反転
			transform.rotation = Quaternion.LookRotation(-transform.forward);
		}
	}
}
