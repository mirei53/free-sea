using UnityEngine;
using UnityEngine.UI; // �� ���ꂪ�K�v�ł��I


public class Check : MonoBehaviour
{

	public GameObject panel; // PortalGate_Simple/Canvas/Panel ���A�T�C��

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player")) // �v���C���[�Ȃǂ̃^�O���m�F
		{
			Toggle toggle = panel.GetComponentInChildren<Toggle>();
			if (toggle != null)
			{
				toggle.isOn = true; // �`�F�b�N���I���ɂ���
			}

		}
	}
}
