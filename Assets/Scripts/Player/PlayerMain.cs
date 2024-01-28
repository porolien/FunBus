using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMain : MonoBehaviour
{
    public PlayerInputs playerInputs;
    public PlayerMovement playerMovement;
    public PlayerInteract playerInteract;
    public PlateMain plateMain;
    public PlayerCam playercam;

    private void Start()
    {
        CustomerManager.Instance.playerMain = this;
    }
}
