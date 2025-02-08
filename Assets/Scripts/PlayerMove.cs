using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    float dirX, dirY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal") * speed;
        dirY = Input.GetAxis("Vertical") * speed;
        rb.linearVelocity = new Vector2(dirX,dirY);
    }
}
