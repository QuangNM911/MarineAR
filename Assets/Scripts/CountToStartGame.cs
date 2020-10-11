using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CountToStartGame : MonoBehaviour
{
    float timeNow;
    public Text countText;
    public GameObject controlCanvas;

    public AudioClip tiktok;

    public AudioClip startSound;
    int timeCount = 3;
    float temp;

    AudioSource soundEffect;
    // Start is called before the first frame update
    void Start()
    {
        timeCount = 3;
        timeNow = Time.time;
        temp = Time.time;
        soundEffect = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
        soundEffect.PlayOneShot(tiktok);
    }

    // Update is called once per frame
    void Update()
    {
        timeNow += Time.deltaTime;
        if(timeNow >= (4 - timeCount) + temp) {
            timeCount --;
            countText.text = "" + timeCount;
            soundEffect.PlayOneShot(tiktok);
        }

        if(timeCount == 0){
            soundEffect.PlayOneShot(startSound);
            controlCanvas.SetActive(true);
            gameObject.SetActive(false);
        }

    }
}
