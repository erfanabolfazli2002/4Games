using UnityEngine;
public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // Prefab سکه
    public float spawnInterval = 2f; // فاصله زمانی بین ایجاد سکه‌ها
    public float coinSpeed = 5f; // سرعت حرکت سکه‌ها
    private Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
        // شروع ایجاد سکه‌ها با فاصله زمانی مشخص
        InvokeRepeating("SpawnCoin", 0f, spawnInterval);
    }
    void SpawnCoin()
    {
        // ایجاد سکه در موقعیت تصادفی در سمت چپ صحنه
        float randomY = Random.Range(-4f, 4f); // موقعیت Y تصادفی
        Vector3 spawnPosition = new Vector3(mainCamera.ViewportToWorldPoint(new Vector3(-0.1f, 0, 0)).x, randomY, 0);
        GameObject newCoin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity);

        // شروع حرکت سکه به سمت راست
        StartCoroutine(MoveCoin(newCoin));
    }
    System.Collections.IEnumerator MoveCoin(GameObject coin)
    {
        while (coin != null)
        {
            // حرکت سکه به سمت راست
            coin.transform.Translate(Vector3.right * coinSpeed * Time.deltaTime);

            // بررسی خروج سکه از سمت راست صحنه
            if (coin.transform.position.x > mainCamera.ViewportToWorldPoint(new Vector3(1.1f, 0, 0)).x)
            {
                Destroy(coin); // نابود کردن سکه
                yield break;
            }
            yield return null;
        }
    }
}