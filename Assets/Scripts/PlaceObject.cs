using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class PlaceObject : MonoBehaviour
{
    public Vector3 addToPlacePosition;
    [SerializeField]
    GameObject objectToPlace;

    [SerializeField]
    GameObject mapPlayGame;

    [SerializeField]
    ARPlaneManager aRPlaneManager;

    [SerializeField]
    GameObject tabToPlaceCanvas;

    [SerializeField]
    GameObject moveCameraCanvas;
    
    List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();

    [SerializeField]
    ARRaycastManager aRRaycastManager;

    bool isPlace = false;
    // Update is called once per frame
    void Update()
    {
        if(isPlace) return;
        var listPlane = aRPlaneManager.trackables;
        if(listPlane.count > 0){
            moveCameraCanvas.SetActive(false);
            tabToPlaceCanvas.SetActive(true);
        }
        if(Input.touchCount > 0){
            Touch t = Input.GetTouch(0);
            if(t.phase == TouchPhase.Began){
                if(aRRaycastManager.Raycast(t.position, raycastHits, TrackableType.PlaneWithinPolygon)){
                    Pose hitPose = raycastHits[0].pose;
                    //Instantiate(objectToPlace, hitPose.position, hitPose.rotation);
                    objectToPlace.SetActive(true);
                    objectToPlace.transform.position = hitPose.position;
                    //mapPlayGame.transform.position = hitPose.position + addToPlacePosition;
                    // mapPlayGame.transform.rotation = hitPose.rotation;
                    // Vector3 v = mapPlayGame.transform.eulerAngles;
                    // v.x = v.z = 0;
                    // mapPlayGame.transform.eulerAngles = v;
                    objectToPlace.transform.eulerAngles = Vector3.zero;
                    foreach(var plane in listPlane){
                        plane.gameObject.SetActive(false);
                    }
                    isPlace = true;
                    aRPlaneManager.enabled = false;
                    tabToPlaceCanvas.SetActive(false);
                }
            }
        }
    }
}
