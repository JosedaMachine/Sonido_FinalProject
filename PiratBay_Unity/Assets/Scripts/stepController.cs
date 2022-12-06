using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using FMODUnity;

enum Terrain{
    Sand, Wood, Water
}

enum MovingType{
    Walking, Running
}

public class stepController : MonoBehaviour
{
    [SerializeField]
    FMODUnity.EventReference stepEventRef;
    private FMOD.Studio.EventInstance stepInstance;
    private FMOD.Studio.PARAMETER_ID Terrain_ID;
    private FMOD.Studio.PARAMETER_ID MovingType_ID;

    bool onSand = true;
    bool playing;
    private void Start()
    {
        playing = false;

        stepInstance = RuntimeManager.CreateInstance(stepEventRef);

        //stepInstance = stepEmitter.EventInstance;
        FMOD.Studio.EventDescription stepEventDescription;
        stepInstance.getDescription(out stepEventDescription);


        FMOD.Studio.PARAMETER_DESCRIPTION _TerrainParameterDesc;
        stepEventDescription.getParameterDescriptionByName("Terrain", out _TerrainParameterDesc);
        Terrain_ID = _TerrainParameterDesc.id;
        
        FMOD.Studio.PARAMETER_DESCRIPTION _MovingTypeDesc;
        stepEventDescription.getParameterDescriptionByName("MovingType", out _MovingTypeDesc);
        MovingType_ID = _MovingTypeDesc.id;

        //stepInstance.start();
        stepInstance.setParameterByID(MovingType_ID, (float)MovingType.Walking);
        stepInstance.setParameterByID(Terrain_ID, (float)Terrain.Sand);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/hipo");

        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)){
            if (!playing)
            {
                stepInstance.start();
                playing = true;
                Debug.Log("Play");
            }
        }
        else{
            if (playing){
                stepInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
                playing = false;
            }
        }

        //if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        //{
        //    stepEmitter.EventInstance.setParameterByName("Moving", 0);
        //}

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            stepInstance.setParameterByID(MovingType_ID, (float)MovingType.Running);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift)){
            stepInstance.setParameterByID(MovingType_ID, (float)MovingType.Walking);
        }
    }

    public void setSand()
    {
        onSand = !onSand;

        //if (onSand) stepEmitter.EventInstance.setParameterByName("Sand", 1);
        //else stepEmitter.EventInstance.setParameterByName("Sand", 0);
    }

    private void OnDestroy()
    {
        stepInstance.release();
    }

    private void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Port"){
            float _terrain;
            stepInstance.getParameterByID(Terrain_ID, out _terrain);

            if((Terrain)((int)_terrain) == Terrain.Sand)
                stepInstance.setParameterByID(Terrain_ID, (float)Terrain.Wood);

            if ((Terrain)((int)_terrain) == Terrain.Wood)
                stepInstance.setParameterByID(Terrain_ID, (float)Terrain.Sand);
        }

        if (other.gameObject.tag == "Water")
        {
            float _terrain;
            stepInstance.getParameterByID(Terrain_ID, out _terrain);

            if ((Terrain)((int)_terrain) == Terrain.Sand)
                stepInstance.setParameterByID(Terrain_ID, (float)Terrain.Water);

            if ((Terrain)((int)_terrain) == Terrain.Water)
                stepInstance.setParameterByID(Terrain_ID, (float)Terrain.Sand);
        }
    }
}
