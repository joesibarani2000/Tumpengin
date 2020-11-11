using System.Linq;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    
    [System.Serializable]
    public struct ObjectFood
    {
        public string name;
        public GameObject foodObject;
    }

    private static FoodSpawner instance;
    public static FoodSpawner Instance { get { return instance; } }

    private void Start()
    {
        instance = this;
    }

    [SerializeField] private ObjectFood[] prefabs;

    public Food CreateFoodInstance(string name, Transform transform, Transform parent = null, bool usingRotationTransform = true)
    {
        Food item = Instantiate(GetPrefabs(name), transform.position, usingRotationTransform ? transform.rotation : Quaternion.identity).GetComponent<Food>();
        item.transform.parent = parent;

        return item;
    }

    private GameObject GetPrefabs(string objectName)
    {
        return prefabs.First(e=> e.name == objectName).foodObject;
    }
}
