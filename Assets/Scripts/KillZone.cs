using UnityEngine;

public class KillZone : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerMove>() != null)
        {
            collision.GetComponent<PlayerMove>().GetHit();
        }
    }
}
