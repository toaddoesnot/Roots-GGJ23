using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    public GameObject[] cams;
    public int cameraNum;

    public void Update()
    {
        foreach (GameObject cam in cams)
        {
            cam.SetActive(false);
            cams[cameraNum].SetActive(true);
        }
    }

}
