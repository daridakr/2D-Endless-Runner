using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private AudioSource _gameOverSounder;

    private CanvasGroup _canvasGroup;

    private void OnEnable()
    {
        _player.Died += OnPlayerDied;

        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _player.Died -= OnPlayerDied;

        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
    }

    private void OnPlayerDied()
    {
        _gameOverSounder.Play();
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        Time.timeScale = 0;
    }

    private void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
