using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    [HideInInspector]
    public Vector3 screenPoint;
    [HideInInspector]
    public Vector3 offset;
    [HideInInspector]
    public static bool isDrop = false;
    [HideInInspector]
    public bool follow = true;

    private PlayerPlaceChecker p1,p2,p3,p4;

    private void Start()
    {
        p1 = GameObject.Find("PlayerChek1").GetComponent<PlayerPlaceChecker>();
        p2 = GameObject.Find("PlayerChek2").GetComponent<PlayerPlaceChecker>();
        p3 = GameObject.Find("PlayerChek3").GetComponent<PlayerPlaceChecker>();
        p4 = GameObject.Find("PlayerChek4").GetComponent<PlayerPlaceChecker>();
    }

    private void Update()
    {
        if (follow)
        {
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            transform.position = curPosition;
            if (Input.GetMouseButtonUp(0))
            {
                if ((transform.position.y < 4.8f && transform.position.y > 2.8f) && 
                    (transform.position.x < 8.81f && transform.position.x > -8.81f) && !p1.IsLocked)
                {
                    follow = false;
                    transform.position = new Vector3(-8,3.35f, screenPoint.z);
                    foreach (Behaviour childCompnent in GetComponentsInChildren<Behaviour>())
                        childCompnent.enabled = true;
                    isDrop = true;
                }
                else if ((transform.position.y < 2.4f && transform.position.y > 0.9f) && 
                    (transform.position.x < 8.81f && transform.position.x > -8.81f) && !p2.IsLocked)
                {
                    follow = false;
                    transform.position = new Vector3(-8, 1.5f, screenPoint.z);
                    foreach (Behaviour childCompnent in GetComponentsInChildren<Behaviour>())
                        childCompnent.enabled = true;
                    isDrop = true;
                }
                else if ((transform.position.y < 0.55f && transform.position.y > -1f) && 
                    (transform.position.x < 8.81f && transform.position.x > -8.81f) && !p3.IsLocked)
                {
                    follow = false;
                    transform.position = new Vector3(-8, -0.45f, screenPoint.z);
                    foreach (Behaviour childCompnent in GetComponentsInChildren<Behaviour>())
                        childCompnent.enabled = true;
                    isDrop = true;
                }
                else if ((transform.position.y < -1.45f && transform.position.y > -3f) && 
                    (transform.position.x < 8.81f && transform.position.x > -8.81f) && !p4.IsLocked)
                {
                    follow = false;
                    transform.position = new Vector3(-8, -2.45f, screenPoint.z);
                    foreach (Behaviour childCompnent in GetComponentsInChildren<Behaviour>())
                        childCompnent.enabled = true;
                    isDrop = true;
                }
                else
                {
                    Destroy(gameObject);
                    isDrop = false;
                }
            }
        }
    }
}
