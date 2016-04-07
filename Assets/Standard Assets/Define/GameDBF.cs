using UnityEngine;
using LibCSNStandard;
using System.Collections;

public class GameDBF : MonoBehaviour
{
	private DBFData m_DBF = new DBFData();

	public static GameDBF pthis = null;

	void Awake()
	{
		pthis = this;
        Add<DBFLanguage>(GameDefine.szDBFLanguage);
        Add<DBFMonster>(GameDefine.szDBFMonster);
        Add<DBFMission>(GameDefine.szDBFMission);
    }

    public void Add<T>(string szDBFName) where T : DBF
	{
		Debug.Log("load dbf " + szDBFName + " " + (m_DBF.Add<T>(szDBFName, "DBF/" + szDBFName) ? "success" : "failed"));
	}
	public string GetLanguage(Argu GUID)
	{
		DBFLanguage Data = m_DBF.Get(GameDefine.szDBFLanguage, GUID) as DBFLanguage;

		if(Data == null)
			return "";

		switch(GameData.pthis.Language)
		{
		case ENUM_Language.zhTW: return Data.zhTW;
		case ENUM_Language.enUS: return Data.enUS;
		default: return "";
		}//switch
	}
	public DBFItor GetLanguage()
	{
		return m_DBF.Get(GameDefine.szDBFLanguage);
	}
	public DBF GetMonster(Argu GUID)
	{
		return m_DBF.Get(GameDefine.szDBFMonster, GUID);
	}
	public DBFItor GetMonster()
	{
		return m_DBF.Get(GameDefine.szDBFMonster);
	}
    public DBF GetMission(Argu GUID)
    {
        return m_DBF.Get(GameDefine.szDBFMission, GUID);
    }
    public DBFItor GetMission()
    {
        return m_DBF.Get(GameDefine.szDBFMission);
    }
}
