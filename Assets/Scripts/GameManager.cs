using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
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
        userData = new UserData("HyeokJun", 85000, 115000);
        Refresh();

    }
    public void Refresh() 
    
    {
        NameText.text = userData.Username;
        BalanceText.text = userData.AccountBalance.ToString("#,##0");
        CashText.text = userData.Cash.ToString("#,##0");
    
    
    }

}
