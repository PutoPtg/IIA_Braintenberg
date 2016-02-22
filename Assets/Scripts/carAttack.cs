using UnityEngine;
using System.Collections;

public class carAttack : CarBehaviour
{

    void Update()
    {
        //Read sensor values
        float leftSensor = LeftLD.getLinearOutput();
        float rightSensor = RightLD.getLinearOutput();

        //Calculate target motor values
        m_RightWheelSpeed = leftSensor * MaxSpeed;
        m_LeftWheelSpeed = rightSensor * MaxSpeed;
    }
}
