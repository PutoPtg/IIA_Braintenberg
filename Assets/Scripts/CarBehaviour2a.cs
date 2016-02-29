using UnityEngine;
using System.Collections;
using System;

public class CarBehaviour2a : CarBehaviour {

    void Update()
	{
		//Read sensor values
		float leftSensor = LeftLD.getLinearOutput ();
		float rightSensor = RightLD.getLinearOutput ();
        float leftRaySensor = RRcast.getDistancia();
        float rightRaySensor = RRcast.getDistancia();

        //Calculate target motor values
        //usa a fórmula de relé (a+b-a*b)
        //quando não detecta nada na proximidade são os sensores de luz que controlam as rodas.
        //quando detecta algo na frente ignora os imputs das luzes e gira as rodas em setidos opostos (com velocidade dependente da distância ao objecto) e vira-o para a dirita
        //até não ter nada nos sensores, passando as luzes novamente a controlar as rodas.
        m_LeftWheelSpeed = (((leftRaySensor + rightRaySensor)/2) + leftSensor - ((leftRaySensor + rightRaySensor) / 2) * leftSensor) * MaxSpeed;
		m_RightWheelSpeed = (-((leftRaySensor + rightRaySensor) / 2) + rightSensor - -((leftRaySensor + rightRaySensor) / 2) * rightSensor) * MaxSpeed;
        //((leftRaySensor + leftSensor)/2)
        // a+b-a*b
    }
}
