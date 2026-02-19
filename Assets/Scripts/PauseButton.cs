using UnityEngine;
using UnityEngine.UI;
public class Pausebotton : MonoBehaviour
{
    public Text pause;
    public Text gameOver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pause.enabled = false;
        gameOver.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (gameOver.enabled == false)
            {
                if (Time.timeScale == 0)
                {
                    Time.timeScale = 1;
                    pause.enabled = false;
                }
                else
                {
                    Time.timeScale = 0;
                    pause.enabled = true;
                }
            }
        }
    }
}
