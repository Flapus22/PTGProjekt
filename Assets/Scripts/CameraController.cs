using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;
    Vector3 moveCamera;

    private void Start()
    {
        //moveCamera = offset;
        //transform.Translate(moveCamera);
    }

    private void LateUpdate()
    {
        //    moveCamera = playerTransform.position * Time.deltaTime;
        //    transform.Translate(moveCamera);
        transform.position = playerTransform.position + offset;
    }
}
