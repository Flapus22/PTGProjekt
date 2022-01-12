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
    //private void OnTriggerEnter(Collider other) //trzeba si� upewni�, �e przeciwnicy tego nie zaktywuj�
    //{
    //    transform.Translate(Vector3.right, Space.World);    //jak zrobi� by si� przesun�o p�ynnie, to samo w skrzyni
    //    GetComponent<Collider>().enabled = false;
    //}
}