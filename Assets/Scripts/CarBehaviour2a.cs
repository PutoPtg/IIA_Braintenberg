using UnityEngine;
using System.Collections;

public class CarBehaviour2a : CarBehaviour {
	
	void Update()
	{
		//Read sensor values
		float leftSensor = LeftLD.getLinearOutput ();
		float rightSensor = RightLD.getLinearOutput ();
        float leftSensorWall = leftWallDetector.getLinearOutput();
        float rightSensorWall = rightWallDetector.getLinearOutput();

        //Calculate target motor values
        //Calculate target motor values
        m_LeftWheelSpeed = (leftSensor * MaxSpeed) - (leftSensorWall * MaxSpeed);
        m_RightWheelSpeed = (rightSensor * MaxSpeed) - (rightSensorWall * MaxSpeed);
    }
}
