using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class PopupBank : MonoBehaviour
{

    public GameObject InputUI;//입금 UI
    public GameObject OutputUI;//출금 UI
    public GameObject ATMUI; //메인 UI
    public TMP_InputField InputField; // 직접입력 field
    public TMP_InputField OutputField; // 직접입력 field
    public GameObject Popup;
    public GameObject LoginUI; //로그인 UI




    private void Start()
    {
        LoginUI.SetActive(true);
        ATMUI.SetActive(false);
        InputUI.SetActive(false);
        OutputUI.SetActive(false);
        Popup.SetActive(false);
    }

    public void OnInput() // 입금 버튼 액션
    {

        InputUI.SetActive(true);
        OutputUI.SetActive(false);
        ATMUI.SetActive(false);
    }

    public void OnOutput() // 출금 버튼 액션
    { 
        OutputUI.SetActive(true);
        InputUI.SetActive(false);
        ATMUI.SetActive(false);
    
    }
    
    public void GoBack() // 뒤로가기 버튼 액션
    {

        InputUI.SetActive(false);
        OutputUI.SetActive(false);
        ATMUI.SetActive(true);
    }


    public void Input(int input)
    {

        if(GameManager.Instance.userData.Cash - input < 0)
        {
            OnPopup();
            return;
        }
        GameManager.Instance.userData.AccountBalance += input;
        GameManager.Instance.userData.Cash -= input;
        GameManager.Instance.SaveUserData();
        GameManager.Instance.Refresh();

        

    }
    public void InputCustom()
    {
        int amount;
        if(int.TryParse(InputField.text, out amount))
        {

            if (GameManager.Instance.userData.Cash - amount < 0)
            {
                OnPopup();
                return;
            }
            GameManager.Instance.userData.AccountBalance += amount;
            GameManager.Instance.userData.Cash -= amount;
            GameManager.Instance.SaveUserData();
            GameManager.Instance.Refresh();
        }


    }
    public void Output(int output)
    {
        if (GameManager.Instance.userData.AccountBalance - output < 0)
        {
            OnPopup();
            return;
        }
        GameManager.Instance.userData.AccountBalance -= output;
        GameManager.Instance.userData.Cash += output;
        GameManager.Instance.SaveUserData();
        GameManager.Instance.Refresh();

    }

    public void OutputCustom()
    {

        int amount;
        if (int.TryParse(InputField.text, out amount))
        {
            if (GameManager.Instance.userData.AccountBalance - amount < 0)
            {
                OnPopup();
                return;
            }

            GameManager.Instance.userData.AccountBalance -= amount;
            GameManager.Instance.userData.Cash += amount;
            GameManager.Instance.SaveUserData();
            GameManager.Instance.Refresh();
        }


    }
    public void OnPopup()
    {
        Popup.SetActive(true);

    }

    public void OffPopUP()
    {

        Popup.SetActive(false);
    }

}
