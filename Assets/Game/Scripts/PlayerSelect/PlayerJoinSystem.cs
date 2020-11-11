using UnityEngine;
using UnityEngine.UI;

public class PlayerJoinSystem : MonoBehaviour
{
    [SerializeField]private PlayerJoinInfo joinInfo;
    public bool useController;

    private void Start()
    {
        UIManager.Instance.EnablePlayerJoinUI(true);
        GameVariables.GAME_START = false;
    }

    // Update is called once per frame
    void Update()
    {
        JoinController();
        StartGame();
    }

    void JoinController()
    {
        int index = 0;

        if (useController) index = DetectIndexController();
        else index = DetectIndexKeyboard();

        if (index != 0)
        {
            if (!joinInfo.CheckIsPlayerJoined(index))
            {
                joinInfo.PlayerJoin(index);
                UIManager.Instance.PlayerJoins(joinInfo.GetPlayerindex(index));
            }
            else
            { 
                Debug.Log("player sudah join");
            }
        }
    }

    void StartGame()
    {
        if (Input.GetKeyDown(InputData.KeyCode_Start(0)))
        {
            if (joinInfo.CountPlayerJoinData() > 1)
            {
                MultiplayerManagement.Instance.SpawnSystem();
                this.enabled = false;
            } else
            {
                Debug.Log("Must be at least 2 players join the game");
            }
        }
    }

    private int DetectIndexController()
    {
        if (Input.GetKeyDown(InputData.KeyCode_Confirm(1))) return 1;
        else if (Input.GetKeyDown(InputData.KeyCode_Confirm(2))) return 2;
        else if (Input.GetKeyDown(InputData.KeyCode_Confirm(3))) return 3;
        else if (Input.GetKeyDown(InputData.KeyCode_Confirm(4))) return 4;
        else return 0;
    }
    private int DetectIndexKeyboard()
    {
        if (Input.GetKeyDown(KeyCode.A)) return 1;
        else if (Input.GetKeyDown(KeyCode.W)) return 2;
        else if (Input.GetKeyDown(KeyCode.S)) return 3;
        else if (Input.GetKeyDown(KeyCode.D)) return 4;
        else return 0;
    }
}
