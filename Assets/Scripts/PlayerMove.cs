using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    float dirX, dirY;
    Vector3 pos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pos = Camera.main.WorldToViewportPoint(transform.position);
    }

    void Update()
    {
        dirX = Input.GetAxis("Horizontal") * speed;
        dirY = Input.GetAxis("Vertical") * speed;
        rb.linearVelocity = new Vector2(dirX,dirY);
    }
    void OnBecameInvisible()
    {
        pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0.0f)
        {
            pos = new Vector3(1.0f, pos.y, pos.z);
        }
        else if (pos.x >= 1.0f)
        {
            pos = new Vector3(0.0f, pos.y, pos.z);
        }
        if (pos.y < 0.0f)
        {
            pos = new Vector3(pos.x, 1.0f, pos.z);
        }
        else if (pos.y >= 1.0f)
        {
            pos = new Vector3(pos.x, 0.0f, pos.z);
        }
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
