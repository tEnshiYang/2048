using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class buttonevent : MonoBehaviour {
    AudioSource audio;
    public Sprite musicoff;
    public Sprite musicplay;
    Image ima;       //bgm开关


    void Start () {
        audio = GetComponent<AudioSource>();
        ima = GetComponent<Image>();
	}

    
    public void MusicOn()
    {
       
        if (audio.isPlaying)
        {
            audio.Stop();
            ima.sprite = musicoff;

        }
        else
        {
            audio.Play();
            ima.sprite = musicplay;
        }
    }

    public void mainClose()
    {
        Application.Quit();
    }

    public void ReLoadLevel()
    {
        Application.LoadLevel("thou");
    }
}
