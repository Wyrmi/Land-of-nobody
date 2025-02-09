using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb;
    public float speed;
    Vector2 dir;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindFirstObjectByType<PlayerMove>().gameObject;
        dir = (player.transform.position - transform.position).normalized;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg));
    }

    void Update()
    {
        rb.linearVelocity = dir * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMove>() != null)
        {
            collision.GetComponent<PlayerMove>().GetHit();
            Destroy(gameObject);
        }
    }
}
