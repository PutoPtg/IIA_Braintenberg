using UnityEngine;
using System.Collections;

public class carAttack : CarBehaviour
{

    void Update()
    {
        //Read sensor values
        float leftSensor = LeftLD.getLinearOutput ();
        float rightSensor = RightLD.getLinearOutput ();
        float leftSensorWall = leftWallDetector.getLinearOutput();
        float rightSensorWall = rightWallDetector.getLinearOutput();

        //Calculate target motor values
        m_RightWheelSpeed = (leftSensor * MaxSpeed) - (leftSensorWall * MaxSpeed);
        m_LeftWheelSpeed = (rightSensor * MaxSpeed) - (rightSensorWall * MaxSpeed);
    }
}
