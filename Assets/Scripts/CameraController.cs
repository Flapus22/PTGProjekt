using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform playerTransform;
    public Vector3 offset;

    private bool isPlayerFound = false;
    private void Start()
    {
        StartCoroutine(WaitForPlayer());
    }
    private IEnumerator WaitForPlayer()
    {
        while (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            yield return null;
        }
        isPlayerFound = true;
    }
    private void Update()
    {
        if (isPlayerFound)
        {
            transform.position = playerTransform.position + offset;
        }
    }
}
