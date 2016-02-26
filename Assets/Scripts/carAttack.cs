using UnityEngine;
using System.Collections;

public class carAttack : CarBehaviour
{

    void Update()
    {
        //Read sensor values
        float leftSensor = LeftLD.getLinearOutput();
        float rightSensor = RightLD.getLinearOutput();
        float leftRaySensor = RRcast.getDistancia();
        float rightRaySensor = RRcast.getDistancia();

        //Calculate target motor values
        m_LeftWheelSpeed = (leftRaySensor + rightSensor - leftRaySensor * rightSensor) * MaxSpeed;
        m_RightWheelSpeed = (-rightRaySensor + leftSensor - -(rightRaySensor) * leftSensor) * MaxSpeed;
    }
}
