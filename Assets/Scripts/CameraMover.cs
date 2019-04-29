using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{

    public Transform target;
    public Vector3 offset;
    public float moveSpeed;
    public int decimals;

    void Start()
    {
        
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, moveSpeed * Time.deltaTime);
        transform.position = new Vector3((float)Math.Round(transform.position.x, decimals), (float)Math.Round(transform.position.y, decimals), transform.position.z);
    }
}
