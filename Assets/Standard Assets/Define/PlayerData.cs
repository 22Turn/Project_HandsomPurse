using UnityEngine;
using LibCSNStandard;

public class PlayerData : MonoBehaviour
{
    public static float fMoney = 0;

    public static int iTagCount = 0;
    public static string[] strTag = new string[50];

    public static SaveData<C_SaveTag> TagDatas = new SaveData<C_SaveTag>();
    // ------------------------------------------------------------------
    private void Start()
    {
        LoadTag();
        /*
        SaveData<SaveMoney> saveDatas = new SaveData<SaveMoney>();

        saveDatas.Add(new SaveMoney() { GUID = new Argu(123), name = "都嚕嚕", note = "卡00巴00巴", money = 999, count = 1, });
        saveDatas.Add(new SaveMoney() { GUID = new Argu("b"), name = "咖乃乃", note = "卡01巴10巴", money = 888, count = 3, });
        saveDatas.Add(new SaveMoney() { GUID = new Argu(223), name = "打逼逼", note = "卡11巴11巴", money = 777, count = 5, });
        saveDatas.Add(new SaveMoney() { GUID = new Argu("d"), name = "得嚕啦", note = "卡21巴12巴", money = 666, count = 7, });
        saveDatas.Add(new SaveMoney() { GUID = new Argu("e"), name = "軟七基", note = "卡34巴43巴", money = 123456789, count = 9, });

        string json = saveDatas.ToString();

        Debug.Log("json=" + json);

        saveDatas.Load(json);

        SaveItor<SaveMoney> itor = saveDatas.GetItor();

        while(itor.IsEnd() == false)
        {
            Debug.Log("data=" + itor.Data().ToString());
            itor.Next();
        }*/
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
    public static void SaveTagtoPlayerPrefs()
    {
        PlayerPrefs.SetString("SaveTag", TagDatas.ToString());
        Debug.Log("SaveTag data = " + TagDatas.ToString());
    }
    // ------------------------------------------------------------------
    public static void LoadTag()
    {
        // 讀取Tag資料.
        string json = PlayerPrefs.GetString("SaveTag", "");
        TagDatas.Load(json);

        SaveItor<C_SaveTag> itor = TagDatas.GetItor();
        
        for (int i = 0; itor.IsEnd() == false; i++)
        {
            Debug.Log("data=" + itor.Data().ToString());
            strTag[i] = itor.Data().GUID;
            itor.Next();
        }

        iTagCount = TagDatas.Count();
    }
    // ------------------------------------------------------------------
    public static bool AddTag(string sValue,int TagType)
    {
        strTag[iTagCount] = sValue;

        C_SaveTag TempTag = new C_SaveTag();
        TempTag.GUID = new Argu(sValue);
        TempTag.TagID = iTagCount;
        TempTag.TagType = TagType;

        TagDatas.Add(TempTag);
        SaveTagtoPlayerPrefs();
        iTagCount++;
        return true;
    }

    public class SaveMoney : Save
    {
        public int TagName = 0;
        public string name = "";
        public string note = "";
        public int money = 0;
        public int count = 0;

        public override string ToString()
        {
            return "TagName=" + TagName + ", name=" + name + ", note=" + note + ", money=" + money + ", count=" + count;
        }
    }

    public class C_SaveTag : Save
    {
        public int TagID = 0;
        public int TagType = 1; // 1.收入 2.支出

        public override string ToString()
        {
            return "TagID" + TagID;
        }
    }
}