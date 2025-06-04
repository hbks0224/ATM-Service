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
    public GameObject SignUpPopup; // 로그인 팝업
    public GameObject UserInfoUI;
    public TMP_InputField SingupID;
    public TMP_InputField SingupName;
    public TMP_InputField SingupPS;
    public TMP_InputField SingupConfim;
    public GameObject CheckInfoPopup;
    public TextMeshProUGUI ErrorMassage;
    public UserData userData;


    public TMP_InputField IdBox;
    public TMP_InputField PSBox;
    private void Start()
    {
        LoginUI.SetActive(true);
        ATMUI.SetActive(false);
        InputUI.SetActive(false);
        OutputUI.SetActive(false);
        Popup.SetActive(false);
        SignUpPopup.SetActive(false);
        CheckInfoPopup.SetActive(false);
        UserInfoUI.SetActive(false);
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
        if (int.TryParse(OutputField.text, out amount))
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
    
    public void OnSignUpPopUp()
    {

        SignUpPopup.SetActive(true);
    }
    public void SignUpCancel()
    {

        SignUpPopup.SetActive(false );
    }
    public void MakeAccount()
    {
        if (SingupID.text == "" || SingupName.text == "" || SingupPS.text == ""|| SingupConfim.text =="")
        {
            CheckInfoPopup.SetActive(true);
            ErrorMassage.text = "다음 사항이 빠져있습니다 : ";
            if(SingupID.text == "")
            {

                ErrorMassage.text += "ID ";
            }

            if(SingupName.text == "")
            {

                ErrorMassage.text += "이름 ";

            }

            if(SingupPS.text == "")
            {

                ErrorMassage.text += "비밀번호 ";
            }

            if(SingupConfim.text == "")
            {

                ErrorMassage.text += "비밀번호 확인 ";
            }

            

            
        }



        else
        {
            if(SingupPS.text == SingupConfim.text)
            {

                if (PlayerPrefs.HasKey($"{SingupID.text}"))
                {
                    ErrorMassage.text = "이미 존재하는 ID입니다.";
                    CheckInfoPopup.SetActive(true);

                }
                else
                {
                    ErrorMassage.text = "";
                    PlayerPrefs.SetString($"{SingupID.text}/UserName", SingupName.text);
                    PlayerPrefs.SetString($"{SingupID.text}", SingupID.text);
                    PlayerPrefs.SetString($"{SingupID.text}/Password", SingupPS.text);
                    PlayerPrefs.SetInt($"{SingupID.text}/Cash", 1000000);
                    PlayerPrefs.SetInt($"{SingupID.text}/Balance", 1000000);


                    GameManager.Instance.SaveUserData();


                    ErrorMassage.text = "회원가입 성공!";

                }


                
            }
            else
            {

                ErrorMassage.text = "비밀번호가 틀립니다.";
            }
        }
        




    }

    public void OffCheckInfoPopUp()
    {
        CheckInfoPopup.SetActive(false ) ; 

    }
    
    public void Login()
    {
        Debug.Log(PlayerPrefs.GetString($"{IdBox.text}"));
        Debug.Log( PlayerPrefs.GetString($"{IdBox.text}/Password"));
        if(IdBox.text == PlayerPrefs.GetString($"{IdBox.text}") && PSBox.text == PlayerPrefs.GetString($"{IdBox.text}/Password"))
        {
            userData.Username = PlayerPrefs.GetString($"{IdBox.text}/UserName", userData.Username);
            userData.Cash = PlayerPrefs.GetInt($"{IdBox.text}/Cash", userData.Cash);
            userData.AccountBalance = PlayerPrefs.GetInt($"{IdBox.text}/Balance", userData.AccountBalance);
            userData.Password = PlayerPrefs.GetString($"{IdBox.text}/Password", userData.Password);
            userData.ID = PlayerPrefs.GetString($"{IdBox.text}", userData.ID);

            LoginUI.SetActive(false );
            ATMUI.SetActive(true); 
            UserInfoUI.SetActive(true);
            GameManager.Instance.LoadUserData(IdBox.text);
            GameManager.Instance.Refresh();

        }
    }
}
