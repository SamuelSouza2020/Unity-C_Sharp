//Antes de executar o código seu GameObject (Sprite) deve está com Rigidbody2D e collisor2D

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulo : MonoBehaviour
{

    //Aqui está chamando um corpo rígido
    Rigidbody2D rig;

    void Start()
    {
        //Aqui pega o corpo rígido do sprite que está com esse script. 
        rig = GetComponent<Rigidbody2D>();
    }

    /*
    Mesmo aplicando força, será usado o Update pois nesse exemplo de código será chamado
    constantemente (Estilo Flappy Bird), para não ter atraso ou falha será usado o Update que é 
    chamado a cada frame. Já o FixedUpdate é chamado em um intervalo de tempo fixo, por isso é mais usado
    quando o código é lento (exemplo calculos físicos).
    */
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Voce pode aplicar força no Vetor X e Y (new Vector(x,y))
            rig.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        }
    }
}
