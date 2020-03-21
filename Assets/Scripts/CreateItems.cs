using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateItems : MonoBehaviour
{
    public GameObject item;
    private Vector3 screenPoint;
    private Vector3 offset;
    public bool thisCard = false;

    private void OnMouseDown()
    {
        GameObject _item = (GameObject)Instantiate(item, transform.position, Quaternion.identity);
        foreach (Behaviour childCompnent in _item.GetComponentsInChildren<Behaviour>())
            childCompnent.enabled = false;
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
        Input.mousePosition.y, screenPoint.z));
        DragDrop dd = _item.GetComponent<DragDrop>();
        dd.enabled = true;
        dd.screenPoint = screenPoint;
        dd.offset = offset;
        thisCard = true;
        DragDrop.isDrop = false;
    }

    private void Update()
    {
        if (DragDrop.isDrop == true)
        {
            if(thisCard == true)
            {
                Destroy(gameObject);
            }
        }
    }
}
