using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void LevelsGame()
    {
        SceneManager.LoadScene("Levels");
    }
    public void SettingGame()
    {
        SceneManager.LoadScene("SettingScene");
    }
    public void AboutGame()
    {
        SceneManager.LoadScene("About");
    }
    public void ShopGame()
    {
        SceneManager.LoadScene("Shop");
    }
    public void ExitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

}
