using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public string tagToDestroy;
    public bool onHit;
    public float attack;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == tagToDestroy)
        {
            onHit = true;
            attack = coll.GetComponent<PlayerMove>().attack;
            Destroy(coll.gameObject);
        }
    }
}
