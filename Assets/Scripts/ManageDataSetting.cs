using System.IO;
using UnityEngine;
public class ManageDataSetting : MonoBehaviour
{
    string pathfile = Path.Combine(Application.dataPath, "GameDataSetting.txt");
    int backGroundMusic = 0;
    int EffetsMusic = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadDate(pathfile);
        ApplyVolumeToAllAudioSources();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void ApplyVolumeToAllAudioSources()
    {
        // پیدا کردن تمام AudioSourceها در صحنه فعلی
        AudioSource[] audioSources = FindObjectsByType<AudioSource>(FindObjectsSortMode.None);

        // اعمال میزان صدا به هر AudioSource
        foreach (AudioSource audioSource in audioSources)
        {
            if (audioSource.name == "BackGroudMusic")
                audioSource.volume = backGroundMusic;
            else
                audioSource.volume = EffetsMusic;
        }
    }
    public void LoadDate(string path)
    {
        string[] data = new string[2];
        using (StreamReader sr = new StreamReader(path))
        {
            string[] line = sr.ReadLine().Split(",");
            backGroundMusic = int.Parse(line[0]);
            EffetsMusic = int.Parse(line[1]);
        }
    }
}
