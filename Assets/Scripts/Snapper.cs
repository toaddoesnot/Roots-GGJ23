using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snapper : MonoBehaviour
{
    public bool slotFull;

    public string tagSt;
    public string wrongTag1;
    public string wrongTag2;

    //public float m_XAxis, m_YAxis, m_ZAxis;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == tagSt)
        {
            //other.GetComponent<InteractableObj>().r_XAxis = m_XAxis;
            //other.GetComponent<InteractableObj>().r_YAxis = m_YAxis;
            //other.GetComponent<InteractableObj>().r_ZAxis = m_ZAxis;

            //other.GetComponent<InteractableObj>().ChangePosition();
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == tagSt)
        {
            slotFull = true;
        }
        if (other.gameObject.tag == wrongTag1 || other.gameObject.tag == wrongTag2)
        {
            other.GetComponent<InteractableObj>().teleported = true;
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
