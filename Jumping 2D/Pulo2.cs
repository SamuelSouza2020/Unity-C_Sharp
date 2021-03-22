/*
Nesse script o GameObject irá pular somente quando tocar o chão
No objeto que você deixará como chão, terá que está com a Tag "chao" (pode ser outro nome).
Para colocar uma tag em um objeto basta apertar no objeto (na Unity) e no Inspector abaixo do nome estará
escrito Tag. Você apertará na Tag onde provavelmente estará com o nome "Untagged" e clicará em "Add Tag".
Após apertar "Add Tag", aparecerá no Inspector "Tags & Layers", abaixo do Tags você apertará no sinal de
mais (+) e escreverá o nome da Tag (pode ser qualquer um nome, nesse script usei "chao").
Após isso só apertar novamente no objeto e ir até Inspector. No Inspector, aperte onde está escrito Tag e por
último apertar em qual você criou.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulo2 : MonoBehaviour
{
    //Criamos uma variavel bool dizendo quando ele estiver pulando.
    bool isJumping = true;

    void Update()
    {
        //Aqui estamos chamando o método Jumping
        Jumping();
    }

    //Aqui foi criado um método para pular.
    void Jumping()
    {
        //Nesse IF o player vai pular somente se pressionar o botão Espaço e se estiver no chão
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 8), ForceMode2D.Impulse);
            //Quando ele pular vai deixar o boolean isJumping como True para não ficar pulando no ar
            isJumping = true;
        }
    }

    //OnCollisionEnter2D identifica assim que o sprite toca em um collisor
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //CompareTag irá identificar se a tag do objeto que tocou é "chao"
        if(collision.gameObject.CompareTag("chao"))
        {
            //O pulo só vai ser falso quando o player tocar o objeto com a tag "chao"
            isJumping = false;
        }
    }
}
