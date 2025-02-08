
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnDistance;
    public GameObject[] objectsToSpawn;
    Vector3 lastpos;
    Vector2 dir;
    Vector3 pos;

    void Start()
    {
        lastpos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(lastpos, gameObject.transform.position) > spawnDistance)
        {
            lastpos = gameObject.transform.position;
            Spawn();
        }
    }

    public void Spawn()
    {
        foreach (GameObject obj in objectsToSpawn)
        {
            dir = Random.insideUnitCircle;
            pos = dir * spawnDistance;
            Instantiate(obj, new Vector3(transform.position.x + pos.x, transform.position.y + pos.y,0), transform.rotation);
        }
    }
}
