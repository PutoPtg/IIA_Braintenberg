using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour
{

    public float sensibilidade;
    public float distancia;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 front = transform.TransformDirection(0, 0, 1);
        Ray wallRay = new Ray(transform.position, front);
        Debug.DrawRay(transform.position, front * sensibilidade);
        if (Physics.Raycast(wallRay, out hit, sensibilidade))
        {
            if (hit.collider.tag == "wall")
            {
                distancia = (hit.distance - 0) / (sensibilidade - 0);
            }
            else
            {
                distancia = 1;
            }
        }
    }
    // Get Sensor output value
    public float getDistancia()
    {

        return distancia;
    }
}
