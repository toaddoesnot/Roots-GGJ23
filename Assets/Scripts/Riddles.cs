using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Riddles : MonoBehaviour
{
    public GameObject[] locks;
    public int neutralEra;

    public Button backBut;
    public Button toBut;
    public bool butsActive;

    public GameObject referenceRoom;
    public EraManager managerSc;

    void Update()
    {
        if (butsActive)
        {
            toBut.interactable = true;

            if (neutralEra > 0)
            {
                backBut.interactable = true;
            }
            else
            {
                backBut.interactable = false;
            }

            if (referenceRoom.GetComponent<EraHolder>().currentEra is 2)
            {
                if (managerSc.sndWin is false)
                {
                    toBut.interactable = false;
                }
                else
                {
                    toBut.interactable = true;
                }
            }
            else
            {
                toBut.interactable = true;
            }
        }
        else
        {
            backBut.interactable = false;
            toBut.interactable = false;
        }

       
        //if room[0] era is 2 and 2nd win is false then disable a button

    }


}

