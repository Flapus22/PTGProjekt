using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCanJump : MonoBehaviour
{
    public PlayerController player;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Moge skaka�");

        if (other.tag != "Enemy")
        {
            player.canJump = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Nie Moge skaka�");

        if (!other.tag.Equals("Enemy") && !other.tag.Equals("Player"))
        {
            player.canJump = false;
        }
    }


}
