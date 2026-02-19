using UnityEngine;
public class AudioEffects : MonoBehaviour
{
    public AudioSource backGroudMusic;
    public AudioClip audioClipGameOver;
    public AudioClip audioClipEffects;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "SideWall" || other.gameObject.tag == "ButtomWall")
        {
            SoundManager.Instance.PlayEfectSound(audioClipEffects);
        }
        else if (other.gameObject.tag == "Finish")
        {
            SoundManager.Instance.PlayGameOverSound(audioClipGameOver);
            backGroudMusic.Stop();
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
}
