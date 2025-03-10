using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject BallObject;

    void Update()
    {
        if (BallObject.transform.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, BallObject.transform.position.y, transform.position.z);

        }
    }
   
}
