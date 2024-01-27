using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ConsoleForBuild : MonoBehaviour
{
    bool ShowConsole;

    string input;

    PlayerInput playerInput;

    private void Start()
    {
        Debug.Log("start");
        playerInput = GetComponent<PlayerInput>();  
    }
    public void OnToggleDebug()
    {
        Debug.Log("con");
        ShowConsole = !ShowConsole;
    }

    private void OnGUI()
    {
        if(!ShowConsole) { return; }
        float y = 0f;
        GUI.Box(new Rect(0, y, Screen.width, 30), "");
        GUI.backgroundColor = new Color(0, 0, 0, 0);
        input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), input);
    }
}
