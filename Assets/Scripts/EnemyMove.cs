using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour
{
    public GameObject player;
    public float speed;
    SpriteRenderer sr;
    Rigidbody2D rb;

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
            SceneManager.LoadScene(0);
        }
    }
    private void OnBecameVisible()
    {
        player = FindFirstObjectByType<PlayerMove>().gameObject;
    }
}
