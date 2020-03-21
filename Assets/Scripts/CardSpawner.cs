using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    public float jeda = 0.8f;
    float timer;
    public GameObject[] cards;
    private bool IsCollison = false;
    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > jeda)
        {
            int random = Random.Range(0, cards.Length);
            Instantiate(cards[random], transform.position, transform.rotation);
            timer = 0;
        }

        if (IsCollison)
        {
            timer = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Card")
        {
            IsCollison = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Card")
        {
            IsCollison = false;
        }
    }
}
