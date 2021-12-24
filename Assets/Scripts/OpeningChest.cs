using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpeningChest : MonoBehaviour
{
    public float openingSpeed = 25f;

    void Update()
    {

        if (transform.rotation.x >= -55f)
        {
            transform.Rotate(Vector3.right, -openingSpeed * Time.deltaTime);
        }
    }
}
