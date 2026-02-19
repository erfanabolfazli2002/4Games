using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    string path = Path.Combine(Application.dataPath, "GameDateScore.txt");
    g1 level_score;
    public Button nextLevelButton;
    public Button resetButton;
    public Text endLevelText;
    public Text gameOverBoard;
    public Text scoreText;
    private int score = 0;
    public AudioClip audioClipWinner;
    public AudioSource backGroundMusic;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Finish")
        {
            level_score = new g1(2, score);
            SaveDate(level_score);
            gameOverBoard.enabled = true;
            resetButton.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            score += 5;
            if (score < 60)
            {
                scoreText.text = "Score : " + score + " / 60";
            }
        }
    }
    public void ResetGameButton()
    {
        scoreText.text = "Score : 0 / 60";
        gameOverBoard.enabled = false;
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        Time.timeScale = 1;
    }
    public void NextLevelButton()
    {
        SceneManager.LoadScene("Level 3");
    }
    public void BackToMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
    public void SaveDate(g1 score)
    {
        using (StreamWriter sw = new StreamWriter(path, true))
        {
            sw.WriteLine(score.GetLevel + "," + score.GetScore);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        nextLevelButton.gameObject.SetActive(false);
        resetButton.gameObject.SetActive(false);
        endLevelText.enabled = false;
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        if (score >= 60)
        {
            score = 60;
            scoreText.text = "Score : " + score + " / 60";
            level_score = new g1(2, score);
            SaveDate(level_score);
            GameObject.FindWithTag("ball").SetActive(false);
            GameObject.FindWithTag("ObjectGame").SetActive(false);
            endLevelText.enabled = true;
            nextLevelButton.gameObject.SetActive(true);
            resetButton.gameObject.SetActive(true);
            backGroundMusic.Stop();
            SoundManager.Instance.PlayEfectSound(audioClipWinner);
            Time.timeScale = 0;
        }
    }

}
