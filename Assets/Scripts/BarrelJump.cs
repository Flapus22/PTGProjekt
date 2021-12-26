using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelJump : MonoBehaviour
{
    public float highJump = 5;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Wszed³em");
        if (other.tag == "Player")
        {
            other.GetComponent<NewPlayerController>().Jump(highJump);
        }
    }
}
