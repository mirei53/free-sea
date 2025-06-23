using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitching : MonoBehaviour
{
	[SerializeField] private Button startButton;
	[SerializeField] private Button retryButton;
	[SerializeField] private Button titleButton;
	[SerializeField] private AudioClip bgmClip;

	private AudioSource audioSource;

	private void Start()
	{
		// AudioSource を取得または追加
		audioSource = GetComponent<AudioSource>();
		if (audioSource == null)
		{
			audioSource = gameObject.AddComponent<AudioSource>();
		}

		audioSource.playOnAwake = false;

		// ボタンイベント登録
		if (startButton != null)
			startButton.onClick.AddListener(OnStartButtonClicked);

		if (retryButton != null)
			retryButton.onClick.AddListener(OnRetryButtonClicked);

		if (titleButton != null)
			titleButton.onClick.AddListener(OnTitleButtonClicked);
	}

	private void PlayBGM()
	{
		if (bgmClip != null && audioSource != null)
		{
			audioSource.clip = bgmClip;
			audioSource.Play();
		}
	}

	private void OnStartButtonClicked()
	{
		PlayBGM();
		SceneManager.LoadScene("GameScene");
	}

	private void OnRetryButtonClicked()
	{
		PlayBGM();
		SceneManager.LoadScene("GameScene");
	}

	private void OnTitleButtonClicked()
	{
		PlayBGM();
		SceneManager.LoadScene("TitleScene");
	}
}
