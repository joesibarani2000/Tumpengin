using System.Collections;
using UnityEngine;

public class FoodSpawnerManager : MonoBehaviour
{
    public static FoodSpawnerManager Instance;

    [SerializeField] string[] foodObject;
    [SerializeField] private float startDelay;
    [SerializeField] private float delaySpawn;
    [SerializeField] private int totalFood;
    [SerializeField] private Transform rollingTable;
    [SerializeField] private Transform[] spawner;
    public int maxSpawnFood;

    private void Start()
    {
        Instance = this;
    }

    public void StartSpawning()
    {
        totalFood = maxSpawnFood / spawner.Length;
        StartCoroutine(SpawnDelay());
    }
    
    IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(startDelay);

        for (int i = 0; i < totalFood; i++)
        {
            foreach (Transform spawnPos in spawner) {
                FoodSpawner.Instance.CreateFoodInstance(foodObject[Random.Range(0, foodObject.Length)], spawnPos, rollingTable, false);
            }
            yield return new WaitForSeconds(delaySpawn);
        }
    }

    public void RandomSpawn(string name)
    {
        FoodSpawner.Instance.CreateFoodInstance(name, spawner[Random.Range(0, spawner.Length)], rollingTable, false);
    }

}