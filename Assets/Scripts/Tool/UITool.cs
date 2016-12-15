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
    void Start()
    {
        //PlayerPrefs.DeleteAll();
    }
    // ------------------------------------------------------------------
    public GameObject CreatePanel(string Name)
    {
        if (Resources.Load("Prefab/Panel/" + Name) == null)
            Debug.Log("Prefab/Panel/" + Name + " is NULL");
        return NGUITools.AddChild(gameObject, Resources.Load("Prefab/Panel/" + Name) as GameObject);
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
