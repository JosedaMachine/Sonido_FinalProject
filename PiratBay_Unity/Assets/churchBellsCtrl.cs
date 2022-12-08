using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class churchBellsCtrl : MonoBehaviour
{
    public float secondsIntervalToSound;

    [Range(0f, 1f)]
    public float probabilityEachSecond;
    float timer;
    bool hasBeenPlayed, startTimer;
    int lastSecond;
    public int numSamples;
    FMODUnity.StudioEventEmitter bellsEvents;
    // Start is called before the first frame update
    void Start()
    {
        bellsEvents = GetComponentInParent<FMODUnity.StudioEventEmitter>();
        timer = 0;
        hasBeenPlayed = startTimer = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer)
        {
            if (timer > 0)
            {
                if ((int)timer != lastSecond)
                {
                    lastSecond = (int)timer;
                    int proba_ = Random.Range(0, numSamples);
                    if (proba_ <= numSamples * probabilityEachSecond)
                    {
                        bellsEvents.Play();
                        hasBeenPlayed = true;
                        startTimer = false;
                        //Debug.Log("bingo random");
                    }
                }

                timer -= Time.deltaTime;
            }
            else
            {
                if (!hasBeenPlayed)
                {
                    bellsEvents.Play();
                    hasBeenPlayed = true;
                    startTimer = false; 
                    //Debug.Log("bingo final");
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FirstPersonController>() && !hasBeenPlayed){
            timer = secondsIntervalToSound;
            startTimer = true;
            lastSecond = (int)timer;
        }
    }

}
