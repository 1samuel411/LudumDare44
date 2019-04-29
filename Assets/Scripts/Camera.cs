using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    public Transform target;
    public float rotateSpeed;
    private int direction, lastDir;

    void Start()
    {
        
    }

    void Update()
    {
        GetDirection();

        transform.localScale = new Vector3(direction, 1, 1);

        if(direction != lastDir)
        {
            lastDir = direction;
            transform.eulerAngles = new Vector3(0, 0, GetRotation());
        }
        transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(0, 0, GetRotation()), rotateSpeed * Time.deltaTime);
    }

    void GetDirection()
    {
        if (transform.position.x - target.position.x < 0)
            direction = -1;
        else
            direction = 1;
    }

    int GetRotation()
    {
        int rotation = (int)(Mathf.Atan2(transform.position.y - target.position.y, transform.position.x - target.position.x) * Mathf.Rad2Deg);

        if(direction == -1)
            rotation += 180;

        return rotation;
    }
}
