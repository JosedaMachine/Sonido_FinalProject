using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves_Contrller : MonoBehaviour
{
    public GameObject[] waves_Sources;
    public GameObject[] town_points;

    public GameObject oceanEmitter;

    FMODUnity.StudioEventEmitter waves;
    private FMOD.Studio.EventInstance wavesInstance;
    private FMOD.Studio.PARAMETER_ID _2D_ID;


    float maxDistanceAttenuation;

    private void Start() {
        waves = oceanEmitter.GetComponent<FMODUnity.StudioEventEmitter>();

        wavesInstance = waves.EventInstance;

        maxDistanceAttenuation = waves.OverrideMaxDistance;

        FMOD.Studio.EventDescription _2DEventDescription;
        wavesInstance.getDescription(out _2DEventDescription);

        FMOD.Studio.PARAMETER_DESCRIPTION _2DParameterDesc;

        _2DEventDescription.getParameterDescriptionByName("2D", out _2DParameterDesc);

        _2D_ID = _2DParameterDesc.id;

        oceanEmitter.transform.position = getMinDistanceRect();
    }


    private Vector3 getMinDistanceRect(){
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

        //Debug.Log(P);
        //Debug.Log("Distance: " + minDis);
        //Debug.Log(minDistancePoint);

        return minDistancePoint;
    }

    private GameObject nearestObject(GameObject[] objecs){
        GameObject nearestObject = null;

        Vector3 P = oceanEmitter.transform.position;

        float minDis = Mathf.Infinity;
        for (int i = 0; i < objecs.Length; i++)
        {
            Vector3 point = objecs[i].transform.position;
                
            float distance = (P - point).magnitude;
            if (distance < minDis){
                minDis = distance;
                nearestObject = objecs[i];
            }
        }

        return nearestObject;
    }

    void changeDimensionSound(){
        var nearestTownPoint = nearestObject(town_points);
        Debug.Log(nearestTownPoint.name);

        Vector3 Player = transform.position;
        Vector3 nearestTownPointPos = nearestTownPoint.transform.position;
        Vector3 oceanEmitterPos = oceanEmitter.transform.position;

        //Si la pos del jugador está mas alla al borde de donde suena el oceano, el sonido sera total 2D. Esta inmerso.
        //De lo contrario será posicional
        if ((Player - nearestTownPointPos).magnitude > (oceanEmitterPos - nearestTownPointPos).magnitude)
            wavesInstance.setParameterByID(_2D_ID, 1.0f);
        else
        {
            //Hacemos un calculo de distancia con la atenuacion para conforme más cerca mas sea 2D.
            float factorAtte = (Player - oceanEmitterPos).magnitude / (maxDistanceAttenuation*0.57f);
            float value = Mathf.Clamp(1 - factorAtte, 0.0f, 1.0f);
            wavesInstance.setParameterByID(_2D_ID, value);
        }

        float _2D;
        wavesInstance.getParameterByID(_2D_ID, out _2D);
        Debug.Log("Ocean 2D:" +  _2D);

    }

    // Update is called once per frame
    void Update() {
        changeDimensionSound();
        
        //Movemos constantemente la posicion de la fuente de sonido del mar, para que siempre suene al lado del jugador
        var newPos = getMinDistanceRect();
        oceanEmitter.transform.position = Vector3.Lerp(oceanEmitter.transform.position, newPos, (oceanEmitter.transform.position - newPos).magnitude/ 60.0f);
    }
}
