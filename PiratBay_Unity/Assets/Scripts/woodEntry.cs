using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class woodEntry : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        stepController steps = other.gameObject.GetComponent<stepController>();

        if (steps != null)
        {
            steps.setSand();
        }
    }
}
