using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class PlayerSwitch : MonoBehaviour
{


    public CinemachineVirtualCamera[] cameras;
    public CinemachineVirtualCamera MainCamera;
    public CinemachineVirtualCamera player2Camera;
    public CinemachineVirtualCamera startingCamera;
    private CinemachineVirtualCamera currrentCam;
    


    public player_controller playerController;
    public player_controller player2Controller;



    void Start()
    {
        player2Controller.enabled = false;
        currrentCam = startingCamera;

        for (int i = 0; i <cameras.Length; i ++)
        {
            if (cameras[i] == currrentCam)
            {
                cameras[i].Priority = 20;
            }
            else
            {
                cameras[i].Priority = 10;
            }


        }



    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchPlayer();
        }
    }


    public void SwitchCamera(CinemachineVirtualCamera newCam)
    {
        currrentCam = newCam;
        
        currrentCam.Priority = 20;

        for (int i = 0; i < cameras.Length; i ++)
        {
            if (cameras[i] != currrentCam)
            {
                cameras[i].Priority = 10;
            }
        }
    }


    public void SwitchPlayer()
    {


        if (playerController.enabled)
        {
            playerController.enabled = false;
            player2Controller.enabled = true;
            SwitchCamera(player2Camera);
        }
        else 
        {
            playerController.enabled = true;
            player2Controller.enabled = false;
            SwitchCamera(MainCamera);
        }
    }




}



