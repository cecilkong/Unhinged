using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CutsceneEvent : MonoBehaviour, IEventObject
{
    [SerializeField] bool interactable = false;
    [SerializeField] GameObject nextEvent;
    GameObject inputManager;
    [SerializeField] TextMeshProUGUI textObject;
    [SerializeField] string dialogue;
    bool dialogueActive = false;

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

    private void ConfirmDialogue()
    {
        if (dialogueActive)
        {
            nextEvent.GetComponent<IEventObject>().SetUp();
            GetComponent<Animator>().SetTrigger("Play");
            dialogueActive = false;
            textObject.transform.parent.gameObject.SetActive(false);
        }
    }

    private IEnumerator shortTimer()
    {
        yield return new WaitForSeconds(.1f);
        dialogueActive = true;
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
