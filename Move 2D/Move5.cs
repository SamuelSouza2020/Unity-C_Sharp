using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move5 : MonoBehaviour
{

    public float vel = 3;

    void Update()
    {
        float H = Input.GetAxis("Mouse X");
        float V = Input.GetAxis("Mouse Y");

        transform.Translate(new Vector2(H * Time.deltaTime * vel, V * Time.deltaTime * vel));
    }
}