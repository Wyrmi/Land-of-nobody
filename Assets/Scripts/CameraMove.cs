using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    float dirX, dirY;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        dirX = Input.GetAxis("Fire2") * speed;
        dirY = Input.GetAxis("Fire1") * speed;
        rb.linearVelocity = new Vector2(dirX,dirY);
    }
}
