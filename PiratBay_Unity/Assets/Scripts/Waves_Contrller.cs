using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves_Contrller : MonoBehaviour
{
    public GameObject[] waves_Sources;

    FMODUnity.StudioEventEmitter waves;

    private void Start()
    {
        waves = GetComponent<FMODUnity.StudioEventEmitter>();
    }

    // Update is called once per frame
    void Update()
    {
        float min = (waves_Sources[0].transform.position - transform.position).magnitude;

        for (int i = 1; i < waves_Sources.Length; i++)
        {
            float dist = (waves_Sources[i].transform.position - transform.position).magnitude;
  
            if(dist < min)
            {
                min = dist;
            }
        }

        float distValue = 1 / min;

         float modificator = Mathf.Clamp(distValue, 0, 1);

        Debug.Log(modificator);


       waves.EventInstance.setParameterByName("Distancia", modificator);
    }
}
