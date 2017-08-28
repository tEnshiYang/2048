using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class buttonstart : MonoBehaviour {
  
    public GameObject shuomingmianban;
   
    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public static bool hasShuo=false;

    // Use this for initialization
    void Start () {
        text1.fontSize +=20;
        text2.fontSize += 20;
        text3.fontSize += 20;
        text4.fontSize += 20;
    }
	
	// Update is called once per frame
	void Update () {
    
	}

    public void clickStart()
    {
        Application.LoadLevel("main");
    }

public void clickExit()
    {
        Application.Quit();
    }

    public void mianbanon()
    {
        hasShuo = true;
        shuomingmianban.SetActive(true);

       
    }

    public void guanbi()
    {
        hasShuo = false;
        shuomingmianban.transform.localScale = new Vector3(0,0,0);
        shuomingmianban.GetComponent<TweenScale>().ResetToBeginning();
        shuomingmianban.SetActive(false);
        shuomingmianban.GetComponent<TweenScale>().enabled = true;
        
    }
}
