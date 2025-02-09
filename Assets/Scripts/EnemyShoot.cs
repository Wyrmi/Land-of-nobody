using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    public float shootDelay;
    AudioSource audioSource;
    private void OnBecameVisible()
    {
        
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot() {
        while (true)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            audioSource.Play();
            yield return new WaitForSeconds(shootDelay);
        }
    }
}
