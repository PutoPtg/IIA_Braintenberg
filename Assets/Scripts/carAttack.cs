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
        m_RightWheelSpeed = leftRaySensor * leftSensor * MaxSpeed;
        m_LeftWheelSpeed = rightRaySensor * rightSensor * MaxSpeed;
    }
}
