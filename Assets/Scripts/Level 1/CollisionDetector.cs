using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
public class g1
{
    int level;
    int sc;
    public g1(int level, int sc)
    {
        this.level = level;
        this.sc = sc;
    }
    public int GetLevel => level;
    public int GetScore => sc;
}
public class CollisionDetector : MonoBehaviour
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
            level_score = new g1(1, score);
            SaveDate(level_score);
            gameOverBoard.enabled = true;
            resetButton.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else if (other.gameObject.tag == "SideWall")
        {
            score += 5;
            if (score < 50)
            {
                scoreText.text = "Score : " + score + " / 50";
            }
        }
        else if (other.gameObject.tag == "ButtomWall")
        {
            score += 3;
            if (score < 50)
            {
                scoreText.text = "Score : " + score + " / 50";
            }
        }
    }
    public void OnClickButton()
    {
        scoreText.text = "Score : 0 / 50";
        gameOverBoard.enabled = false;
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        Time.timeScale = 1;
    }
    public void NextLevelButton()
    {
        SceneManager.LoadScene("Level 2");
        Time.timeScale = 1;
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
        Debug.Log("Data successfully saved to file : " + path);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        endLevelText.enabled = false;
        nextLevelButton.gameObject.SetActive(false);
        resetButton.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
    // Update is called once per frame
    void Update()
    {
        if (score >= 50)
        {
            score = 50;
            scoreText.text = "Score : " + score + " / 50";
            level_score = new g1(1, score);
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
