using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraManager : MonoBehaviour
{
    public GameObject[] rooms;
    public GameObject Rcollider;
    public GameObject LCollider;

    public GameObject TV;


    public void Update()
    {
        if (rooms[2].GetComponent<EraHolder>().currentEra is 1) //mid
        {
            if(Rcollider.GetComponent<Snapper>().slotFull is false)
            {
                rooms[0].GetComponent<EraHolder>().influCube.SetActive(false);
            }
            if (rooms[0].GetComponent<EraHolder>().influCube.activeInHierarchy is false)
            {
                rooms[1].GetComponent<EraHolder>().influCube.SetActive(false);
            }
            if (LCollider.GetComponent<Snapper>().slotFull is true)
            {
                TV.SetActive(false);
            }
            
        }



    }

    public void ButtonTo()
    {
        foreach (GameObject room in rooms)
        {
            room.GetComponent<EraHolder>().TimeTo();
        }
    }
    public void ButtonBack()
    {
        
        foreach (GameObject room in rooms)
        {
            room.GetComponent<EraHolder>().TimeBack();
        }
    }
}
