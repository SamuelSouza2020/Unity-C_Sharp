//Nesse script você não precisa chamar componente

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipScale : MonoBehaviour
{
    float H;

    void Update()
    {
        H = Input.GetAxis("Horizontal");
        transform.Translate(new Vector2(H * Time.deltaTime, 0));

        Flip();
    }
    void Flip()
    {
        if(H > 0)
        {
            //É usado diretamente o transform
            //A Escala do Objeto muda, não precisando usar o flip Renderer
            transform.localScale = new Vector3(1.2f, 1.2f, 0);
        }else if(H < 0)
        {
            transform.localScale = new Vector3(-1.2f, 1.2f, 0);
        }  
    }
}