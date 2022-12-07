using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canonController : MonoBehaviour
{
    bool playerClose = false;

    [SerializeField]
    FMODUnity.EventReference canonEventRef;
    private FMOD.Studio.EventInstance canonInstance;

    public GameObject ballPrefab;

    [SerializeField]
    Transform initShotPoint, finalShotPoint;


    public Vector2 ballSpeed;

    private GameObject playerGO;

    private void Start()
    {
        canonInstance = RuntimeManager.CreateInstance(canonEventRef);
    }

    // Update is called once per frame
    void Update()
    {    
        if (playerClose && Input.GetKeyDown(KeyCode.Return))
        {
            canonInstance.start();
            GameObject ball = Instantiate(ballPrefab, initShotPoint.position, Quaternion.identity);
            float time = Random.Range(2.5f, 4.5f);
            var rigidB = ball.GetComponent<Rigidbody>();
            var timer = ball.GetComponent<lifeTime>();

            if(playerGO != null)
            {
                var rigidBPlayer = playerGO.GetComponent<Rigidbody>();

                Vector3 dirVel = (Vector3.Scale(playerGO.transform.position, new Vector3(1, 0, 1)) - Vector3.Scale(this.gameObject.transform.position, new Vector3(1, 0, 1))).normalized;

                rigidBPlayer.AddForce(dirVel * 15, ForceMode.Impulse);

            }

            if(timer != null)
            {
                timer.setLifeTime(time);
            }
            if(rigidB != null)
            {
                float multiplier = Random.Range(ballSpeed.x, ballSpeed.y);

                Vector3 vel = (finalShotPoint.position - initShotPoint.position).normalized;
                rigidB.velocity = vel* multiplier; 
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<FirstPersonController>();
        if (player != null)
        {
            playerGO = other.gameObject;
            playerClose = true;
            GameManager.Instance.toggleCanonText();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var player = other.GetComponent<FirstPersonController>();

        if (player != null)
        {
            playerClose = false;
            GameManager.Instance.toggleCanonText();
        }
    }
}
