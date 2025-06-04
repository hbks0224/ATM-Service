using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UserData
{

   public string Username ; //사용자명
   public int Cash; //현금
   public int AccountBalance; // 통장 잔고

    public UserData(string username, int cash, int accountBalance)
    {
        Username = username;
        Cash = cash;
        AccountBalance = accountBalance;


    }

}
