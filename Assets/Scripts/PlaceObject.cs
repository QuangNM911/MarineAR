using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class PlaceObject : MonoBehaviour
{
    [SerializeField]
    GameObject objectToPlace;
    
    List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();

    [SerializeField]
    ARRaycastManager aRRaycastManager;
    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0){
            Touch t = Input.GetTouch(0);
            if(t.phase == TouchPhase.Began){
                if(aRRaycastManager.Raycast(t.position, raycastHits, TrackableType.PlaneWithinPolygon)){
                    Pose hitPose = raycastHits[0].pose;
                    Instantiate(objectToPlace, hitPose.position, hitPose.rotation);
                }
            }
        }
    }
}
