using UnityEngine;
public class Movement : MonoBehaviour
{
    public Rigidbody2D body;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        body.linearVelocity = new Vector2(h * speed, v * speed);
    }
}
