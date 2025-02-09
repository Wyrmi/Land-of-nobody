using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    GameObject player;
    public GameObject bullet;
    Vector3 direction;
    private void OnBecameVisible()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
