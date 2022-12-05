using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager theUIManager;

    [SerializeField]
    private TMPro.TMP_Text parrotText;
    private void Awake(){

    }

    private void Start()
    {
        GameManager.Instance.SetUIManager(this);
    }

    public void toggleParrotText(){
        parrotText.enabled = !parrotText.enabled;
    }

}
