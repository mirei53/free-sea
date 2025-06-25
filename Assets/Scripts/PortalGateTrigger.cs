using UnityEngine;

public class PortalGateTrigger : MonoBehaviour
{
	public GameObject panel; // �\���E��\����؂�ւ���Panel

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			panel.SetActive(true); // Panel��\��
		}
	}
}
