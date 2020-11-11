using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mousemovement : MonoBehaviour
{
    private Vector2 mouseposition;
    [SerializeField] private Camera camera;
    private bool drag;
    [SerializeField] private GameObject food;
    [SerializeField] private Sprite dragPointer;
    [SerializeField] private Sprite normalPointer;
    // Start is called before the first frame update
    void Start()
    {
        drag = false;
    }

    // Update is called once per frame
    void Update()
    {
        mouseposition = camera.ScreenToWorldPoint(Input.mousePosition);

        transform.position = mouseposition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("food"))
        {
            if(food == null)
            {
                food = collision.gameObject;
                drag = true;
            }
            
        }
    }

    private void OnMouseDrag()
    {
        if (drag == true && food != null)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = dragPointer;
            food.transform.position = transform.position;
        }
    }

    private void OnMouseUp()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = normalPointer;
        food.GetComponent<Food>().SendFoodData();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        drag = false;
        food = null;
        
    }


}
