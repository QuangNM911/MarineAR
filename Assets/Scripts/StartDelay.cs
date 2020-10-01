using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDelay : MonoBehaviour
{
    public float timeDelay;

    // Start is called before the first frame update
    void Start()
    {
        timeDelay += Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= timeDelay) gameObject.SetActive(false);
    }
}
