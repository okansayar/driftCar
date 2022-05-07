using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; //kamera neyi takip edicek
    public Vector3 offset; //takip arasýndaki mesafe
    void Start()
    {
        
    }

  
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * 3);
    }
}
