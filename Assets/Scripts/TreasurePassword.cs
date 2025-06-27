using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TreasurePassword : MonoBehaviour
{
	public GameObject passwordPanel;
	public TMP_InputField passwordInput;
	public string correctPassword = "1621";

	public string clearSceneName = "ClearScene";
	public string gameOverSceneName = "GameOverScene";

	private bool isPanelActive = false;

	private void Start()
	{
		passwordPanel.SetActive(false);
	}

	private void Update()
	{
		if (isPanelActive && Input.GetKeyDown(KeyCode.Return))
		{
			CheckPassword();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			passwordPanel.SetActive(true);
			isPanelActive = true;
		}
	}

	public void CheckPassword()
	{
		if (passwordInput.text == correctPassword)
		{
			SceneManager.LoadScene(clearSceneName);
		}
		else
		{
			SceneManager.LoadScene(gameOverSceneName);
		}
	}

}