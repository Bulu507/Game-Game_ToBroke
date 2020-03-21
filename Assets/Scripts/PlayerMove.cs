using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float attack;

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    }
}
