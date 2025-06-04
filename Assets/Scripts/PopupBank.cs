using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupBank : MonoBehaviour
{
    public Button InputBtn;
    public Button OutputBtn;
    public Button InputBackBtn;
    public Button OutputBackBtn;
    public GameObject InputUI;
    public GameObject OutputUI;
    public GameObject ATMUI;

   public void OnInput()
    {

        InputUI.SetActive(true);
        OutputUI.SetActive(false);
        ATMUI.SetActive(false);
    }

    public void OnOutput() 
    { 
        OutputUI.SetActive(true);
        InputUI.SetActive(false);
        ATMUI.SetActive(false);
    
    }
    
    public void GoBack()
    {

        InputUI.SetActive(false);
        OutputUI.SetActive(false);
        ATMUI.SetActive(true);
    }



}
