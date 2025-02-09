using TMPro;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    public float speed;
    public int score;
    public TextMeshProUGUI scoreText;
    float dirX, dirY;
    Vector3 pos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        pos = Camera.main.WorldToViewportPoint(transform.position);
        score = 0;
    }

    void Update()
    {
        dirX = Input.GetAxis("Horizontal") * speed;
        dirY = Input.GetAxis("Vertical") * speed;
        rb.linearVelocity = new Vector2(dirX,dirY);
        
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if (rb.linearVelocity.x > 0 && !sr.flipX)
        {
            sr.flipX = true;
        }
        else if (rb.linearVelocity.x < 0 && sr.flipX)
        {
            sr.flipX = false;
        }
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        score ++;
        scoreText.text = "Souls:\n" + score;
    }
}
