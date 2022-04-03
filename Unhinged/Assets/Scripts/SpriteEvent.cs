using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpriteEvent : MonoBehaviour, IEventObject
{
    [SerializeField] bool interactable = false;
    [SerializeField] GameObject nextEvent;
    [SerializeField] Sprite alteredSprite;
    [SerializeField] TextMeshProUGUI textObject;
    [SerializeField] string dialogue;
    bool dialogueActive = false;
    GameObject inputManager;

    private void Start()
    {
        inputManager = FindObjectOfType<PanningInput>().gameObject;
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            ConfirmDialogue();
        }
    }

    public void Interact()
    {
        interactable = false;
        textObject.transform.parent.gameObject.SetActive(true);
        textObject.text = dialogue;
        SetInputFalse();
        StartCoroutine(shortTimer());
    }

    private IEnumerator shortTimer()
    {
        yield return new WaitForSeconds(.1f);
        dialogueActive = true;
    }

    private void ConfirmDialogue()
    {
        if (dialogueActive)
        {
            GetComponent<SpriteRenderer>().sprite = alteredSprite;
            nextEvent.GetComponent<IEventObject>().SetUp();
            SetInputTrue();
            dialogueActive = false;
            textObject.transform.parent.gameObject.SetActive(false);
        }
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
