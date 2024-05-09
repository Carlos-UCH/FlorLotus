using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class PlayerSwitch : MonoBehaviour
{


    public CinemachineVirtualCamera[] cameras;
    public CinemachineVirtualCamera MainCamera;
    public CinemachineVirtualCamera player2Camera;
    public CinemachineVirtualCamera player3Camera;

    public CinemachineVirtualCamera startingCamera;
    private CinemachineVirtualCamera currrentCam;
    


    public player_controller playerController;
    public player_controller player2Controller;
     public player_controller player3Controller;
     
    private bool ver = false;



    void Start()
    {
        player2Controller.enabled = false;
        player3Controller.enabled = false;

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

        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            ver = true;

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


        if (ver && player3Controller.enabled == false)
        {
            playerController.enabled = false;
            player2Controller.enabled = false;
            player3Controller.enabled = true;
            SwitchCamera(player3Camera);

        }   
        else if (playerController.enabled &&  ver == false)
        {    
            playerController.enabled = false;
            player2Controller.enabled = true;
            player3Controller.enabled = false;
            ver = false;
            SwitchCamera(player2Camera);
        }
        else
        {
            playerController.enabled = true;
            player2Controller.enabled = false;
            player3Controller.enabled = false;
            ver = false;
            SwitchCamera(MainCamera);
        
        }
    }




}



