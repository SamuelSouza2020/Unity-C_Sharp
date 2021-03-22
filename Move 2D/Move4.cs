//Nesse script é aplicado velocidade (velocity) em um corpo rígido (rigidbody)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move4 : MonoBehaviour
{
    public float v = 3;

    //FixedUpdate é utilizado quando necessita aplicar física ao corpo rígido
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Rigidbody é o corpo rígido do GameObjeto (Player)
            GetComponent<Rigidbody2D>().velocity = new Vector2(v, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //Velocidade está sendo aplicada no corpo rígido
            GetComponent<Rigidbody2D>().velocity = new Vector2(-v, 0);
        }
    }
}
