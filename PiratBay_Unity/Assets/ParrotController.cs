using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParrotController : MonoBehaviour
{
    // Start is called before the first frame update
    ParrotVoice parrotV;
    
    void Start() {
        parrotV = GetComponent<ParrotVoice>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other){
        var player = other.GetComponent<FirstPersonController>();

        if(player != null){
            Debug.Log("Is Player");
            parrotV.tooglePlay();
            GameManager.Instance.toggleParrotText();
        }
    }

    private void OnTriggerExit(Collider other){
        var player = other.GetComponent<FirstPersonController>();

        if (player != null){
            Debug.Log("Is Player");
            parrotV.tooglePlay();
            GameManager.Instance.toggleParrotText();
        }
    }
}
