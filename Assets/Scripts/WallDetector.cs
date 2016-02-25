using UnityEngine;
using System.Collections;
using System;

public class WallDetector : MonoBehaviour {

    public float angle;

    public float output;
    public int numObjects;

    void Start()
    {
        output = 0;
        numObjects = 0;
    }

    void Update()
    {
        GameObject[] walls = GetVisibleWalls();
        
        Vector3 temp;
        float dist = 0;

        output = 0;
        numObjects = walls.Length;

        if(walls.Length != 0)
        {
            temp = walls[0].transform.position;
            dist = 1f / ((transform.position - walls[0].transform.position).magnitude + 1);
            output = dist;
        }
       

        foreach (GameObject wall in walls)
        {
            // achar wall mais proxima
            if(dist < (1f / ((transform.position - wall.transform.position).magnitude + 1)))
            {
                output = 1f / ((transform.position - wall.transform.position).magnitude + 1);
            }
        }

        if (numObjects > 0)
            output = output / numObjects;
    }

    // Get Sensor output value
    public float getLinearOutput()
    {

        return output;
    }

    // Returns all "Light" tagged objects. The sensor angle is not taken into account.
    GameObject[] GetAllWalls()
    {
        return GameObject.FindGameObjectsWithTag("Pilar");
    }

    // Returns all "Light" tagged objects that are within the view angle of the Sensor. Only considers the angle over 
    // the y axis. Does not consider objects blocking the view.
    GameObject[] GetVisibleWalls()
    {
        ArrayList visibleWalls = new ArrayList();
        float halfAngle = angle / 2.0f;

        GameObject[] walls = GameObject.FindGameObjectsWithTag("Pilar");

        foreach (GameObject wall in walls)
        {
            Vector3 toVector = (wall.transform.position - transform.position);
            Vector3 forward = transform.forward;
            toVector.y = 0;
            forward.y = 0;
            float angleToTarget = Vector3.Angle(forward, toVector);

            if (angleToTarget <= halfAngle)
            {
                visibleWalls.Add(wall);
            }
        }

        return (GameObject[])visibleWalls.ToArray(typeof(GameObject));
    }
}
