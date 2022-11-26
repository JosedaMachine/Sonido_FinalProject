using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stepController : MonoBehaviour
{
    FMODUnity.StudioEventEmitter stepEmitter;
    bool onSand = true;

    private void Start()
    {
        stepEmitter = GetComponent <FMODUnity.StudioEventEmitter>();

    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            stepEmitter.EventInstance.setParameterByName("Moving", 1);

        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            stepEmitter.EventInstance.setParameterByName("Moving", 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            stepEmitter.EventInstance.setParameterByName("Run", 1);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            stepEmitter.EventInstance.setParameterByName("Run", 0);
        }
    }

    public void setSand()
    {
        onSand = !onSand;

        if (onSand) stepEmitter.EventInstance.setParameterByName("Sand", 1);
        else stepEmitter.EventInstance.setParameterByName("Sand", 0);
    }
}
