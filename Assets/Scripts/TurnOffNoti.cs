using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TurnOffNoti : MonoBehaviour
{
    // Start is called before the first frame update
    float timeNow;
    private void OnEnable() {
        timeNow = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timeNow + 2.5f) gameObject.SetActive(false);
    }
}
