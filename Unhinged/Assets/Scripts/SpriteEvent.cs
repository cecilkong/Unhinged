using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteEvent : MonoBehaviour, IEventObject
{
    [SerializeField] bool interactable = false;
    [SerializeField] GameObject nextEvent;
    [SerializeField] Sprite alteredSprite;

    public void Interact()
    {
        interactable = false;
        nextEvent.GetComponent<IEventObject>().SetUp();
        GetComponent<SpriteRenderer>().sprite = alteredSprite;

    }

    public void SetUp()
    {
        interactable = true;
    }

    public bool GetInteractable()
    {
        return interactable;
    }
}
