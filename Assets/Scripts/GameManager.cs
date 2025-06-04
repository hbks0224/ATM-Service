using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.RestService;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public UserData userData;

    public TextMeshProUGUI NameText;
    public TextMeshProUGUI BalanceText;
    public TextMeshProUGUI CashText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {

            Destroy(gameObject);
        }
    }
    private void Start()
    {
        //userData = new UserData("HyeokJun", 8500000, 115000);
        LoadUserData();
        Refresh();

    }
    public void Refresh() 
    
    {
        NameText.text = userData.Username;
        BalanceText.text = $"Balance {userData.AccountBalance.ToString("#,##0")}";
        CashText.text = userData.Cash.ToString("#,##0");
    
    
    }

    public void SaveUserData() //데이터 저장
    {

        PlayerPrefs.SetString("UserName", userData.Username);
        PlayerPrefs.SetInt("Cash",userData.Cash);
        PlayerPrefs.SetInt("Balance", userData.AccountBalance);
    }

    public void LoadUserData()
    {
        userData.Username = PlayerPrefs.GetString("UserName", userData.Username);
        userData.Cash = PlayerPrefs.GetInt("Cash",userData.Cash);
        userData.AccountBalance = PlayerPrefs.GetInt("Balance", userData.AccountBalance);

    }



}
