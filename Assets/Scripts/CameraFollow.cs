using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform target;
    public Vector3 offset;
    public float followSpeed = 10f;

    void Start()
    {
        target = GameObject.Find("SnowPrincess").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        transform.position = target.position + offset;
    }
}
