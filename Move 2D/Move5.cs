//Um exemplo básico de como utilizar o Mouse para movimentar o Player.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move5 : MonoBehaviour
{

    public float vel = 3;

    void Update()
    {
        //Aqui você está chamando o método pronto da Unity, que está localizado em: Edit>Project Settings>Input Manager
        float H = Input.GetAxis("Mouse X");
        float V = Input.GetAxis("Mouse Y");

        transform.Translate(new Vector2(H * Time.deltaTime * vel, V * Time.deltaTime * vel));
    }
}