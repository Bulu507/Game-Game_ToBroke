using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuckDetector : MonoBehaviour
{
    public Card card;

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Card")
        {
            this.card.IsCollison = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Card")
        {
            this.card.IsCollison = true;
        }
    }
}
