using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCursorController : MonoBehaviour
{
    private float sensitivity;
    private Vector3 direction;
    [SerializeField] private bool drag, hold, clickFlag;
    [SerializeField] private CharacterBehaviour characterInfo;
    [SerializeField] private int controllerIndex;
    [SerializeField] private GameObject food;
    [SerializeField] private Sprite dragPointer;
    [SerializeField] private Sprite normalPointer;
    [SerializeField] private GameObject cursor;
    [SerializeField] private float sensitivityDasar;
    [SerializeField, Range(0f, 1f)] private float debuffMove;
    private SpriteRenderer cursorRender;

    void Update()
    {
        if (GameVariables.GAME_OVER) return;
        movement();
        pressx();
        follow(hold);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hold && food) return;
        if (collision.gameObject.CompareTag("food"))
        {
            hold = false;
            if (food != collision.gameObject)
            {
                food = collision.gameObject;
                drag = true;
            }

        }
    }

    public void SetPointerImage(PlayerData data)
    {
        dragPointer = data.dragCursor;
        normalPointer = data.normalCursor;
    }

    public void SetPlayerInfo(PlayerJoinData data)
    {
        sensitivity = sensitivityDasar;
        cursorRender = cursor.GetComponent<SpriteRenderer>();
        controllerIndex = data.controllerIndex;
    }

    public void movement()
    {
        direction = new Vector3(InputData.GetXAxis(controllerIndex), InputData.GetYAxis(controllerIndex), 0.0f);
        transform.position = transform.position + direction * Time.deltaTime * sensitivity;
    }

//kiminosei kiminosei
    public void pressx()
    {
        if (drag == true && food != null && Input.GetKeyDown(InputData.KeyCode_Action(controllerIndex)))
        {
            clickFlag = !clickFlag;

            if (clickFlag)
            {
                AudioController.PlaySFX("grab");
                sensitivity = sensitivityDasar * debuffMove;
                cursorRender.sprite = dragPointer;
                hold = true;
                food.GetComponent<Food>().GrabFood(characterInfo);
                food.transform.parent = null;
            }
            else
            {
                AudioController.PlaySFX("throw");
                sensitivity = sensitivityDasar;
                cursorRender.sprite = normalPointer;
                hold = false;

                Food activeFood = food?.GetComponent<Food>();

                if (food != null && activeFood.GetFoodData().name == "Special" && characterInfo.GetLastFood())
                {
                    activeFood.SetFoodData(characterInfo.GetLastFood());
                }

                activeFood?.SendFoodData();
            }
            
        }
    }

    public void ForceRelease()
    {
        sensitivity = sensitivityDasar;
        cursorRender.sprite = normalPointer;
        hold = false;
        clickFlag = false;
    }

    public void follow(bool inHold)
    {
        if(inHold && food!=null) food.transform.position = cursor.transform.position;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("food") && !hold)
        {
            if (food == collision.gameObject) {
                drag = false;
                food = null;
            }
        }
    }
}
