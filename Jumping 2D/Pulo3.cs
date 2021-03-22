//dois pulos ou double jump. Código simples para fazer o GameObject pular 2 vezes

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulo3 : MonoBehaviour
{
    //No primeiro boolean ele verificará se o sprite está no chão
    bool isJumping = true;
    
    //No segundo boolean ele verificará se deu o primeiro pulo
    bool jumpRep = false;

    void Update()
    {
        Jumping();
    }

    void Jumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            //O Player dando o primeiro pulo, o segundo pulo ficará ativo para pular novamente
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 8), ForceMode2D.Impulse);
            isJumping = true;
            jumpRep = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && jumpRep == true)
        {
            //O Player dando o segundo pulo, ele fica desativado até dar o primeiro pulo novamente
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 8), ForceMode2D.Impulse);
            jumpRep = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chao"))
        {
            //Quando o Player toca no chão, é desativado o boolean dele pulando e do segundo pulo
            isJumping = false;
            jumpRep = false;
        }
    }
}