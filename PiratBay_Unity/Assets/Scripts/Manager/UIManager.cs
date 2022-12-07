using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager theUIManager;

    [SerializeField]
    private TMPro.TMP_Text parrotText;

    [SerializeField]
    private TMPro.TMP_Text canonText;
    private void Awake(){

    }

    private void Start()
    {
        GameManager.Instance.SetUIManager(this);
    }

    public void toggleParrotText(){
        parrotText.enabled = !parrotText.enabled;
    }

    public void toggleCanonText()
    {
        canonText.enabled = !canonText.enabled;
    }

}
