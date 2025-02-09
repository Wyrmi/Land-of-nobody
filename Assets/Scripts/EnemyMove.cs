using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public GameObject player;
    public float speed;
    SpriteRenderer sr;
    Rigidbody2D rb;
    Vector3 pos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (player != null)
        {
            Vector2 dir = player.transform.position - gameObject.transform.position;
            rb.linearVelocity = dir.normalized * speed;
        }
        if (rb.linearVelocity.x < 0 && !sr.flipX)
        {
            sr.flipX = true;
        }
        else if (rb.linearVelocity.x > 0 && sr.flipX)
        {
            sr.flipX = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMove>() != null) {
            collision.GetComponent<PlayerMove>().GetHit();
            Destroy(gameObject);
        }
    }
    private void OnBecameVisible()
    {
        player = FindFirstObjectByType<PlayerMove>().gameObject;
        pos = Camera.main.WorldToViewportPoint(transform.position);
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
