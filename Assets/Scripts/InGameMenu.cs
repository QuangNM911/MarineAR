using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InGameMenu : MonoBehaviour
{
    public void BackToMenu(){
        SceneManager.LoadScene(0);
    }

    public void Replay(){
        Debug.Log("RePlay");
        SceneManager.LoadScene(1);
    }

    public void QuitApp(){
        Application.Quit();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            Replay();
        }
    }
}
