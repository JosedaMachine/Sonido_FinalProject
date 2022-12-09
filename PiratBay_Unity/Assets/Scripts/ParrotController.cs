using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParrotController : MonoBehaviour
{
    // Start is called before the first frame update
    ParrotVoice parrotV;

    [SerializeField]
    FMODUnity.EventReference frenchEventRef;
    private Outline outlineCmp;
    private FMOD.Studio.EventInstance frenchInstance;
    void Start() {
        parrotV = GetComponent<ParrotVoice>();
        frenchInstance = RuntimeManager.CreateInstance(frenchEventRef);
        outlineCmp = GetComponentInParent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        var player = other.GetComponent<FirstPersonController>();

        if(player != null){

            if (outlineCmp != null && !outlineCmp.enabled)
                outlineCmp.enabled = true;

            parrotV.tooglePlay();
            frenchInstance.start();
            GameManager.Instance.toggleParrotText();
        }
    }

    private void OnTriggerExit(Collider other){
        var player = other.GetComponent<FirstPersonController>();

        if (player != null){
            parrotV.tooglePlay();
            GameManager.Instance.toggleParrotText();
        }
    }
}
