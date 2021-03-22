//Primeiro MOVE - Nesse script mostrarei o comando de movimento transform.Translate

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move1 : MonoBehaviour
{
    //A velocidade pode ser ajustada no Inspector da Unity.
    public float v = 5;

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Vector2(X,Y)
            transform.Translate(new Vector2(v * Time.deltaTime, 0));
        }
        //Trocando o segundo if por Else if, quando você apertar os dois botões ao mesmo tempo, a preferencia do comando vai para o primeiro código (RightArrow)
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector2(-v * Time.deltaTime, 0));
        }
    }
}
