using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{

    public GameObject pipe;
    

    float cont = 2;
    //float height = 1.5f;

    void Update()
    {
        cont += Time.deltaTime;

        if(cont > 2)
        {
            Instantiate(pipe, new Vector3(transform.position.x, Random.Range(-3, 1), 0), Quaternion.identity);
            cont = 0;
            //Debug.Log(height);
        }
    }
}
