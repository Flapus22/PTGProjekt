using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesColider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            other.GetComponent<NewPlayerController>().GetHit(10);
        }
    }
}
