using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log(other.transform.tag);
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other.transform.tag + "x");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
