using UnityEngine;
using System.Collections;
using System.Globalization;

public class P_Calculator : MonoBehaviour
{
    static public P_Calculator pthis = null;

    public UILabel Lb_Title = null;
    public UILabel Lb_TotalNum = null;

    public double dTempNum = 0;
    public double dTotal = 0;

    public float[] registers = new float[2];//2 registers
    public string currentNumber = "0";
    public int calcScreenFontSize = 27;
    public int operationFontSize = 15;
    public string currentOperationToPerform = "";
    public int maxDigits = 11;
    public bool isFirst = true;
    public bool shouldClearScreen = false;

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
    }

    // 更新顯示.
    void Refresh()
    {
        Lb_TotalNum.text = dTotal.ToString("#,0");
    }

    // 增加數字.
    public void AddendNumber(string s)
    {
        if ((currentNumber == "0") || shouldClearScreen)
            currentNumber = (s == ".") ? "0." : s;
        else
            if (currentNumber.Length < maxDigits)
            currentNumber += s;

        if (shouldClearScreen)
            shouldClearScreen = false;
        StoreCurrentNumberInReg(isFirst ? 0 : 1);
    }

    // 增加數字.
    public void SetNum(double dNum)
    {
        if (Lb_TotalNum.text.Length >= 15)
            return;

        if(dTotal == 0)
            dTotal = dNum;
        else
            dTotal = double.Parse(dTotal.ToString() + dNum);

        Refresh();
    }
    
    public void OperatorPressed(string op)
    {
        StoreCurrentNumberInReg(0);
        isFirst = false;
        shouldClearScreen = true;
        currentOperationToPerform = op;
    }

    void StoreCurrentNumberInReg(int regNumber)
    {
        registers[regNumber] = float.Parse(currentNumber, CultureInfo.InvariantCulture.NumberFormat);
    }

    void PerformOperation()
    {
        switch (currentOperationToPerform)
        {
            case "+":
                if (currentNumber != "NaN")
                    currentNumber = (registers[0] + registers[1]).ToString();
                break;
            case "-":
                if (currentNumber != "NaN")
                    currentNumber = (registers[0] - registers[1]).ToString();
                break;
            case "x":
                if (currentNumber != "NaN")
                    currentNumber = (registers[0] * registers[1]).ToString();
                break;
            case "/":
                if (currentNumber != "NaN")
                    currentNumber = (registers[1] != 0) ? (registers[0] / registers[1]).ToString() : "NaN";
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
    }

    // 清空數字.
    public void ClearCalcData()
    {
        isFirst = true;
        shouldClearScreen = true;
        currentOperationToPerform = "";
        currentNumber = "0";
        for (int i = 0; i < registers.Length; i++)
            registers[i] = 0;
    }
}
