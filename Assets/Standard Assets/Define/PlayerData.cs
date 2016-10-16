using UnityEngine;
using LibCSNStandard;

public class PlayerData : MonoBehaviour
{
    public static float fMoney = 0;

    public static int iTagCount = 0;
    public static string[] strTag = new string[50];

    // ------------------------------------------------------------------
    private void Start()
    {
        // 取得Tag總數.
        //iTagCount = PlayerPrefs.GetInt("iTagCount", 0);
        // 取得Tag名稱.

        SaveData<TestOfSave> saveDatas = new SaveData<TestOfSave>();

        saveDatas.Add(new TestOfSave() { GUID = new Argu(123), name = "都嚕嚕", note = "卡00巴00巴", money = 999, count = 1, });
        saveDatas.Add(new TestOfSave() { GUID = new Argu("b"), name = "咖乃乃", note = "卡01巴10巴", money = 888, count = 3, });
        saveDatas.Add(new TestOfSave() { GUID = new Argu(223), name = "打逼逼", note = "卡11巴11巴", money = 777, count = 5, });
        saveDatas.Add(new TestOfSave() { GUID = new Argu("d"), name = "得嚕啦", note = "卡21巴12巴", money = 666, count = 7, });
        saveDatas.Add(new TestOfSave() { GUID = new Argu("e"), name = "軟七基", note = "卡34巴43巴", money = 123456789, count = 9, });

        string json = saveDatas.ToString();

        Debug.Log("json=" + json);

        saveDatas.Load(json);

        SaveItor<TestOfSave> itor = saveDatas.GetItor();

        while(itor.IsEnd() == false)
        {
            Debug.Log("data=" + itor.Data().ToString());
            itor.Next();
        }
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

    public class TestOfSave : Save
    {
        public string name = "";
        public string note = "";
        public int money = 0;
        public int count = 0;

        public override string ToString()
        {
            return "name=" + name + ", note=" + note + ", money=" + money + ", count=" + count;
        }
    }
}