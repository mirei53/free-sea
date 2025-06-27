using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TreasurePassword : MonoBehaviour
{
	[Header("UI Elements")]
	public GameObject passwordPanel;
	public InputField passwordInput;
	public Text feedbackText;
	public Button submitButton;

	[Header("Password Settings")]
	public string correctPassword = "secret123";
	public int maxAttempts = 3;

	private int attemptCount = 0;

	void Start()
	{
		passwordPanel.SetActive(false);
		submitButton.onClick.AddListener(CheckPassword);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			ShowPasswordUI();
		}
	}

	void ShowPasswordUI()
	{
		passwordPanel.SetActive(true);
		feedbackText.text = "�p�X���[�h����͂��Ă�������";
		passwordInput.text = "";
	}

	public void CheckPassword()
	{
		if (passwordInput.text == correctPassword)
		{
			SceneManager.LoadScene("GameClearScene");
		}
		else
		{
			attemptCount++;
			feedbackText.text = $"�p�X���[�h���Ⴂ�܂��i{attemptCount}/{maxAttempts}�j";

			if (attemptCount >= maxAttempts)
			{
				SceneManager.LoadScene("GameOverScene");
			}
		}
	}
}