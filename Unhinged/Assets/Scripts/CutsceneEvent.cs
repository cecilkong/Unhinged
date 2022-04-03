using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneEvent : MonoBehaviour, IEventObject
{
    [SerializeField] bool interactable = false;
    [SerializeField] GameObject nextEvent;
    GameObject inputManager;

    private void Start()
    {
        inputManager = FindObjectOfType<PanningInput>().gameObject;
    }

    public void Interact()
    {
        interactable = false;
        nextEvent.GetComponent<IEventObject>().SetUp();
        GetComponent<Animator>().SetTrigger("Play");
        SetInputFalse();
    }

    public void SetUp()
    {
        interactable = true;
    }

    public bool GetInteractable()
    {
        return interactable;
    }

    public void SetInputFalse()
    {
        inputManager.GetComponent<PanningInput>().canInput = false;
        inputManager.GetComponent<MouseInput>().canInput = false;
    }

    public void SetInputTrue()
    {
        inputManager.GetComponent<PanningInput>().canInput = true;
        inputManager.GetComponent<MouseInput>().canInput = true;
    }
}
