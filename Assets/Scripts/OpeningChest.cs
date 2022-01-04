using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpeningChest : MonoBehaviour
{
    public float openingSpeed = 555f;

    private void OnTriggerEnter(Collider other) //trzeba si� upewni�, �e przeciwnicy tego nie zaktywuj�
    {
        transform.Rotate(Vector3.right, -10f); //-openingSpeed* Time.deltaTime); //trzeba zrobi� aby powoli si� otwiera�o do k�ta -55, 
        GetComponent<Collider>().enabled = false;
    }
}
