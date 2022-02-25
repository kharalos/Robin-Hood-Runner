using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Transform target;
    [Range(0,20)] [SerializeField] private float altitude = 15f;
    [Range(0,20)] [SerializeField] private float longitude = 13f;
    [Range(0,10)] [SerializeField] private float lerpTime = 1.4f;
    [Range(0,30)] [SerializeField] private float angle = 15f;

    void Update()
    {
        if(target == null) return;
        transform.position = Vector3.Slerp(transform.position, new Vector3(0.0f,altitude, -longitude) + target.position, lerpTime * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(angle, 0.0f, 0.0f), lerpTime * Time.deltaTime);
    }
}
