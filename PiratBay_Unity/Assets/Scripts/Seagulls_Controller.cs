using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seagulls_Controller : MonoBehaviour
{

    public FMODUnity.StudioEventEmitter seagullsEmitter;
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){
        seagullsEmitter.EventInstance.setParameterByName("Direction", 180);
    }
}
