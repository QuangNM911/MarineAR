using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScaleWithScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 v = transform.localScale;
        v.y *= Mathf.Sqrt((Screen.width/Screen.height)/(2048/1536));
        transform.localScale = v;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
