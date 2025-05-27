using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
	[SerializeField]
	float speed = 0.3f;

	[SerializeField]
	float rotationSpeed = 0.01f;

	[SerializeField]
	float rotation_Interval = 3f;

	Rigidbody iwasirigid;

	void Start()
	{
		iwasirigid = GetComponent<Rigidbody>();
		StartCoroutine(RotateFishRoutine());
	}

	IEnumerator RotateFishRoutine()
	{
		while (true)
		{
			yield return new WaitForSeconds(rotation_Interval);

			int count = Random.Range(0, 6);
			Debug.Log(count);

			switch (count)
			{
				case 0:
					// �������A�������Ƀg���N��������
					iwasirigid.AddTorque(Vector3.down * rotationSpeed, ForceMode.Impulse);
					iwasirigid.AddTorque(Vector3.right * rotationSpeed, ForceMode.Impulse);
					break;
				case 1:
					// �E�����A�������Ƀg���N��������
					iwasirigid.AddTorque(Vector3.up * rotationSpeed, ForceMode.Impulse);
					iwasirigid.AddTorque(Vector3.right * rotationSpeed, ForceMode.Impulse);
					break;
				case 2:
					// �������A������Ƀg���N��������
					iwasirigid.AddTorque(Vector3.down * rotationSpeed, ForceMode.Impulse);
					iwasirigid.AddTorque(Vector3.left * rotationSpeed, ForceMode.Impulse);
					break;
				case 3:
					// �E�����A������Ƀg���N��������
					iwasirigid.AddTorque(Vector3.up * rotationSpeed, ForceMode.Impulse);
					iwasirigid.AddTorque(Vector3.right * rotationSpeed, ForceMode.Impulse);
					break;
				case 4:
					// �E�����Ƀg���N��������
					iwasirigid.AddTorque(Vector3.up * rotationSpeed, ForceMode.Impulse);
					break;
				case 5:
					// �������Ƀg���N��������
					iwasirigid.AddTorque(Vector3.down * rotationSpeed, ForceMode.Impulse);
					break;
			}
		}
	}

	void Update()
	{
		// �O�ɐi��
		iwasirigid.velocity = transform.forward * speed;

		// �O�ςŌ��ɖ߂� X������
		Vector3 left = transform.TransformVector(Vector3.left);
		Vector3 hori_left = new Vector3(left.x, 0, left.z).normalized;
		iwasirigid.AddTorque(Vector3.Cross(left, hori_left) * 4, ForceMode.Force);

		// �O�ςŌ��ɖ߂� Z������
		Vector3 forward = transform.TransformVector(Vector3.forward);
		Vector3 hori_forward = new Vector3(forward.x, 0, forward.z).normalized;
		iwasirigid.AddTorque(Vector3.Cross(forward, hori_forward) * 4, ForceMode.Force);
	}
}