using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeControl : MonoBehaviour
{
    public GameObject scrollBar;
	float scroll_pos = 0;
	float []pos;
	int posisi = 0;
	public static bool tutorial = false;
	public GameObject tutorialUI;

	void Start()
    {
		scroll_pos = scrollBar.GetComponent<Scrollbar>().value;
	}

	void Update()
	{
		pos = new float[transform.childCount];
		float distance = 1f / (pos.Length - 1f);
		for (int i = 0; i < pos.Length; i++)
		{
			pos[i] = distance * i;
		}

		if (Input.GetMouseButton(0))
		{
			scroll_pos = scrollBar.GetComponent<Scrollbar>().value;
		}
		else
		{
			for (int i = 0; i < pos.Length; i++)
			{
				if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
				{
					scrollBar.GetComponent<Scrollbar>().value =
						Mathf.Lerp(scrollBar.GetComponent<Scrollbar>().value, pos[i], 0.15f);
					posisi = i;
				}
			}
		}

	}

    public void Next()
    {
	    if (posisi < pos.Length - 1)
	    {
		    posisi += 1;
		    scroll_pos = pos[posisi];
	    }
    }

    public void Prev()
    {
	    if (posisi > 0)
	    {
		    posisi -= 1;
		    scroll_pos = pos[posisi];
	    }
    }
    
    public void LastNext()
    {
	    AudioController.PlaySFX("klik_menu");
	    tutorialUI.SetActive(false);
	    tutorial = false;
	    scroll_pos = pos[0];
    }
    
}
