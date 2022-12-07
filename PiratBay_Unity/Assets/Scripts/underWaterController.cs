using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class underWaterController : MonoBehaviour
{
    public GameObject head;

    private void Update()
    {

        if (transform.position.y > head.transform.position.y)
        {
            float dist = transform.position.y - head.transform.position.y;
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("underWater", dist);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<stepController>() != null) FMODUnity.RuntimeManager.StudioSystem.setParameterByName("underWater", 0.0f);
    }
}
