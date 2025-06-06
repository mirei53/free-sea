using System.Collections;
using UnityEngine;

public class Fish : MonoBehaviour
{
	[SerializeField] float speed = 1f;                  // 魚の移動速度
	[SerializeField] float rotationSpeed = 30f;         // 回転時のトルクの強さ
	[SerializeField] float rotationInterval = 3f;       // 回転の間隔（秒）

	Rigidbody rb;

	void Start()
	{
		// Rigidbody 設定
		rb = GetComponent<Rigidbody>();
		rb.useGravity = false;                                             // 重力を無効化
		rb.collisionDetectionMode = CollisionDetectionMode.Continuous;    // 衝突検出を強化
		rb.interpolation = RigidbodyInterpolation.Interpolate;            // 滑らかな動きに補間

		// 回転処理のコルーチンを開始
		StartCoroutine(RotateFishRoutine());
	}

	// 一定間隔でランダムに回転するコルーチン
	IEnumerator RotateFishRoutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(rotationInterval);

			// Y軸方向にランダムなトルクを加える（水平回転）
			float randomY = Random.Range(-1f, 1f);
			//z軸方向にランダムなトルクを追加
			rb.AddTorque(Vector3.up * randomY * rotationSpeed, ForceMode.Impulse);
		}
	}

	// 物理演算に基づく移動処理
	void FixedUpdate()
	{
		// 前方に一定速度で移動
		rb.velocity = transform.forward * speed;
	}

	// 衝突時の処理
	void OnCollisionEnter(Collision collision)
	{
		// 衝突した相手が BoxCollider を持っているか確認
		if (collision.collider is BoxCollider)
		{
			// 進行方向を反転（Rigidbody を使って回転）
			Quaternion newRotation = Quaternion.LookRotation(-transform.forward);
			rb.MoveRotation(newRotation);
		}
	}
}
