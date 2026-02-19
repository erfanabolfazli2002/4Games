using UnityEngine;
using UnityEngine.AddressableAssets; // برای دسترسی به متدهای آدرس‌دهی
using UnityEngine.UI; // اگر بخواهید دکمه‌ها را مدیریت کنید

public class GameLauncher : MonoBehaviour
{
    // این متد را به دکمه (Button) در اینسپکتور وصل می‌کنیم
    public void LoadMiniGame(string key)
    {
        // key همان اسمی است که در پنجره Addressables به بازی دادید (مثلاً Game1)
        Addressables.LoadSceneAsync(key);
    }
}