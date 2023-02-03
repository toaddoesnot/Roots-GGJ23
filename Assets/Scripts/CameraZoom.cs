using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    [SerializeField] float maxCameraDistance; //
    CinemachineComponentBase componentBase;
    float cameraDistance;
    [SerializeField] float sensitivity = 10f;
    public CameraSwitcher switchSc;

    public GameObject[] vcams;
    public bool DoOnce;

    public void Start()
    {
        
        //virtualCamera.LookAt = holyM;
        //virtualCamera.Follow = holyM;
    }

    // Update is called once per frame
    void Update()
    {
        virtualCamera = vcams[switchSc.cameraNum].GetComponent<CinemachineVirtualCamera>();

        if (componentBase == null)
        {
            componentBase = virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
            maxCameraDistance = (componentBase as CinemachineFramingTransposer).m_CameraDistance;
        }
        
        if (DoOnce is true)
        {
            componentBase = virtualCamera.GetCinemachineComponent(CinemachineCore.Stage.Body);
            maxCameraDistance = (componentBase as CinemachineFramingTransposer).m_CameraDistance;
            DoOnce = false;
        }
       

        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            print("scrolling");
            cameraDistance = Input.GetAxis("Mouse ScrollWheel") * sensitivity;

            if(componentBase is CinemachineFramingTransposer)
            {
                if (cameraDistance < 0)
                {
                    (componentBase as CinemachineFramingTransposer).m_CameraDistance -= cameraDistance;
                    if ((componentBase as CinemachineFramingTransposer).m_CameraDistance > maxCameraDistance)
                    {
                        (componentBase as CinemachineFramingTransposer).m_CameraDistance = maxCameraDistance;
                    }
                }
                else
                {
                    (componentBase as CinemachineFramingTransposer).m_CameraDistance -= cameraDistance;
                    if ((componentBase as CinemachineFramingTransposer).m_CameraDistance < 2)
                    {
                        (componentBase as CinemachineFramingTransposer).m_CameraDistance = 2;
                    }
                }

                   // (componentBase as CinemachineFramingTransposer).m_CameraDistance -= cameraDistance;
            }

        }
    }
}
