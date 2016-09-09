using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerData : MonoBehaviour
{
    public static float fMoney = 0;

    public static int iTagCount = 0;
    public static string[] strTag = new string[50];
    // ------------------------------------------------------------------
    void Start()
    {
        // 取得Tag總數.
        //iTagCount = PlayerPrefs.GetInt("iTagCount", 0);
        // 取得Tag名稱.
    }
    // ------------------------------------------------------------------
    public static float GetMoney()
    {
        return fMoney;
    }
    // ------------------------------------------------------------------
    public static bool AddMoney(float fValue)
    {
        fMoney = fMoney + fValue;
        return true;
    }
    // ------------------------------------------------------------------
    public static bool AddTag(string sValue)
    {
        strTag[iTagCount] = sValue;
        iTagCount++;
        //PlayerPrefs.SetString(, );
        return true;
    }
}
