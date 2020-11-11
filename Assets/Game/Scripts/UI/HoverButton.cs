using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverButton : MonoBehaviour, IPointerEnterHandler
{
    // Start is called before the first frame update
   public void OnPointerEnter(PointerEventData eventData)
    {
        
        AudioController.PlaySFX("Button_Select");
    }
}
