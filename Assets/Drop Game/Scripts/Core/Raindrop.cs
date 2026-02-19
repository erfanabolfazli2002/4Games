using UnityEngine;

public class Raindrop : MonoBehaviour
{
    public float fallSpeed = 5f;
    public AudioClip collectSound; // صدای جمع‌آوری قطره

    void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
        if (transform.position.y < -6f)
        {
            DropGameManager.Instance.OnLifeLost();
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // پخش صدا قبل از نابودی
            if (collectSound != null)
            {
                // این متد یک اسپیکر موقت در صحنه می‌سازه تا با نابودی قطره صدا قطع نشه
                AudioSource.PlayClipAtPoint(collectSound, Camera.main.transform.position);
            }
            
            DropGameManager.Instance.AddScore(10);
            Destroy(gameObject);
        }
    }
}