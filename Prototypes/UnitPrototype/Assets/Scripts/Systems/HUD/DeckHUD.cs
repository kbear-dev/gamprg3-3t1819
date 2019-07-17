using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckHUD : MonoBehaviour
{
    public RectTransform selector;
    public List<RectTransform> slots;

    public Sprite EmptyCardSprite;

    private int selectedSlot;

    // Start is called before the first frame update
    void Start()
    {
        selectedSlot = 0;
        selector.position = slots[selectedSlot].position;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeSelectorPosition();
    }

    private void ChangeSelectorPosition ()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            if (selectedSlot == slots.Count - 1)
            {
                selectedSlot = 0;
                return;
            }

            selectedSlot++;
            
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
           if (selectedSlot == 0)
            {
                selectedSlot = slots.Count - 1;
                return;
            }

            selectedSlot--;
        }

        selector.position = slots[selectedSlot].position;
    }
}
