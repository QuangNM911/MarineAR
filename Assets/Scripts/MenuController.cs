using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuController : MonoBehaviour
{
    AudioSource backgroundMusic;
    AudioSource soundEffect;

    public Image loadingBarImage;

    public GameObject infoCanvas;

    public GameObject callCanvas;

    public GameObject aiCanvas;

    public Text bestScore;

    public Color disableButtonColor;

    public Image backgroundMusicButton;

    public Image soundEffectButton;
    private void Start() {
        backgroundMusic = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
        soundEffect = GameObject.Find("SoundEffect").GetComponent<AudioSource>();
        bestScore.text = "" + PlayerPrefs.GetInt("best", 0);

        if(backgroundMusic.volume == 0) backgroundMusicButton.color = disableButtonColor;
        if(soundEffect.volume == 0) soundEffectButton.color = disableButtonColor;
    }
    public void PlayAR(){
        StartCoroutine(LoadARScene());
    }

    IEnumerator LoadARScene(){
        AsyncOperation ao = SceneManager.LoadSceneAsync(1);
        while(!ao.isDone){
            loadingBarImage.fillAmount = Mathf.Clamp01(ao.progress/.9f);
            yield return null;
        }
    }

    public void OnOffBackgroundMusic(){
        backgroundMusic.volume = (backgroundMusic.volume+1)%2;
        if(backgroundMusic.volume == 0){
            backgroundMusicButton.color = disableButtonColor;
        }
        else{
            backgroundMusicButton.color = Color.white;
        }
    }

    public void OnOffSoundEffect(){
        soundEffect.volume = (soundEffect.volume+1)%2;
        if(soundEffect.volume == 0){
            soundEffectButton.color = disableButtonColor;
        }
        else{
            soundEffectButton.color = Color.white;
        }
    }

    public void TurnOnInfo(){
        Application.OpenURL("http://kcmb-ai.com.tw:8000/");
    }

    public void TurnOnCallCanvas(){
        callCanvas.SetActive(true);
    }

    public void TurnOffCallCanvas(){
        callCanvas.SetActive(false);
    }

    public void ShowAICanvas(){
        aiCanvas.SetActive(true);
    }

    public void TurnOffAICanvas(){
        aiCanvas.SetActive(false);
    }

}
