using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeTime : MonoBehaviour
{
    // Start is called before the first frame update
    private float lifeTime_;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lifeTime_ > 0)
        {
            lifeTime_ -= Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void setLifeTime(float live)
    {
        lifeTime_ = live;
    }
}
