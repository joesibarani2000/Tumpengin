using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    [SerializeField] private FoodSpawnerManager spawnerManager;
    private int currentIndex;
    private int totalActiveFood;
    public static GameManagement Instance;

    [SerializeField] private ScoreboardManager scoreboardmanager;

    [System.Serializable]
    public struct PlayerJoinStage
    {
        public int playerCount;
        [System.Serializable]
        public struct StatesInfo
        {
            public string name;
            public int totalFoodSpawn;
        }
        public StatesInfo[] statesInfo;
    }

    [SerializeField] private PlayerJoinStage[] playerJoinStage;

    private void Start()
    {
        TransitionManager.Instance.FadeOut(null);
        AudioController.PlayBGM("main_game", PlayType.AUTO,true);
        Instance = this;
    }

    //Update
    public void StartingTheGame()
    {


        foreach (PlayerHolder holder in MultiplayerManagement.Instance.GetPlayerHolder())
        {
            holder.GetPlaceHolderContentBuilder().UpdateCursor();
        }
        startTheStage();
    }

    public void nextStage()
    {
        currentIndex++;
        PlayerJoinStage data = playerJoinStage.First(e => e.playerCount == MultiplayerManagement.Instance.GetPlayersActive().Count);

        if (currentIndex < data.statesInfo.Length)
        {
            MultiplayerManagement.Instance.PlayerRotation();
            startTheStage();
        }
        else
        {
            GameVariables.GAME_OVER = true;
            scoreboardmanager.ActiveScore();
        }
    }

    public void startTheStage()
    {
        UIManager.Instance.TriggerStageText("Stage "+ (currentIndex + 1));
        PlayerJoinStage data = playerJoinStage.First(e => e.playerCount == MultiplayerManagement.Instance.GetPlayersActive().Count);

        totalActiveFood = data.statesInfo[currentIndex].totalFoodSpawn;
        spawnerManager.maxSpawnFood = data.statesInfo[currentIndex].totalFoodSpawn;
        spawnerManager.StartSpawning();
    }

    public void decrementFood()
    {
        totalActiveFood--;
        if(totalActiveFood == 0)
        {
            nextStage();
        }
    }

    public int GetSpawnTotal()
    {
        PlayerJoinStage data = playerJoinStage.First(e => e.playerCount == MultiplayerManagement.Instance.GetPlayersActive().Count);

        return data.statesInfo[currentIndex].totalFoodSpawn / MultiplayerManagement.Instance.GetPlayersActive().Count;
    }
}
