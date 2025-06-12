using UnityEngine;

public class MovingCamera : MonoBehaviour
{
	public Transform target; // プレイヤーのTransform
	public Vector3 offset = new Vector3(0f, 5f, -10f); // プレイヤーの背後に配置
	public float smoothSpeed = 0.125f;

	void LateUpdate()
	{
		// プレイヤーの向きに合わせてオフセットを回転
		Vector3 rotatedOffset = target.rotation * offset;

		// 目標位置を計算
		Vector3 desiredPosition = target.position + rotatedOffset;

		// スムーズに追従
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;

		// プレイヤーを常に見る
		transform.LookAt(target);
	}
}
