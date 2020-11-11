using UnityEngine;

public class FoodContentBuilder : MonoBehaviour
{
    [SerializeField] private FoodRestricUpgradable foodUpgradable;

    [SerializeField] private SpriteRenderer nasiKuning;
    [SerializeField] private SpriteRenderer[] ayam;
    [SerializeField] private SpriteRenderer[] ikan;
    [SerializeField] private SpriteRenderer[] telurIris;
    [SerializeField] private SpriteRenderer lalapan;
    [SerializeField] private SpriteRenderer urap;
    [SerializeField] private SpriteRenderer[] telurRebus;
    [SerializeField] private SpriteRenderer sambalMatah;
    [SerializeField] private SpriteRenderer[] perkedel;


    public void PlaceFood(FoodData foodData)
    {
        
        if (foodData.name == "Nasi Kuning")
        {
            nasiKuning.gameObject.transform.localPosition = foodUpgradable.Upgrade(foodData.name);
            nasiKuning.sprite = foodData.image[foodUpgradable.GetLevel(foodData.name)];
        }

        if (foodData.name == "Ikan")
        {
            foreach (SpriteRenderer i in ikan)
            {
                if (!i.sprite)
                {
                    i.sprite = foodData.image[0];
                    break;
                }
            }
        }

        if (foodData.name == "Telur Iris")
        {
            foreach (SpriteRenderer i in telurIris)
            {
                if (!i.sprite)
                {
                    i.sprite = foodData.image[0];
                    break;
                }
            }
        }

        if (foodData.name == "Telur Mentah")
        {
            foreach (SpriteRenderer i in telurRebus)
            {
                if (!i.sprite)
                {
                    i.sprite = foodData.image[0];
                    break;
                }
            }
        }

        if (foodData.name == "Urap")
        {
            urap.gameObject.transform.localPosition = foodUpgradable.Upgrade(foodData.name);
            urap.sprite = foodData.image[foodUpgradable.GetLevel(foodData.name)];
        }

        if (foodData.name == "Lalapan")
        {
            lalapan.gameObject.transform.localPosition = foodUpgradable.Upgrade(foodData.name);
            lalapan.sprite = foodData.image[foodUpgradable.GetLevel(foodData.name)];
        }

        if (foodData.name == "Ayam")
        {
            foreach (SpriteRenderer i in ayam)
            {
                if (!i.sprite)
                {
                    i.sprite = foodData.image[0];
                    break;
                }
            }
        }

        if (foodData.name == "Sambal Matah")
        {
            sambalMatah.sprite = foodData.image[0];
        }


        if (foodData.name == "Perkedel")
        {
            foreach (SpriteRenderer i in perkedel)
            {
                if (!i.sprite)
                {
                    i.sprite = foodData.image[0];
                    break;
                }
            }
        }

    }
}
