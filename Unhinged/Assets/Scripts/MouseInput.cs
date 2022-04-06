using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    GameObject hoveringOver;
    [SerializeField] Camera mainCam;
    public bool canInput = true;
    void Update()
    {
        if (!canInput) return;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
        if (hoveringOver != null && hoveringOver.GetComponent<CreateOutline>())
        {
            hoveringOver.GetComponent<CreateOutline>().setInactive();
        }
        if (hit.collider != null){
            
            hoveringOver = hit.transform.gameObject;
            if (hit.collider.GetComponent<IEventObject>().GetInteractable())
            {
                if (hoveringOver.GetComponent<CreateOutline>()) { hit.transform.GetComponent<CreateOutline>().displayInteractable(); }
                if (Input.GetMouseButtonDown(0))
                {
                    hit.collider.GetComponent<IEventObject>().Interact();
                }
            }
            else
            {
                if(hoveringOver.GetComponent<CreateOutline>()) hit.transform.GetComponent<CreateOutline>().displayuninteractable();
            }
        }
    }
}
