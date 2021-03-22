//Segundo MOVE - Nesse script mostrarei o comando de movimento transform.position

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    public float v = 5;

    void Update()
    {
        //GetKey é conforme você segura o botão, a função é executada.
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Position não aceitar o new Vector2, somente new Vector3 e new Vector4
            transform.position += new Vector3(v * Time.deltaTime, 0, 0);
        }
        //Pode ser usado o Else If para se apertar os dois ao mesmo tempo dará prioridade ao 1º
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-v * Time.deltaTime, 0, 0);
        }
    }
}
