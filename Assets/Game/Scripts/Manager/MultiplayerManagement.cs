using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MultiplayerManagement : MonoBehaviour
{
    [SerializeField] PlayerHolder []playerHolder;
    
    public GameObject player;
    public Transform parentPlayer;
    public PlayerJoinInfo playerJoinInfo;

    public static MultiplayerManagement Instance;

    private bool[] playerReady;

    private List<CharacterBehaviour> playersActive;

    void Start()
    {
        Instance = this;
    }
    
    public void PlayerRotation()
    {
        int j;
        CharacterBehaviour last;
        last = playerHolder[playerHolder.Length - 1].player;
        for (j = playerHolder.Length - 1; j > 0; j--)
        {
            playerHolder[j].player = playerHolder[j - 1].player;
            if (playerHolder[j].player != null)
            {
                playerHolder[j].player.transform.parent = playerHolder[j].transform;
                playerHolder[j].player.transform.localPosition = Vector3.zero;
            }
            playerHolder[j].GetPlaceHolderContentBuilder().UpdateContent();
        }

        playerHolder[0].player = last;
        if (playerHolder[0].player != null)
        {
            playerHolder[0].player.transform.parent = playerHolder[0].transform;
            playerHolder[0].player.transform.localPosition = Vector3.zero;
        }
        playerHolder[0].GetPlaceHolderContentBuilder().UpdateContent();

    }

    private void SpawnCharacter(PlayerJoinData playerJoinData)
    {
        CharacterBehaviour character = Instantiate(player, parentPlayer).GetComponent<CharacterBehaviour>();
        character.Initialize(playerJoinInfo.GetPlayerData(playerJoinData.playerIndex), playerJoinData);
        character.gameObject.GetComponent<ControllerSelectPlace>().SetPlayerInfo(playerJoinInfo.GetPlayerData(playerJoinData.playerIndex), playerJoinData);
        character.gameObject.GetComponent<CharacterCursorController>().SetPlayerInfo(playerJoinData);

        playersActive.Add(character);
    }

    public void SpawnSystem()
    {
        playersActive = new List<CharacterBehaviour>();
        List<PlayerJoinData> temp = playerJoinInfo.GetPlayerJoinData();
        playerReady = new bool[temp.Count];
            
        for (int i = 0; i < temp.Count; i++)
        {
            SpawnCharacter(temp[i]);
            UIManager.Instance.selectTables(i);
           
        }
    }

    public bool Ready(int playerIndex)
    {
        playerReady[playerIndex] = true;
        bool isAllReady = !playerReady.Any(e => e == false);
        if (isAllReady) UIManager.Instance.EnablePlayerJoinUI(false);
        return isAllReady;
    }

    public List<CharacterBehaviour> GetPlayersActive()
    {
        return playersActive;
    }

    public PlayerHolder[] GetPlayerHolder()
    {
        return playerHolder;
    }
}
