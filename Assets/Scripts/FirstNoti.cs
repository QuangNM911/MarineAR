using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstNoti : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int i = PlayerPrefs.GetInt("haveShowNoti", 0);
        if(i != 0) Destroy(gameObject);
        else {
            Destroy(gameObject, 5f);
            PlayerPrefs.SetInt("haveShowNoti", 1);
        }
    }
}
