using UnityEngine;
using System.Collections;
using System.Globalization;

public class P_Calculator : MonoBehaviour
{
    static public P_Calculator pthis = null;

    public UILabel Lb_Title = null;
    public UILabel Lb_TotalNum = null;
    public UILabel Lb_OK = null;

    public double dTotal = 0;

    public float[] registers = new float[2];//2 registers
    public string currentNum = "0";
    public string currentOperationToPerform = "";
    public bool isFirst = true;
    public bool shouldClearScreen = false;

    bool bIsOKBtn = true;

    void Awake()
    {
        pthis = this;
    }
	// Use this for initialization
	void Start ()
    {
        switch (SysMain.Now_Page)
        {
            case ENUM_Page.Calculator_Get:
                Lb_Title.text = "請輸入收入金額";
                break;
            case ENUM_Page.Calculator_Pay:
                Lb_Title.text = "請輸入支出金額";
                break;
            default:
                Lb_Title.text = "Page Error";
                break;
        }

        ClearCalcData();
    }

    // 更新顯示.
    void Refresh()
    {
        dTotal = double.Parse(currentNum);

        if (currentNum.Contains("."))
            Lb_TotalNum.text = dTotal.ToString("C2").Remove(0,1);
        else
            Lb_TotalNum.text = dTotal.ToString("N0");
    }

    // 增加數字.
    public void AddendNumber(string s)
    {
        // 不可以按兩次點.
        if (s == "." && currentNum.Contains("."))
            return;

        if ((currentNum == "0") || shouldClearScreen)
            currentNum = (s == ".") ? "0." : s;
        else 
            if (currentNum.Length < GameDefine.iMaxCalculatorNum)
                currentNum += s;

        if (shouldClearScreen)
            shouldClearScreen = false;

        StoreCurrentNumberInReg(isFirst ? 0 : 1);

        Refresh();
    }

    // 刪除數字.
    public void delendNumber()
    {
        currentNum = currentNum.Remove(currentNum.Length - 1, 1);

        StoreCurrentNumberInReg(isFirst ? 0 : 1);
        Refresh();
    }

    public void OperatorPressed(string op)
    {
        // 切換OK為等於.
        SwitchOK(false);

        StoreCurrentNumberInReg(0);
        isFirst = false;
        shouldClearScreen = true;
        currentOperationToPerform = op;
    }

    void StoreCurrentNumberInReg(int regNumber)
    {
        registers[regNumber] = float.Parse(currentNum, CultureInfo.InvariantCulture.NumberFormat);
    }

    public void PerformOperation()
    {
        if (bIsOKBtn)
        {
            SysMain.SetTempNumber(dTotal);
            UITool.pthis.CreatePanel("P_Tag");
            Destroy(gameObject);
            return;
        }

        switch (currentOperationToPerform)
        {
            case "+":
                if (currentNum != "NaN")
                    currentNum = (registers[0] + registers[1]).ToString();
                break;
            case "-":
                if (currentNum != "NaN")
                    currentNum = (registers[0] - registers[1]).ToString();
                break;
            case "x":
                if (currentNum != "NaN")
                    currentNum = (registers[0] * registers[1]).ToString();
                break;
            case "/":
                if (currentNum != "NaN")
                    currentNum = (registers[1] != 0) ? (registers[0] / registers[1]).ToString() : "NaN";
                break;
            case "":
                break;
            default:
                Debug.LogError("Unknown operation: " + currentOperationToPerform);
                break;
        }
        StoreCurrentNumberInReg(0);
        isFirst = true;
        shouldClearScreen = true;

        // 切換OK為等於.
        SwitchOK(true);

        Refresh();
    }
    
    // 清空數字.
    public void ClearCalcData()
    {
        SwitchOK(true);
        isFirst = true;
        shouldClearScreen = true;
        currentOperationToPerform = "";
        currentNum = "0";
        Lb_TotalNum.text = "0";
        for (int i = 0; i < registers.Length; i++)
            registers[i] = 0;
    }

    public void SwitchOK(bool bIsOK)
    {
        bIsOKBtn = bIsOK;
        if (bIsOK)
            Lb_OK.text = "OK";
        else
            Lb_OK.text = "=";
    }
}
