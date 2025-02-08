using System.Collections;
using UnityEngine;

public class Animate : MonoBehaviour
{
    public SpriteRenderer sr;
    public Sprite one;
    public Sprite two;
    public float animationSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(animate());
    }

    IEnumerator animate()
    {
        while (true)
        {
            sr.sprite = one;
            yield return new WaitForSeconds(animationSpeed);
            sr.sprite = two;
            yield return new WaitForSeconds(animationSpeed);
        }
    }
}
