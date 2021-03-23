using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{

    public GameObject pipe;
    

    float cont = 2;

    void Update()
    {
        cont += Time.deltaTime;

        if(cont > 2)
        {
            Instantiate(pipe, new Vector3(transform.position.x, Random.Range(-3, 1), 0), Quaternion.identity);
            cont = 0;
        }
    }
}
