using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    AudioSource audioSource;
    private void OnBecameVisible()
    {
        Instantiate(bullet, transform.position, Quaternion.identity);
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}
