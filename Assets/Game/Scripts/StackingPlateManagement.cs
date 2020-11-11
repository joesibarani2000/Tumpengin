using System.Collections.Generic;
using UnityEngine;

public class StackingPlateManagement : MonoBehaviour
{
    [SerializeField] private Vector3 offsetPlacement;
    [SerializeField] private Vector3 offsetStacking;
    [SerializeField] private float maksimumStack;

    public void UpdateStack(List<GameObject> foodDatas)
    {
        for (int i = 0; i < foodDatas.Count; i++)
        {
            foodDatas[i].transform.parent = transform;
            
            if (i < maksimumStack)
            {
                foodDatas[i].GetComponent<SpriteRenderer>().sortingOrder = i;
                foodDatas[i].transform.GetChild(0).gameObject.SetActive(false);
                foodDatas[i].transform.localPosition = offsetPlacement + (i * offsetStacking);

                foodDatas[i].GetComponent<SpriteRenderer>().sortingLayerName = "Plate";
                foodDatas[i].GetComponent<SpriteRenderer>().sortingOrder = i;
            }
            else
            {
                foodDatas[i].transform.position = Vector2.zero;
                foodDatas[i].SetActive(false);
            }
        }
    }
}
