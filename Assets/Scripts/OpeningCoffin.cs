using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpeningCoffin : MonoBehaviour
{
    public float openingSpeed = 0.01f;
    private void OnTriggerEnter(Collider other) //trzeba siê upewniæ, ¿e przeciwnicy tego nie zaktywuj¹
    {
        transform.Translate(Vector3.right * openingSpeed * Time.deltaTime, Space.World);    //jak zrobiæ by siê przesunê³o p³ynnie, to samo w skrzyni
        GetComponent<Collider>().enabled = false;
    }
}