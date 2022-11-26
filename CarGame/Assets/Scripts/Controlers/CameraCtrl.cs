using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public Transform cameraTarget;
    public float speed = 10.0f;
    public Vector3 distance;
    public Transform lookTarget;


    private void FixedUpdate()
    {
        Vector3 dPos = cameraTarget.position + distance;
        Vector3 sPos = Vector3.Lerp(transform.position, dPos, speed * Time.deltaTime);
        transform.position = sPos;
        transform.LookAt(lookTarget.position);
    }


}
