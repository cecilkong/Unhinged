using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    public bool canInput = true;
    void Update()
    {
        if (!canInput) return;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
        if (hit.collider != null){
            if (hit.collider.GetComponent<IEventObject>().GetInteractable())
            {
                //show interactable outline
                if (Input.GetMouseButtonDown(0))
                {
                    hit.collider.GetComponent<IEventObject>().Interact();
                }
            }
            else
            {
                //show non-interact thing
            }
        }
    }
}
