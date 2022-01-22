using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public Vector3 delta;
    Vector3 startPosition;
    Rigidbody rigidbody;


    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        startPosition = transform.position;
    }

    void Update()
    {
        float velocity = 50f / delta.sqrMagnitude;
        float change = (Mathf.Sin(Time.timeSinceLevelLoad * velocity) + 1f) / 2f;
        rigidbody.position = Vector3.Lerp(startPosition, startPosition + delta, change);
    }


#if UNITY_EDITOR

    public bool visibleGizmo;
    private void OnDrawGizmos()
    {
        if (visibleGizmo)
        {

            Gizmos.color = Color.gray;

            if (Selection.activeTransform == transform)
            {
                Gizmos.color = Color.yellow;
            }

            Vector3 ghostPosition = transform.position + delta;
            Vector3 ghostSize = transform.localScale;
            var rotate = transform.rotation;
            MeshFilter meshFilter = GetComponent<MeshFilter>();
            //Gizmos.DrawWireCube(ghostPosition, ghostSize);

            Gizmos.DrawWireMesh(meshFilter.sharedMesh, ghostPosition, rotate, ghostSize);
        }
    }
#endif
}
