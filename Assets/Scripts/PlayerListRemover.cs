using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerListRemover : MonoBehaviour
{
    public GameObject playerChecker;
    public List<GameObject> activePlayer;

    private void Update()
    {
        activePlayer = playerChecker.GetComponent<PlayerPlaceChecker>().activePlayer;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            Debug.Log("masuk enemy");
            foreach (GameObject i in activePlayer)
            {
                Debug.Log("asd = "+i);
                Destroy(i);
            }
        }
    }
}
