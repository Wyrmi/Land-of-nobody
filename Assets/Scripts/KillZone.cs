using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMove>() != null)
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
