using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControll : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera camera1;
    [SerializeField] CinemachineVirtualCamera camera2;
    [SerializeField] CinemachineVirtualCamera camera3;
    [SerializeField] CinemachineVirtualCamera camera4;
    [SerializeField] CinemachineVirtualCamera camera5;
    [SerializeField] CinemachineVirtualCamera camera6;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            camera1.Priority = +1;
            camera2.Priority=10;
            camera3.Priority=10;
            camera4.Priority=10;
            camera5.Priority=10;
            camera6.Priority=10;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            camera2.Priority = +1;
            camera1.Priority = 10;
            camera3.Priority = 10;
            camera4.Priority = 10;
            camera5.Priority = 10;
            camera6.Priority = 10;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            camera3.Priority = +1;
            camera1.Priority = 10;
            camera2.Priority = 10;
            camera4.Priority = 10;
            camera5.Priority = 10;
            camera6.Priority = 10;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            camera4.Priority = +1;
            camera1.Priority = 10;
            camera2.Priority = 10;
            camera3.Priority = 10;
            camera5.Priority = 10;
            camera6.Priority = 10;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            camera5.Priority = +1;
            camera1.Priority = 10;
            camera2.Priority = 10;
            camera3.Priority = 10;
            camera4.Priority = 10;
            camera6.Priority = 10;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            camera6.Priority = +1;
            camera1.Priority = 10;
            camera2.Priority = 10;
            camera3.Priority = 10;
            camera4.Priority = 10;
            camera5.Priority = 10;
            
        }

    }
}
