using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canonController : MonoBehaviour
{
    bool playerClose = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {                       //C de canon
        if (playerClose && Input.GetKeyDown(KeyCode.C))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/canon");
            Debug.Log("Hola");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FirstPersonController>() != null) playerClose = true;

        Debug.Log("Hola");
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<FirstPersonController>() != null) playerClose = false;
    }
}
