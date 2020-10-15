using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleByTouch : MonoBehaviour
{
    public GameObject selectedObject;
    Vector3 initialScale;
    float initialFingersDistance;

    // Update is called once per frame
    void Update()
    {
        int fingersOnScreen = 0;
        // If there are two touches on the device...
        foreach (Touch touch in Input.touches)
        {
            fingersOnScreen++;
 
            if (fingersOnScreen == 2)
            {
                //First set the initial distance between fingers so you can compare.
                if (touch.phase == TouchPhase.Began)
                {
                    initialFingersDistance = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
                    initialScale = selectedObject.transform.localScale;
                }
                else
                {
                    var currentFingersDistance = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
                    var scaleFactor = currentFingersDistance / initialFingersDistance;
                    selectedObject.transform.localScale = initialScale * scaleFactor;
                }
            }
        }
    }
}
