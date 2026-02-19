using UnityEngine;
using UnityEngine.SceneManagement;
public class SplashScreenManager : MonoBehaviour
{
    public float splashScreenDuration = 3f; // مدت زمان نمایش اسپلش اسکرین
    public string nextSceneName = "Menu"; // نام صحنه بعدی
    void Start()
    {
        // شروع کروتین برای تغییر صحنه پس از مدت زمان مشخص
        StartCoroutine(LoadNextSceneAfterDelay());
    }
    System.Collections.IEnumerator LoadNextSceneAfterDelay()
    {
        // منتظر ماندن برای مدت زمان مشخص
        yield return new WaitForSeconds(splashScreenDuration);
        // تغییر به صحنه بعدی
        SceneManager.LoadScene(nextSceneName);
    }
}