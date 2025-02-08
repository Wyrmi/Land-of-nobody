using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour
{
    public GameObject player;
    public float speed;

    void Update()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, speed * Time.deltaTime);
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
