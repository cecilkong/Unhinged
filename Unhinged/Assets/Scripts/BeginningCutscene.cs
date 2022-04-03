using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginningCutscene : MonoBehaviour
{
    GameObject inputManager;

    private void Start()
    {
        inputManager = FindObjectOfType<PanningInput>().gameObject;
        SetInputFalse();
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
