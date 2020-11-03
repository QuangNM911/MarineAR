using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyGameObject : MonoBehaviour
{
    static GameObject instance;
    private void Awake() {
        if(instance == null){
            instance = this.gameObject;
            //PlayerPrefs.SetInt("haveShowNoti", 0);
            DontDestroyOnLoad(gameObject);
        }
        else{
            Destroy(gameObject);
        }
    }
}
