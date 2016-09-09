using UnityEngine;
using System.Collections;

public class G_TagType : MonoBehaviour
{
    public UISprite pTagBg = null;
    public UILabel pTagName = null;

    	// Use this for initialization
	void Start () {
	
	}
	
	public void SetName(string sTagName)
    {
        pTagName.text = sTagName;

        pTagBg.width = pTagName.width + 90;
    }

    public int GetWidth()
    {
        return pTagBg.width;
    }
}
