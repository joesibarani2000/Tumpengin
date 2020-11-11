using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputData : MonoBehaviour
{
    public struct InputDataController
    {
        public KeyCode[] action;
        public KeyCode[] start;
        public KeyCode[] confirm;

        public struct Movement
        {
            public KeyCode left;
            public KeyCode right;
            public KeyCode up;
            public KeyCode down;
        }

        public Movement[] movement;
    }

    private static InputData instance;

    private InputDataController control;

    public static KeyCode KeyCode_Action(int controllerID)
    {
        return ControllerData.KeyCode_Action(controllerID);
    }

    public static KeyCode KeyCode_Confirm(int controllerID)
    {
        return ControllerData.KeyCode_Confirm(controllerID);
    }

    public static KeyCode KeyCode_Start(int controllerID)
    {
        return ControllerData.KeyCode_Start(controllerID);
    }

    public static float GetXAxis(int controllerID)
    {
        return ControllerData.GetXAxis(controllerID);
    }

    public static float GetYAxis(int controllerID)
    {
        return ControllerData.GetYAxis(controllerID);
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
        control.movement = new InputDataController.Movement[5];

        control.action[0] = KeyCode.Q;
        control.action[1] = KeyCode.Q;
        control.action[2] = KeyCode.R;
        control.action[3] = KeyCode.U;
        control.action[4] = KeyCode.RightShift;

        control.confirm[0] = KeyCode.E;
        control.confirm[1] = KeyCode.E;
        control.confirm[2] = KeyCode.Y;
        control.confirm[3] = KeyCode.O;
        control.confirm[4] = KeyCode.Keypad0;

        control.start[0] = KeyCode.X;
        control.start[1] = KeyCode.X;
        control.start[2] = KeyCode.B;
        control.start[3] = KeyCode.M;
        control.start[4] = KeyCode.RightControl;

        control.movement[0].up = KeyCode.W;
        control.movement[1].up = KeyCode.W;
        control.movement[2].up = KeyCode.T;
        control.movement[3].up = KeyCode.I;
        control.movement[4].up = KeyCode.UpArrow;

        control.movement[0].down = KeyCode.S;
        control.movement[1].down = KeyCode.S;
        control.movement[2].down = KeyCode.G;
        control.movement[3].down = KeyCode.K;
        control.movement[4].down = KeyCode.DownArrow;

        control.movement[0].left = KeyCode.A;
        control.movement[1].left = KeyCode.A;
        control.movement[2].left = KeyCode.F;
        control.movement[3].left = KeyCode.J;
        control.movement[4].left = KeyCode.LeftArrow;

        control.movement[0].right = KeyCode.D;
        control.movement[1].right = KeyCode.D;
        control.movement[2].right = KeyCode.H;
        control.movement[3].right = KeyCode.L;
        control.movement[4].right = KeyCode.RightArrow;
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
        if (Input.GetKey(control.movement[controllerID].left)) return -1;
        if (Input.GetKey(control.movement[controllerID].right)) return 1;
        return 0;
    }

    float getYAxis(int controllerID)
    {
        if (Input.GetKey(control.movement[controllerID].up)) return 1;
        if (Input.GetKey(control.movement[controllerID].down)) return -1;
        return 0;
    }
}
