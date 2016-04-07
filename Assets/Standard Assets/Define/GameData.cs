using UnityEngine;
using System.Collections;

public class GameData : MonoBehaviour
{
    static public GameData pthis = null;

    public ENUM_Language Language = ENUM_Language.zhTW;

    void Awake()
    {
        pthis = this;
    }
	
}
