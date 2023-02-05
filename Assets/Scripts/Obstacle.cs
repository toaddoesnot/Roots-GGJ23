using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public bool colliding;
    public InteractableObj inside;


    public void Update()
    {
        if(inside != null)
        {
            if (colliding)
            {
                inside.teleported = true;
                inside.holding = false;
            }
            else
            {
                //inside.teleported = false;
            }
        }

       
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "itemM" || other.tag == "itemL" || other.tag == "itemR" || other.tag == "itemL2")
        {
            inside = other.GetComponent<InteractableObj>();
            colliding = true;
            
        }
       
    }

    public void OnTriggerExit()
    {
        colliding = false;
    }
}
