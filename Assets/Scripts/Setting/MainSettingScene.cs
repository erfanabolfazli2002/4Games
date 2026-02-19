using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainSettingScene : MonoBehaviour
{
    string pathfile = Path.Combine(Application.dataPath, "GameDataSetting.txt");
    public Text backGroundMusicVolume;
    public Text EffetsMusicVolume;
    public Slider backGroundMusicSlider;
    public Slider EffetsMusicSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadData(pathfile);
    }
    // Update is called once per frame
    void Update()
    {
        backGroundMusicVolume.text = Convert.ToString(backGroundMusicSlider.value);
        EffetsMusicVolume.text = Convert.ToString(EffetsMusicSlider.value);
    }
    public void SaveData(string path)
    {
        using (StreamWriter sw = new StreamWriter(path, false))
        {
            sw.Write(backGroundMusicSlider.value + "," + EffetsMusicSlider.value);
        }
    }
    public void LoadData(string path)
    {
        using (StreamReader sr = new StreamReader(path))
        {
            string[] line = sr.ReadLine().Split(",");
            backGroundMusicSlider.value = int.Parse(line[0]);
            EffetsMusicSlider.value = int.Parse(line[1]);
        }
    }
    public void SaveChangeAndBackToMenu()
    {
        SaveData(pathfile);
        SceneManager.LoadScene("Menu");
    }
}