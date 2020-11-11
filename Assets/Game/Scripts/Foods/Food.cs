using DG.Tweening;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private FoodData foodData;
    [SerializeField] private Sprite piringPecah;

    private SmallTableServe activeMejaKecil;
    private CharacterBehaviour playerWhoHoldThis;
    private SpriteRenderer renderer;

    private bool inRollingTable;

    private void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        inRollingTable = true;
    }

    private void Update()
    {
        if (inRollingTable) AdjustingRotation();
    }

    private void AdjustingRotation()
    {
        transform.localEulerAngles = -transform.parent.localEulerAngles;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.gameObject.CompareTag("meja kecil"))
        {
            activeMejaKecil = collision.gameObject.GetComponent<SmallTableServe>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("meja kecil"))
        {
            activeMejaKecil = null;
        }
    }

    public void SetFoodData(FoodData newData)
    {
        foodData = newData;
    }

    public void SendFoodData()
    {
        if (activeMejaKecil != null && foodData.name != "Special")
        {
            if (playerWhoHoldThis.GetPlayerData() == activeMejaKecil.GetOwner())
            {
                if (!activeMejaKecil.SetFoodData(this))
                {
                    DOTween.Sequence()
                        .AppendCallback(() => Falling())
                        .AppendInterval(0.5f)
                        .OnComplete(() => Destroy(gameObject));
                    FoodSpawnerManager.Instance.RandomSpawn(foodData.name);
                }
            }
            else
            {
                DOTween.Sequence()
                    .AppendCallback(() => Falling())
                    .AppendInterval(0.5f)
                    .OnComplete(() => Destroy(gameObject));
                FoodSpawnerManager.Instance.RandomSpawn(foodData.name);
            }
        }
        else
        {
            DOTween.Sequence()
                .AppendCallback(() => Falling())
                .AppendInterval(0.5f)
                .OnComplete(() => Destroy(gameObject));
            FoodSpawnerManager.Instance.RandomSpawn(foodData.name);
        }
        
    }

    public void GrabFood(CharacterBehaviour data)
    {
        if (playerWhoHoldThis == null)
        {
            renderer.sortingLayerName = "FoodDrag";
            transform.GetChild(0).GetComponent<SpriteRenderer>().sortingLayerName = "FoodDrag";
            inRollingTable = false;
            playerWhoHoldThis = data;
        } else if (playerWhoHoldThis != data)
        {
            renderer.sortingLayerName = "FoodDrag";
            transform.GetChild(0).GetComponent<SpriteRenderer>().sortingLayerName = "FoodDrag";
            inRollingTable = false;
            playerWhoHoldThis.ReleaseFood();
            playerWhoHoldThis = data;
        }
    }

    public bool IsHold()
    {
        return playerWhoHoldThis;
    }

    private void Falling()
    {
        AudioController.PlaySFX("pecah");
        renderer.sprite = piringPecah;
    }

    public FoodData GetFoodData()
    {
        return foodData;
    }
}
