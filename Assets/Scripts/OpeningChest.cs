using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OpeningChest : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myAnimationController.SetBool("PlayOpen", true);
            GetComponent<Collider>().enabled = false;
            StartCoroutine(Load());
        }
    }

    private IEnumerator Load()
    {
        yield return new WaitForSeconds(2);
    }
    //public float openingSpeed = 555f;

    //private void OnTriggerEnter(Collider other) //trzeba siê upewniæ, ¿e przeciwnicy tego nie zaktywuj¹
    //{
    //    transform.Rotate(Vector3.right, -10f); //-openingSpeed* Time.deltaTime); //trzeba zrobiæ aby powoli siê otwiera³o do k¹ta -55, 
    //    GetComponent<Collider>().enabled = false;
    //}
}
