using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 0, -10);
    public float smoothing;

    private Vector2 minPosition, maxPosition;
    private Camera cam;
    void Start()
    {
        cam = GetComponent<Camera>();
    }
    
    void Update()
    {
        Vector3 o;
        if (Input.GetAxisRaw("Horizontal") >= 0)
        {
            o = offset;
        }
        else
        {
            o = new Vector3(-offset.x, offset.y, offset.z);
        }

        Vector3 targetPosition = target.position + o;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
    }

   
}
