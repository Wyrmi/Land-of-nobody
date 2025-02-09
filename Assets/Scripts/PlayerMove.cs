using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rb;
    SpriteRenderer sr;
    AudioSource deathSFX;
    public AudioSource horse;
    public AudioSource soulCollect;
    public float speed;
    public int score;
    public TextMeshProUGUI scoreText;
    public GameObject soul;
    public float soulDropDistance;
    public float animationSpeed;
    public Sprite[] horseAnim;
    float dirX, dirY;
    Vector3 pos;
    Vector2 ringdir;
    Vector3 ringpos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        deathSFX = GameObject.FindGameObjectWithTag("DeathSFX").GetComponent<AudioSource>();
        pos = Camera.main.WorldToViewportPoint(transform.position);
        score = 0;
        StartCoroutine(animate());
    }

    void Update()
    {
        dirX = Input.GetAxis("Horizontal") * speed;
        dirY = Input.GetAxis("Vertical") * speed;
        rb.linearVelocity = new Vector2(dirX,dirY);
        
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        if (rb.linearVelocity.x > 0 && !sr.flipX)
        {
            sr.flipX = true;
        }
        else if (rb.linearVelocity.x < 0 && sr.flipX)
        {
            sr.flipX = false;
        }
        if (horse.isPlaying && rb.linearVelocity == Vector2.zero)
        {
            horse.Pause();
        }
        else if (!horse.isPlaying && rb.linearVelocity != Vector2.zero)
        {
            horse.Play();
        }
    }

    IEnumerator animate()
    {
        int i = 0;
        while (true)
        {
            yield return new WaitForSeconds(animationSpeed);
            if (rb.linearVelocity != Vector2.zero)
            {
                i++;
                if (i == horseAnim.Length)
                    i= 0;
                sr.sprite = horseAnim[i];
            }
        }
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Animate>() != null)
        {
            Destroy(collision.gameObject);
            soulCollect.Play();
            score++;
            scoreText.text = "Souls:\n" + score;
        }
    }

    public void GetHit()
    {
        deathSFX.Play();
        if (score > 0)
        {
            for (int i = 0; i < score; i++)
            {
                Debug.Log(i);
                ringdir = Random.insideUnitCircle;
                pos = ringdir * soulDropDistance;
                Instantiate(soul, new Vector3(transform.position.x + pos.x, transform.position.y + pos.y, 0), transform.rotation);
            }
            score = 0;
            scoreText.text = "Souls:\n" + score;
        }
        else {
            SceneManager.LoadScene(0);
        }
    }
}
