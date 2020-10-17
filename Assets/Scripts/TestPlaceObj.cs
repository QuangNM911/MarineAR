using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlaceObj : MonoBehaviour
{
    public GameObject gameMap;
    // Start is called before the first frame update
    public void AddX(){
        Vector3 v = gameMap.transform.position;
        v.x++;
        gameMap.transform.position = v;
    }

    public void MinusX(){
        Vector3 v = gameMap.transform.position;
        v.x--;
        gameMap.transform.position = v;
    }

    public void AddY(){
        Vector3 v = gameMap.transform.position;
        v.y++;
        gameMap.transform.position = v;
    }

    public void MinusY(){
        Vector3 v = gameMap.transform.position;
        v.y--;
        gameMap.transform.position = v;
    }

    public void AddZ(){
        Vector3 v = gameMap.transform.position;
        v.z++;
        gameMap.transform.position = v;
    }

    public void MinusZ(){
        Vector3 v = gameMap.transform.position;
        v.z--;
        gameMap.transform.position = v;
    }
}
