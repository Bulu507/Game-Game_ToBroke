using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [HideInInspector]
    public Vector3 screenPoint;
    public float jeda;
    public float timeStart = 25f;
    public float timeTo = 50f;
    private float randomDelay;
    float timer;
    public GameObject[] enemies;
    private List<GameObject> activeEnemies;
    private bool IsKnock = false;
    public bool letSpawn = false;

    // Use this for initialization
    void Start()
    {
        activeEnemies = new List<GameObject>();

        randomDelay = Random.Range(timeStart, timeTo);
    }
    // Update is called once per frame
    void Update()
    {
        if (letSpawn)
        {
            if (!IsKnock)
            {
                int randomEnemies = Random.Range(0, enemies.Length);
                Instantiate(enemies[randomEnemies], transform.position, Quaternion.Euler(0, 180, 0));
                letSpawn = false;
            }
        }

        if (Input.GetKeyDown("space"))
        {
            
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            activeEnemies.Add(coll.gameObject);
        }

        if(coll.gameObject.tag == "Player")
        {
            IsKnock = true;
            foreach(GameObject i in activeEnemies)
            {
                Destroy(i);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            IsKnock = false;
        }
    }
}
