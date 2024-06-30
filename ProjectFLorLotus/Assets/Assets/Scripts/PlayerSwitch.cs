using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Drone;


public class PlayerSwitch : MonoBehaviour
{


    public CinemachineVirtualCamera[] cameras;
    public CinemachineVirtualCamera MainCamera;
    public CinemachineVirtualCamera player2Camera;

    public CinemachineVirtualCamera startingCamera;
    private CinemachineVirtualCamera currrentCam;



    public CommonPlayer playerController;
    public CommonPlayer player2Controller;



    void Start()
    {
        player2Controller.enabled = false;

        currrentCam = startingCamera;

        for (int i = 0; i < cameras.Length; i++)
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
        if (playerController.tag == "DeadPlayer")
        {
            SwitchCamera(player2Camera);
            player2Controller.enabled = true;
        }
        else if (player2Controller == null)
        {
            SwitchCamera(MainCamera);
            playerController.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchPlayer();
        }
        playerController.BarModifiers();
        player2Controller.BarModifiers();
        playerController.EnergyRecovery();
        player2Controller.EnergyRecovery();
        playerController.AudioController();
        player2Controller.AudioController();
        
    }


    public void SwitchCamera(CinemachineVirtualCamera newCam)
    {
        currrentCam = newCam;

        currrentCam.Priority = 20;

        for (int i = 0; i < cameras.Length; i++)
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
            GameObject.Find("FOV").GetComponent<PlayerFOV>().enabled = false;
            SwitchCamera(player2Camera);
        }
        else
        {
            playerController.enabled = true;
            player2Controller.enabled = false;
            GameObject.Find("FOV").GetComponent<PlayerFOV>().enabled = true;
            SwitchCamera(MainCamera);

        }
    }
}



