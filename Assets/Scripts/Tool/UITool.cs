using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class UITool : MonoBehaviour
{
    public static UITool pthis;

    void Awake()
    {
        pthis = this;
    }
    // ------------------------------------------------------------------
    public GameObject CreateUI(GameObject Parent, string Path)
    {
		if(Resources.Load(Path) == null)
			Debug.Log(Path + " is NULL");
		return NGUITools.AddChild(Parent, Resources.Load(Path) as GameObject);
    }
    // ------------------------------------------------------------------
}
