using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOutline : MonoBehaviour
{
    [SerializeField] Color interactableColor;
    [SerializeField] Color uninteractableColor;
    [SerializeField] Sprite square;
    [SerializeField] float maskScaleMultiplier = 1.1f;
    GameObject mask;
    GameObject outline;

    private void Start()
    {
        Sprite objSprite = GetComponent<SpriteRenderer>().sprite;
        mask = new GameObject();
        mask.AddComponent<SpriteMask>().sprite = objSprite;
        mask.transform.SetParent(transform);
        mask.transform.localPosition = Vector3.zero;
        mask.transform.localScale *= maskScaleMultiplier;
        mask.SetActive(false);


        outline = new GameObject();
        outline.transform.SetParent(transform);
        outline.AddComponent<SpriteRenderer>().sprite = square;
        outline.GetComponent<SpriteRenderer>().maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        outline.transform.localPosition = Vector3.zero;
        outline.GetComponent<SpriteRenderer>().sortingOrder -= 1;
        outline.transform.localScale *= 50;
        outline.SetActive(false);
    }

    public void setInactive()
    {
        mask.SetActive(false);
        outline.SetActive(false);
    }

    public void displayInteractable()
    {
        mask.SetActive(true);
        outline.SetActive(true);
        outline.GetComponent<SpriteRenderer>().color = interactableColor;
    }

    public void displayuninteractable()
    {
        mask.SetActive(true);
        outline.SetActive(true);
        outline.GetComponent<SpriteRenderer>().color = uninteractableColor;
    }
}
