//Nesse script será mostrado como inverter o GameObject usando SpriteRenderer

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FliSpriteRen: MonoBehaviour
{
    //Aqui será chamado o SpriteRenderer e uma variavel float vazia
    SpriteRenderer spt;
    float H;

    void Start()
    {
        //Ele pega o spriterenderer do GameObject que está esse script
        spt = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        //A variavel H é usada como GetAxis para movimentar o GameObject
        H = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(H * Time.deltaTime, 0));

        //Chamamos o método Flip
        Flip();
    }
    void Flip()
    {
        /*
        Se você colocar a variável H no print ou Debug.Log
        verá que se apertar para a direita o valor vai até 1
        se apertar para esquerda, vai até -1
        */
        if(H > 0)
        {
            //indo no Inspector verá no SpriteRenderer o Flip X e Y
            spt.flipX = false;
        }else if(H < 0)
        {
            spt.flipX = true;
        }  
    }
}