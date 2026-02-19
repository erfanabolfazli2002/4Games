using UnityEngine;
using UnityEngine.SceneManagement;
public class MainSettingLevels : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    public void BackToLevels()
    {
        SceneManager.LoadScene("Levels");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void GotToLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void GotToLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }
}
