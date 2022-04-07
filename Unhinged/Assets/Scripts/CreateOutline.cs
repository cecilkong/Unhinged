using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateOutline : MonoBehaviour
{
    [SerializeField] Material interactableMat;
    [SerializeField] Material uninteractableMat;
    [SerializeField] Material defaultMat;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void setInactive()
    {
        spriteRenderer.material = defaultMat;
    }

    public void displayInteractable()
    {
        spriteRenderer.material = interactableMat;
    }

    public void displayuninteractable()
    {
        spriteRenderer.material = uninteractableMat;
    }
}
