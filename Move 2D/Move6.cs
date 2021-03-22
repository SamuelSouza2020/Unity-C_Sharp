/*
Com joystick é um pouco semelhante ao Mouse. Mas nele voce terá que seguir alguns passos.
Dentro da engine Unity, entre em Edit>Project Settings>Input Manager
Em Input Manager você irá até um Submit, após apertar nele o primeiro campo dele é Name, você mudará o nome para Direcional (Pode ser outro).
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move1 : MonoBehaviour
{
    public float vel = 3;

    void Update()
    {
        /*
        Coloque o mesmo nome que você alterou no Submit dentro do GetAxis
        Dentro do Input Manager>Direcional você limpará os campo Alt, positive e negative button
        Colocará o Type como Joystick Axis e pesquisará o mapa do controle que vai utilizar como joystick
        Na opção Axi que fica abaixo do Type você coloca o nome do botão mostrado no mapa
        Nesse exemplo irei demonstrar o Horizontal do controle "X axis" ou "6th axis"
        */
        float H = Input.GetAxis("Direcional");

        transform.Translate(new Vector2(H * Time.deltaTime * vel, 0));
    }
}
