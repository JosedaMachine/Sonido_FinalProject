using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canonController : MonoBehaviour
{
    bool playerClose = false;

    // Update is called once per frame
    void Update()
    {                       //C de canon
        if (playerClose && Input.GetKeyDown(KeyCode.C))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/canon");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FirstPersonController>() != null) playerClose = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<FirstPersonController>() != null) playerClose = false;
    }
}
