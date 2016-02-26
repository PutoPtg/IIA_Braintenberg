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
        m_LeftWheelSpeed = (leftRaySensor + leftSensor - leftRaySensor * leftSensor) * MaxSpeed;
		m_RightWheelSpeed = (-rightRaySensor + rightSensor - -(rightRaySensor) * rightSensor) * MaxSpeed;
        //((leftRaySensor + leftSensor)/2)
        // a+b-a*b
    }
}
