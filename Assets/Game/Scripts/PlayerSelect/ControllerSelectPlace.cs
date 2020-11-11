using DG.Tweening;
using UnityEngine;

public class ControllerSelectPlace : MonoBehaviour
{
    public float sensitivity;

    private bool wasPlace;
    private Vector3 direction;

    [SerializeField] private GameObject pointerCursor;
    [SerializeField] private int controllerIndex;
    [SerializeField] private PlayerHolder activePlayerHolder;
    [SerializeField] private SpriteRenderer cursor;
    [SerializeField] private CharacterBehaviour characterInfo;

    private void Start()
    {
        wasPlace = false;
    }

    void Update()
    {
        if (GameVariables.GAME_START)
        {
            StartTheGame();
            return;
        }
        ControlMove();
        Action();
        Ready();
    }

    public void SetPlayerInfo(PlayerData playerData, PlayerJoinData data)
    {
        controllerIndex = data.controllerIndex;
        cursor.sprite = playerData.normalCursor;
    }

    void ControlMove()
    {
        direction = new Vector3(InputData.GetXAxis(controllerIndex), InputData.GetYAxis(controllerIndex), 0.0f);
        pointerCursor.transform.position = pointerCursor.transform.position + direction * Time.deltaTime * sensitivity;
    }

    void Action()
    {
        if (Input.GetKeyDown(InputData.KeyCode_Action(controllerIndex)))
        {
            cursor.sprite = characterInfo.GetPlayerData().dragCursor;

            if (!wasPlace && activePlayerHolder)
            {
                if (activePlayerHolder.player == null)
                {
                    wasPlace = true;
                    activePlayerHolder.SetPlayer(characterInfo);
                    gameObject.transform.parent = activePlayerHolder.transform;
                    gameObject.transform.position = Vector2.zero;
                    activePlayerHolder.Hover(false);
                    UIManager.Instance.PlayerJoins(characterInfo.GetPlayerIndex());
                }
            }
        }

        if (Input.GetKeyUp(InputData.KeyCode_Action(controllerIndex)))
        {
            cursor.sprite = characterInfo.GetPlayerData().normalCursor;
        }
    }

    void Ready()
    {
        if (activePlayerHolder != null && wasPlace && Input.GetKeyDown(InputData.KeyCode_Start(characterInfo.GetControllerIndex())))
        {
            if (MultiplayerManagement.Instance.Ready(characterInfo.GetPlayerIndex()))
            {
                GameVariables.GAME_START = true;
                GameManagement.Instance.StartingTheGame();
            }
        }
    }

    void StartTheGame()
    {
        this.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Table"))
        {
            if (!wasPlace)
            {
                activePlayerHolder = collision.GetComponent<PlayerHolder>();
                activePlayerHolder.Hover(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Table"))
        {
            if (!wasPlace)
            {
                activePlayerHolder.Hover(false);
                activePlayerHolder = null;
            }
        }
    }
}
