using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playEventOnTrigger : MonoBehaviour
{
    public FMODUnity.StudioEventEmitter emitter;
    private Outline outlineCmp;
    // Start is called before the first frame update
    bool hasBeenPlayed;
    void Start()
    {
        hasBeenPlayed = false;
        outlineCmp = GetComponentInParent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        if (other.GetComponent<FirstPersonController>() != null && !hasBeenPlayed)
        {
            hasBeenPlayed=true;
            if (outlineCmp != null)
                outlineCmp.enabled = true;

            Debug.Log("PLayer");
            emitter.Play();
        }
    }
}
