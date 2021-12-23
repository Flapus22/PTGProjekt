using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCanJump : MonoBehaviour
{
    public PlayerController player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Enemy")
        {
            player.canJump = true;
            Debug.Log("Moge skakaæ");

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Enemy")
        {
            player.canJump = false;
            Debug.Log("Nie Moge skakaæ");
        }
    }
}
