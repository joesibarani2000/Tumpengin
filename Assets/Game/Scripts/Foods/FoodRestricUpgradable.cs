using System.Linq;
using UnityEngine;

public class FoodRestricUpgradable : MonoBehaviour
{
    [System.Serializable]
    public struct FoodUpgradableData
    {
        public int index;
        public string name;
        public int currentLevel;
        public Vector3[] offsetPositionLocal;
    }

    [SerializeField] private FoodUpgradableData[] foodUpgradable;

    public Vector3 Upgrade(string name)
    {
        if (IsAny(name))
        {
            int index = foodUpgradable.First(e => e.name == name).index;
            foodUpgradable[index].currentLevel++;

            int maxUpgradeable = foodUpgradable[index].offsetPositionLocal.Length;
            int positionIndex = foodUpgradable[index].currentLevel - 1;
            Debug.Log(positionIndex);
            return foodUpgradable[index].offsetPositionLocal[(positionIndex < maxUpgradeable) ? positionIndex : maxUpgradeable - 1];
        }
        else
        {
            Debug.Log("Data Upgradable Not Found");
            return Vector3.zero;
        }
    }

    public int GetLevel(string name)
    {
        if (IsAny(name))
        {
            int index = foodUpgradable.First(e => e.name == name).index;
            if ((foodUpgradable[index].currentLevel - 1) < foodUpgradable[index].offsetPositionLocal.Length) return foodUpgradable[index].currentLevel - 1;
            else return foodUpgradable[index].offsetPositionLocal.Length - 1;

        }
        else
        {
            Debug.Log("Data Upgradable Not Found");
            return -1;
        }
    }

    public bool IsAny(string name)
    {
        return foodUpgradable.Any(e => e.name == name);
    }
}
