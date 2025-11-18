using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OrderedUnlockGate : MonoBehaviour
{
    [SerializeField] List<OrderedUnlockButton> orderedButtons;
    int numButtons;
    List<OrderedUnlockButton> pressedOrder;
    Vector3 startPosition;
    Vector3 endPosition;
    [SerializeField] SpriteRenderer[] symbols;
    int currPressed = 0;

    void Start()
    {
        pressedOrder = new List<OrderedUnlockButton>();
        numButtons = orderedButtons.Count;
        startPosition = transform.position;
        endPosition = new Vector3(startPosition.x, startPosition.y + 5, startPosition.z);
    }

    public void AddButton(OrderedUnlockButton pressedButton)
    {
        symbols[currPressed].color = pressedButton.startColor;
        pressedOrder.Add(pressedButton);
        currPressed++;
        ButtonPressed();
    }

    private void ButtonPressed()
    {
        if (pressedOrder.Count == numButtons)
        {
            int matches = 0;
            for (int i = 0; i < numButtons; i++)
            {
                if (orderedButtons[i] == pressedOrder[i])
                {
                    matches++;
                }
            }
            if (matches == numButtons)
            {
                Raise();
            }
            else
            {
                foreach (OrderedUnlockButton button in pressedOrder)
                {
                    button.ResetButton();
                }
                foreach (SpriteRenderer symbol in symbols)
                {
                    symbol.color = Color.white;
                }
                pressedOrder.Clear();
                currPressed = 0;
            }
        }
    }

    public void Raise()
    {
        transform.position = endPosition;
    }
}
