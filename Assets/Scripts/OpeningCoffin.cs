using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpeningCoffin : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myAnimationController.SetBool("PlayOpen", true);
            GetComponent<Collider>().enabled = false;
        }
    }

    //public float openingSpeed = 1f;
    //private void OnTriggerEnter(Collider other) //trzeba siê upewniæ, ¿e przeciwnicy tego nie zaktywuj¹
    //{
    //    transform.Translate(Vector3.right, Space.World);    //jak zrobiæ by siê przesunê³o p³ynnie, to samo w skrzyni
    //    GetComponent<Collider>().enabled = false;
    //}
}