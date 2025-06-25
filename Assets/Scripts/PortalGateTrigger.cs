using UnityEngine;

public class PortalGateTrigger : MonoBehaviour
{
	public GameObject panel; // 表示・非表示を切り替えるPanel

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			panel.SetActive(true); // Panelを表示
		}
	}
}
