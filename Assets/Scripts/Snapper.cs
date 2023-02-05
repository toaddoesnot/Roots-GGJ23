using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapper : MonoBehaviour
{
    public bool slotFull;

    public string tagSt;
    public string wrongTag1;
    public string wrongTag2;
    public string wrongTag3;

    //public InteractableObj impostor;
    //public bool colliding;

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == tagSt)
        {
            slotFull = true;
        }
        
        if (other.gameObject.tag == wrongTag1 || other.gameObject.tag == wrongTag2 || other.gameObject.tag == wrongTag3)
        {
            other.GetComponent<InteractableObj>().teleported = true;
            other.GetComponent<InteractableObj>().holding = false;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == tagSt)
        {
            slotFull = false;
        }
        
    }
}
