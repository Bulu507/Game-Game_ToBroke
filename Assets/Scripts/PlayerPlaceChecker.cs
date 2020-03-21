using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlaceChecker : MonoBehaviour
{
    public List<GameObject> activePlayer;
    public bool IsLocked = false;

    private void Start()
    {
        activePlayer = new List<GameObject>();
    }

    private void Update()
    {
       
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        IsLocked = true;

        if (coll.gameObject.tag == "Player")
        {
            activePlayer.Add(coll.gameObject);
            Debug.Log("HJH = " + IsLocked);
        }

        //if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Player")
        //{
        //    IsLocked = true;
        //}

    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        IsLocked = false;
        Debug.Log("HJH = " + IsLocked);
        //if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Player")
        //{
        //    IsLocked = false;
        //}
    }
}
