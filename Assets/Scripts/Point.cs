using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    Vector3 startPosition;
    Vector3 endPosition;
    private void Start()
    {
        startPosition = transform.position;
        endPosition = startPosition;
        endPosition.y += 0.2f;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            other.GetComponent<NewPlayerController>().GetPoint();
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        float velocity = 2;
        float change = (Mathf.Sin(Time.timeSinceLevelLoad * velocity) + 1f) / 2f;
        transform.position = Vector3.Lerp(startPosition, endPosition, change);
    }
}
