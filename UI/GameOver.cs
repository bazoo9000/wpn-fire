using UnityEngine;

public class GameOver : MonoBehaviour
{
    static public bool _isOver = false;
    public bool _isSet = false;
    public CanvasGroup _gameOverScreen;
    public GameObject _buttons;

    private void Awake()
    {
        _gameOverScreen = GameObject.Find("GameOverScreen").GetComponent<CanvasGroup>();
    }

    private void Start()
    {
        _isOver = false;
        _isSet = false;
    }

    private void Update()
    {
        if (_isOver && !_isSet)
        {
            FadeIn();
        }
    }

    static public void GameOverScreen()
    {
        PauseMenuScripts._isPaused = true;
        Time.timeScale = 0f;
        _isOver = true;
    }

    private void FadeIn()
    {
        _gameOverScreen.alpha += Time.unscaledDeltaTime / 2f; // folosim unscaledTime deoarece timeScale este 0 (adica timpul sa oprit)

        if (_gameOverScreen.alpha >= 1)
        {
            ShowButtons();
        }
    }

    private void ShowButtons()
    {
        _buttons.SetActive(true);
        _isSet = true;
    }
}