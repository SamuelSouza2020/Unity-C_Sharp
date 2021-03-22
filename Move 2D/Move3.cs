//Invés de usar o GetKey, iremos utilizar o GetAxis (método pronto do Unity)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move1 : MonoBehaviour
{
    //A velocidade pode ser ajustada no Inspector da Unity.
    public float v = 3;

    void Update()
    {
        //GetAxis Horizontal voce poderá modificar pelo Edit>Project Settings>Input Manager>Horizontal
        float H = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(H * Time.deltaTime * v, 0, 0));
    }
}
