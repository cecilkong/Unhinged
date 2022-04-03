using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeRecipeEvent : MonoBehaviour, IEventObject
{
    [SerializeField] bool interactable;
    int ingredients = 0;
    [SerializeField] int ingredientAmount = 5;

    public void Interact()
    {

    }

    public void SetUp()
    {
        ingredients++;
        if (ingredients == ingredientAmount) interactable = true;
    }

    public bool GetInteractable()
    {
        return interactable;
    }
}
