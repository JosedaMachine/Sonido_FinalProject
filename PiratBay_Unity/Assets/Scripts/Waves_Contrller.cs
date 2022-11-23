using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves_Contrller : MonoBehaviour
{
    public GameObject[] waves_Sources;

    public GameObject oceanEmitter;

    FMODUnity.StudioEventEmitter waves;

    private void Start()
    {
        waves = GetComponent<FMODUnity.StudioEventEmitter>();
    }


    private Vector3 getMinDistance(){
        Vector3 minDistancePoint = Vector3.zero;
        //Punto actual del jugador
        Vector3 P = transform.position;
        //Vamos por pares de vertices

        float minDis = Mathf.Infinity;
        for (int i = 0; i < waves_Sources.Length - 1; i++){
            //Definimos la recta
            Vector3 A = waves_Sources[i].transform.position;
            Vector3 B = waves_Sources[i + 1].transform.position;
            Vector3 aux;

            if (Vector3.Dot(A - B, P - A) > 0) aux = A;
            else if (Vector3.Dot(B - A, P - B) > 0) aux = B;
            else aux = A + Vector3.Project(P - A, B - A);

            float distance = (P - aux).magnitude;
            if(distance < minDis)
            {
                minDis = distance;
                minDistancePoint = aux;
            }
        }

        Debug.Log(P);
        Debug.Log("Distance: " + minDis);
        Debug.Log(minDistancePoint);

        return minDistancePoint;
    }


    // Update is called once per frame
    void Update(){
        // float min = (waves_Sources[0].transform.position - transform.position).magnitude;

        // for (int i = 1; i < waves_Sources.Length; i++)
        // {
        //     float dist = (waves_Sources[i].transform.position - transform.position).magnitude;

        //     if(dist < min)
        //     {
        //         min = dist;
        //     }
        // }

        // float distValue = 1 / min;

        //  float modificator = Mathf.Clamp(distValue, 0, 1);

        // Debug.Log(modificator);


        //waves.EventInstance.setParameterByName("Distancia", modificator);

        var newPos = getMinDistance();
        oceanEmitter.transform.position = Vector3.Lerp(oceanEmitter.transform.position, newPos, (oceanEmitter.transform.position - newPos).magnitude/ 600.0f);

    }
}
