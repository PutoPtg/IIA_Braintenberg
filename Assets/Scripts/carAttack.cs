using UnityEngine;
using System.Collections;

public class carAttack : CarBehaviour
{

    void Update()
    {
        //Read sensor values
        //sensores de luz
        float leftSensor = LeftLD.getLinearOutput();
        float rightSensor = RightLD.getLinearOutput();
        //sensores de proximidade
        float leftRaySensor = RRcast.getDistancia();
        float rightRaySensor = RRcast.getDistancia();

        //Calculate target motor values
        //usa a fórmula de relé (a+b-a*b)
        //quando não detecta nada na proximidade são os sensores de luz que controlam as rodas, estando o da direita ligado ao esquerdo e vice-versa.
        //quando detecta algo na frente ignora os imputs das luzes e gira as rodas em setidos opostos (com velocidade dependente da distância ao objecto) e vira-o para a dirita
        //até não ter nada nos sensores, passando as luzes novamente a controlar as rodas.
        m_LeftWheelSpeed = (leftRaySensor + rightSensor - leftRaySensor * rightSensor) * MaxSpeed;
        m_RightWheelSpeed = (-rightRaySensor + leftSensor - -(rightRaySensor) * leftSensor) * MaxSpeed;
    }
}
