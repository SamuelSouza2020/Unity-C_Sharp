using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMove : MonoBehaviour
{
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * 3;
        Destroy(gameObject, 9);
    }
}
