using UnityEngine;

public class MovingCamera : MonoBehaviour
{
	public Transform target; // プレイヤーのTransform
	public float smoothSpeed = 0.1f;
	public float lookUpOffset = 1.5f; // どれだけ上を見るか

	private Vector3 initialOffset;

	void Start()
	{
		// 初期位置からプレイヤーへの相対オフセットを記録
		initialOffset = Quaternion.Inverse(target.rotation) * (transform.position - target.position);
	}

	void LateUpdate()
	{
		// プレイヤーの向きに合わせてオフセットを回転
		Vector3 rotatedOffset = target.rotation * initialOffset;

		// 目標位置を計算
		Vector3 desiredPosition = target.position + rotatedOffset;

		// スムーズに追従
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;

		// プレイヤーの少し上を向く
		Vector3 lookAtPoint = target.position + Vector3.up * lookUpOffset;
		transform.LookAt(lookAtPoint);
	}
}
