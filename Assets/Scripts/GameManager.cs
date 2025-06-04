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

        PlayerPrefs.SetString($"{userData.ID}/UserName", userData.Username);
        PlayerPrefs.SetInt($"{userData.ID}/Cash",userData.Cash);
        PlayerPrefs.SetInt($"{userData.ID}/Balance", userData.AccountBalance);
        PlayerPrefs.SetString($"{userData.ID}",userData.ID);
        PlayerPrefs.SetString($"{userData.ID}/Password",userData.Password);
    }

    public void LoadUserData(string id)
    {
        userData.Username = PlayerPrefs.GetString($"{id}/UserName", userData.Username);
        userData.Cash = PlayerPrefs.GetInt($"{id}/Cash",userData.Cash);
        userData.AccountBalance = PlayerPrefs.GetInt($"{id}/Balance", userData.AccountBalance);
        userData.Password = PlayerPrefs.GetString($"{id}/Password", userData.Password);
        userData.ID = PlayerPrefs.GetString ($"{id}", userData.ID);

    }



}
