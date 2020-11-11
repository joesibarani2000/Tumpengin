using UnityEngine;

public class ControllerData : MonoBehaviour
{
    public struct InputDataController
    {
        public KeyCode[] action;
        public KeyCode[] start;
        public KeyCode[] confirm;
    }

    private static ControllerData instance;

    private InputDataController control;

    public static KeyCode KeyCode_Action(int controllerID)
    {
        return instance.keyCode_Action(controllerID);
    }

    public static KeyCode KeyCode_Confirm(int controllerID)
    {
        return instance.keyCode_Confirm(controllerID);
    }

    public static KeyCode KeyCode_Start(int controllerID)
    {
        return instance.keyCode_Start(controllerID);
    }

    public static float GetXAxis(int controllerID)
    {
        return instance.getXAxis(controllerID);
    }

    public static float GetYAxis(int controllerID)
    {
        return instance.getYAxis(controllerID);
    }


    private void Start()
    {
        Init();
    }

    void Init()
    {
        if (instance == null)
        {
            instance = this;

            InitializeInput();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void InitializeInput()
    {
        control.action = new KeyCode[5];
        control.confirm = new KeyCode[5];
        control.start = new KeyCode[5];

        control.action[0] = KeyCode.JoystickButton2;
        control.action[1] = KeyCode.Joystick1Button2;
        control.action[2] = KeyCode.Joystick2Button2;
        control.action[3] = KeyCode.Joystick3Button2;
        control.action[4] = KeyCode.Joystick4Button2;

        control.confirm[0] = KeyCode.JoystickButton1;
        control.confirm[1] = KeyCode.Joystick1Button1;
        control.confirm[2] = KeyCode.Joystick2Button1;
        control.confirm[3] = KeyCode.Joystick3Button1;
        control.confirm[4] = KeyCode.Joystick4Button1;

        control.start[0] = KeyCode.JoystickButton7;
        control.start[1] = KeyCode.Joystick1Button7;
        control.start[2] = KeyCode.Joystick2Button7;
        control.start[3] = KeyCode.Joystick3Button7;
        control.start[4] = KeyCode.Joystick4Button7;
    }

    KeyCode keyCode_Action(int controllerID)
    {
        return instance.control.action[controllerID];
    }

    KeyCode keyCode_Confirm(int controllerID)
    {
        return instance.control.confirm[controllerID];
    }

    KeyCode keyCode_Start(int controllerID)
    {
        return instance.control.start[controllerID];
    }

    float getXAxis(int controllerID)
    {
        return Input.GetAxis("Horizontal" + controllerID);
    }

    float getYAxis(int controllerID)
    {
        return Input.GetAxis("Vertical" + controllerID);
    }
}
