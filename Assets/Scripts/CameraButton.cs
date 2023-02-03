using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraButton : MonoBehaviour
{
    public CameraSwitcher switchSc;
    public CameraZoom cazoo;
    public int myNum;

    public void OnMouseDown()
    {
        switchSc.cameraNum = myNum;
        cazoo.DoOnce = true;
    }


}
