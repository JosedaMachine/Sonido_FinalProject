using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class underWaterController : MonoBehaviour
{
    public GameObject head;
    public float thresholdDistance;
    [Range(0, -200)]
    public int rangeBlueFilter;

    public PostProcessVolume m_Volume;
    ColorGrading colorGrading_;

    private void Start()
    {
        m_Volume.profile.TryGetSettings<ColorGrading>(out  colorGrading_) ;
        Debug.Log(colorGrading_.mixerRedOutBlueIn.value);
    }

    private void Update()
    {
        if (transform.position.y > head.transform.position.y)
        {
            float dist = Mathf.Abs(transform.position.y - head.transform.position.y);
            dist = Mathf.Clamp(dist / thresholdDistance, 0.0f, 1.0f);
            colorGrading_.mixerRedOutBlueIn.value = dist * rangeBlueFilter;
            //Debug.Log(dist);
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("underWater", dist);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<stepController>() != null)
        {
            this.enabled = true;
            Debug.Log("In water");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<stepController>() != null){

            this.enabled = false;
            Debug.Log("outside");
            FMODUnity.RuntimeManager.StudioSystem.setParameterByName("underWater", 0.0f);
        }
    }
}
