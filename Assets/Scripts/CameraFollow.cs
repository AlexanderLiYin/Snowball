using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float followSpeed = 10f;

    void FixedUpdate()
    {
        transform.position = target.position + offset;
    }
}
