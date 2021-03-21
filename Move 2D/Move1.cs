//Nesse script mostrarei o comando de movimento transform.Translate


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move1 : MonoBehaviour
{
    //A velocidade pode ser ajustada no Inspector da Unity.
    public float v = 5;

    void Update()
    {
        //Quando é utilizado sem valor ou boolean o if considera se for Input... == true
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Vector2(X,Y)
            transform.Translate(new Vector2(v * Time.deltaTime, 0));
        }
        //Pode ser usado o Else If para se apertar os dois ao mesmo tempo dará prioridade ao 1º
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector2(-v * Time.deltaTime, 0));
        }
    }
}
