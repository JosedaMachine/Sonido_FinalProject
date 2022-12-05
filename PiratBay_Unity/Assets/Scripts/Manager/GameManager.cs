using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    
    public static GameManager Instance
    {
        get {
            if (instance == null)
                Debug.LogError("No GameManager!");
            return instance; 
        }
    }

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Debug.Log("Initialized GM");
            DontDestroyOnLoad(this);
        }
        else
            Destroy(gameObject);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUIManager(UIManager ui)
    {
        UIManager.theUIManager = ui;
    } 


    public void toggleParrotText()
    {
        UIManager.theUIManager.toggleParrotText();
    }
}
