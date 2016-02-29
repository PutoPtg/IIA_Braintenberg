using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour
{

    public float sensibilidade;
    public float distancia;

    // Update is called once per frame
    void Update()
    {
        distancia = 0;
        RaycastHit hit; //vairável que indica se o raio bateu em algm objecto ou não
        Vector3 front = transform.TransformDirection(0, 0, 1); //transformada de direcção que mantém o raio sempre para a frente do carro mesmo quando este vira
        Ray wallRay = new Ray(transform.position, front);
        Debug.DrawRay(transform.position, front * sensibilidade); //debug que desenha as linas do raio
        //projecta um raio para a frente e detecta a proximidade do objencto defronte
        if (Physics.Raycast(wallRay, out hit, sensibilidade))
        {
            if (hit.collider.tag == "wall")
            {
                //se o raio colidir calcula a distância normalizada de 0 a 1
                distancia = (hit.distance - 0) / (sensibilidade - 0);
                //distancia = 1;
            }
            else
            {
                //caso não haja nada à frente faz reset à variável
                distancia = 0;
            }
        }
    }
    // Get Sensor output value
    public float getDistancia()
    {

        return distancia;
    }
}
