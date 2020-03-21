using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public float speed = 1;
    public bool IsCollison = false;

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.right * speed * Time.deltaTime;

        if (IsCollison)
        {
            speed = 0;
        }
        else
        {
            speed = 1;
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
