using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ConsoleForBuild : MonoBehaviour
{
    bool showConsole;

    string input;

    PlayerInputs playerInput;

    [SerializeField]
    PlayerMovement _playerMovement;

    [SerializeField]
    PlateBalancerUI _plateBalancerUI;

    public static DebugCommand<int> SET_SPEED_CHARACTER;
    public static DebugCommand<int> SET_SPEED_GR;
    public static DebugCommand<int> SET_DELAY_TO_FALL_GR;
    public static DebugCommand<int> SET_DELAY_PATERN_P1_MIN_PR;
    public static DebugCommand<int> SET_DELAY_PATERN_P1_MAX_PR;
    public static DebugCommand<int> SET_DELAY_PATERN_P2_MIN_PR;
    public static DebugCommand<int> SET_DELAY_PATERN_P2_MAX_PR;
    public static DebugCommand<int> SET_SPEED_PATERN_P2_MAX_PR;
    public static DebugCommand<int> SET_SPEED_PATERN_P2_MIN_PR;
    public static DebugCommand<int> SET_SPEED_PATERN_P1_MAX_PR;
    public static DebugCommand<int> SET_SPEED_PATERN_P1_MIN_PR;

    public List<object> commandList;

    private void Awake()
    {
        SET_SPEED_CHARACTER = new DebugCommand<int>("set_speed_character", "change la speed du joueur", "set_speed <speed_amount>", (x) => 
        {
            _playerMovement.ConsoleChangeSpeed(x);
        });
        SET_SPEED_GR = new DebugCommand<int>("set_speed_gr", "change la speed du grand rectangle", "set_speed <speed_amount>", (x) =>
        {
            _plateBalancerUI.ConsoleChangeSpeedGR(x);
        });
        SET_DELAY_TO_FALL_GR = new DebugCommand<int>("set_delay_to_fall_gr", "change le délai avant que le grand rectangle ne chute", "set_delay <delay_account>", (x) =>
        {
            _plateBalancerUI.ConsoleChangeDelayGR(x);
        });
        SET_DELAY_PATERN_P1_MAX_PR = new DebugCommand<int>("set_delay_patern_p1_max_pr", "change le max de temps qu'il faut pour changer de patern sur le patern numéro 1 du petit rectangle", "set_delay_max <max_delay_account>", (x) =>
        {
            _plateBalancerUI.ConsoleChangeDelayMaxPRP1(x);
        });
        SET_DELAY_PATERN_P1_MIN_PR = new DebugCommand<int>("set_delay_patern_p1_min_pr", "change le min de temps qu'il faut pour changer de patern sur le patern numéro 1 du petit rectangle", "set_delay_min <min_delay_account>", (x) =>
        {
            _plateBalancerUI.ConsoleChangeDelayMinPRP1(x);
        });
        SET_DELAY_PATERN_P2_MAX_PR = new DebugCommand<int>("set_delay_patern_p2_max_pr", "change le max de temps qu'il faut pour changer de patern sur le patern numéro 2 du petit rectangle", "set_delay_max <max_delay_account>", (x) =>
        {
            _plateBalancerUI.ConsoleChangeDelayMaxPRP2(x);
        });
        SET_DELAY_PATERN_P2_MIN_PR = new DebugCommand<int>("set_delay_patern_p2_min_pr", "change le min de temps qu'il faut pour changer de patern sur le patern numéro 2 du petit rectangle", "set_delay_min <min_delay_account>", (x) =>
        {
            _plateBalancerUI.ConsoleChangeDelayMinPRP2(x);
        });
        SET_SPEED_PATERN_P2_MAX_PR = new DebugCommand<int>("set_speed_patern_p2_max_pr", "change le max de vitesse sur le patern numéro 2 du petit rectangle", "set_speed_max <max_speed_account>", (x) =>
        {
            _plateBalancerUI.ConsoleChangeSpeedMaxPRP2(x);
        });
        SET_SPEED_PATERN_P2_MIN_PR = new DebugCommand<int>("set_speed_patern_p2_min_pr", "change le min de vitesse sur le patern numéro 2 du petit rectangle", "set_speed_min <min_speed_account>", (x) =>
        {
            _plateBalancerUI.ConsoleChangeSpeedMinPRP2(x);
        });
        SET_SPEED_PATERN_P1_MAX_PR = new DebugCommand<int>("set_speed_patern_p1_max_pr", "change le max de vitesse sur le patern numéro 1 du petit rectangle", "set_speed_max <max_speed_account>", (x) =>
        {
            _plateBalancerUI.ConsoleChangeSpeedMaxPRP1(x);
        });
        SET_SPEED_PATERN_P1_MIN_PR = new DebugCommand<int>("set_speed_patern_p1_min_pr", "change le min de vitesse sur le patern numéro 1 du petit rectangle", "set_speed_min <min_speed_account>", (x) =>
        {
            _plateBalancerUI.ConsoleChangeSpeedMinPRP1(x);
        });
        commandList = new List<object>
        {
            SET_SPEED_CHARACTER,
            SET_SPEED_GR,
            SET_DELAY_TO_FALL_GR,
            SET_DELAY_PATERN_P1_MAX_PR,
            SET_DELAY_PATERN_P1_MIN_PR,
            SET_DELAY_PATERN_P2_MAX_PR,
            SET_DELAY_PATERN_P2_MIN_PR,
            SET_SPEED_PATERN_P1_MIN_PR,
            SET_SPEED_PATERN_P1_MAX_PR,
            SET_SPEED_PATERN_P2_MIN_PR,
            SET_SPEED_PATERN_P2_MAX_PR,
        };
    }
    /*private void Start()
    {
        Debug.Log("start");
        playerInput = GetComponent<PlayerInputs>();  
    }*/
    public void OnToggleDebug(InputValue value)
    {
        Debug.Log("con");
        showConsole = !showConsole;
    }

    public void OnReturn()
    {
        if (showConsole)
        {
            HandleInput();
            input = "";
        }
    }

    private void OnGUI()
    {
        if(!showConsole) { return; }
        float y = 0f;
        GUI.Box(new Rect(0, y, Screen.width, 30), "");
        GUI.backgroundColor = new Color(0, 0, 0, 0);
        input = GUI.TextField(new Rect(10f, y + 5f, Screen.width - 20f, 20f), input);
    }

    private void HandleInput()
    {
        Debug.Log("handle");
        string[] properties = input.Split(' ');

        for(int i = 0; i < commandList.Count; i++)
        {
            DebugCommandBase commandBase = commandList[i] as DebugCommandBase;

            if(input.Contains(commandBase.commandId))
            {
                if (commandList[i] as DebugCommand != null)
                {
                    (commandList[i] as DebugCommand).Invoke();
                }
                else if (commandList[i] as DebugCommand<int> != null)
                {
                    (commandList[i] as DebugCommand<int>).Invoke(int.Parse(properties[1]));
                }
            }
        }
    }
}
