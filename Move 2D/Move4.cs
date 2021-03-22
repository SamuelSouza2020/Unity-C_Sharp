using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move1 : MonoBehaviour
{
    public float v = 3;

    //FixedUpdate é utilizado quando necessita aplicar física ao corpo rígido
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //Rigidbody é o corpo físico do GameObjeto (Player)
            GetComponent<Rigidbody2D>().velocity = new Vector2(v, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-v, 0);
        }
    }
}