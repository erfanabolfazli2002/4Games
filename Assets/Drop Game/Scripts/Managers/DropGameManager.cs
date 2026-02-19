using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DropGameManager : MonoBehaviour
{
    public static DropGameManager Instance { get; private set; }

    [Header("Game Settings")]
    public int maxLives = 3;
    private int _currentScore = 0;
    private int _currentLives;
    private bool _isGameOver = false;

    [Header("UI References")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public GameObject gameOverPanel; // این همون پنلی هست که گفتی متوجه نشدی
    public TextMeshProUGUI finalScoreText;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        Time.timeScale = 1f; // مطمئن می‌شیم بازی در جریان هست
        _currentLives = maxLives;
        UpdateUI();
        if (gameOverPanel != null) gameOverPanel.SetActive(false); // در شروع بازی پنل مخفی باشه
    }

    public void AddScore(int amount)
    {
        if (_isGameOver) return;
        _currentScore += amount;
        UpdateUI();
    }

    public void OnLifeLost()
    {
        if (_isGameOver) return;
        _currentLives--;
        UpdateUI();
        if (_currentLives <= 0) TriggerGameOver();
    }

    private void UpdateUI()
    {
        if (scoreText != null) scoreText.text = "Score: " + _currentScore;
        if (livesText != null) livesText.text = "Lives: " + _currentLives;
    }

    private void TriggerGameOver()
    {
        _isGameOver = true;
        Time.timeScale = 0f; // توقف فیزیک و حرکت
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true); // نمایش پنل پایان بازی
            if (finalScoreText != null) finalScoreText.text = "Final Score: " + _currentScore;
        }
    }

    // متدهای دکمه‌ها
    public void RestartGame() => SceneManager.LoadScene("DropGame");
    public void QuitGame() => Application.Quit();
}