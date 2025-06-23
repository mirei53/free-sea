using UnityEngine;
using UnityEngine.UI; // ← これが必要です！


public class Check : MonoBehaviour
{

	public GameObject panel; // PortalGate_Simple/Canvas/Panel をアサイン

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player")) // プレイヤーなどのタグを確認
		{
			Toggle toggle = panel.GetComponentInChildren<Toggle>();
			if (toggle != null)
			{
				toggle.isOn = true; // チェックをオンにする
			}

		}
	}
}
