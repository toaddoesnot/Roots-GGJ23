using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EraManager : MonoBehaviour
{
    public GameObject[] rooms;

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
