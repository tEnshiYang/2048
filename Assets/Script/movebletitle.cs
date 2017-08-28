using UnityEngine;
using System.Collections;

public class movebletitle : MonoBehaviour {
    float time = 1f;
    float timer = 0f;
    public GameObject shuomingmianban;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (buttonstart.hasShuo)
        {
            if (Input.GetMouseButtonDown(0))
            {
                shuomingmianban.transform.localScale = new Vector3(0, 0, 0);
                shuomingmianban.GetComponent<TweenScale>().ResetToBeginning();
                shuomingmianban.SetActive(false);
                shuomingmianban.GetComponent<TweenScale>().enabled = true;
            }
        }
        timer += Time.deltaTime;
       
        if (timer < 1)
        {

            transform.position += new Vector3(0f, 0.005f, 0f);
        }
        if (1 < timer && timer < 2)
        {

            transform.position -= new Vector3(0f, 0.0048f, 0f);

        }
        if (timer >= 2)
        {
            timer = 0;
        }


    }
}
