using System.Collections;
using UnityEngine;

public class RaindropSpawner : MonoBehaviour
{
    [Header("Settings")]
    public GameObject raindropPrefab; 
    public float spawnInterval = 1f;
    public float xRange = 8f;

    void Start()
    {
        if (raindropPrefab == null)
        {
            Debug.LogError("Error: You have not introduced the droplet prefab to the script (check in Inspector)...!");
        }
        else
        {
            Debug.Log("Spawner successfully launched.");
            StartCoroutine(SpawnRoutine());
        }
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            
            float randomX = Random.Range(-xRange, xRange);
            Vector3 spawnPos = new Vector3(randomX, 6f, 0f); 
            
            // ایجاد قطره
            GameObject newDrop = Instantiate(raindropPrefab, spawnPos, Quaternion.identity);
            
            // گزارش در کنسول برای اطمینان
            // Debug.Log("A droplet was created at position " + spawnPos + ".");
        }
    }

    // این بخش باعث می‌شود در محیط ادیتور، محدوده تولید قطره را با خط سبز ببینی
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(-xRange, 6, 0), new Vector3(xRange, 6, 0));
    }
}