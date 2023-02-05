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
        }
        else
        {
            backBut.interactable = false;
            toBut.interactable = false;
        }
    }


}

