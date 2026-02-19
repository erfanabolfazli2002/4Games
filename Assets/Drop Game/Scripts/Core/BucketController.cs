using UnityEngine;

public class BucketController : MonoBehaviour
{
    [Header("Configuration")]

    private float moveSpeed = 8f;


    private float xBoundary = 8f;

    private Transform _transform;

    private void Awake()
    {
        // Caching Transform component for micro-optimization
        _transform = transform;
    }

    private void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        // دریافت ورودی از سیستم Input Manager
        float horizontalInput = Input.GetAxis("Horizontal");

        // محاسبه بردار جابجایی
        // استفاده از Time.deltaTime برای مستقل‌سازی سرعت از نرخ فریم
        Vector3 displacement = Vector3.right * horizontalInput * moveSpeed * Time.deltaTime;

        // اعمال حرکت به موقعیت فعلی
        _transform.Translate(displacement);

        // محدودسازی (Clamping) موقعیت سطل در کادر تصویر
        // معادل شرط‌های if(x < 0) در libGDX
        float clampedX = Mathf.Clamp(_transform.position.x, -xBoundary, xBoundary);

        _transform.position = new Vector3(clampedX, _transform.position.y, _transform.position.z);
    }
}