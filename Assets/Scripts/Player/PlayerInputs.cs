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
}