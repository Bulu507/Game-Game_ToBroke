using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public float delay;
    float timer;
    public EnemySpawner[] enemiesSpawner;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > delay)
        {
            int randomSpawner = Random.Range(0, enemiesSpawner.Length);
            enemiesSpawner[randomSpawner].letSpawn = true;
            timer = 0;
        }

        if (Input.GetKeyDown("space"))
        {

        }
    }
}
