using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{

    PlayerInput _playerInput;
    PlayerMain _playerMain;
    void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerMain = GetComponent<PlayerMain>();
        _playerMain.playerInputs = this;
    }

    public void OnMovement(InputValue value)
    {
        _playerMain.playerMovement.Move(value.Get<Vector3>());
    }

    public void OnInteract()
    {
        _playerMain.playerInteract.Interact();
    }

    public void OnStabilize()
    {
        _playerMain.plateMain.plateBalancer.IsStabilized();
    }

    public void OnSwapSelection(InputValue value)
    {
        int directionSelected = 1;
        if(value.Get<Vector2>().y != 0)
        {
            if (value.Get<Vector2>().y < 0)
            {
                directionSelected = -1;
            }
            _playerMain.plateMain.plateInventory.SelectASelectable(directionSelected);
        }
    }

    public void OnDrop()
    {
        _playerMain.plateMain.plateInventory.DropSelectedProbs();
    }
}
