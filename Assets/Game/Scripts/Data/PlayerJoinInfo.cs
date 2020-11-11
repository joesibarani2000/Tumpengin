using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerJoinInfo : MonoBehaviour
{
    [SerializeField] private PlayerData[] data;

    private List<PlayerJoinData> listQueue = new List<PlayerJoinData>();
    private List<PlayerJoinData> playerJoins = new List<PlayerJoinData>();

    private void Start()
    {
        InitQueue();
    }

    void InitQueue()
    {
        for (int i = 0; i<4; i++)
        {
            PlayerJoinData data = new PlayerJoinData(i + 1);
            listQueue.Add(data);
        }
    }

    public bool CheckIsPlayerJoined(int index)
    {
        return playerJoins.Any(e => e.controllerIndex == index);
    }

    public void PlayerJoin(int index)
    {
        PlayerJoinData dataSelect = listQueue[0];
        dataSelect.controllerIndex = index;
        playerJoins.Add(dataSelect);
        listQueue.Remove(dataSelect);
    }

    public bool IsPlayerHasJoin(int index)
    {
        return playerJoins.Any(e=> e.controllerIndex == index);
    }

    public List<PlayerJoinData> GetPlayerJoinData()
    {
        return playerJoins;
    }

    public int CountPlayerJoinData()
    {
        return playerJoins.Count;
    }

    public int GetPlayerindex(int index)
    {
        return playerJoins.First(e => e.controllerIndex == index).playerIndex;
    }

    public PlayerData GetPlayerData(int index)
    {
        return data[index];
    }
}

[System.Serializable]
public class PlayerJoinData
{
    public string playerName;
    public int playerIndex;
    public int controllerIndex;

    public PlayerJoinData(int index)
    {
        playerIndex = index-1;
        playerName = "Player" + index;
        controllerIndex = 0;
    }
}
