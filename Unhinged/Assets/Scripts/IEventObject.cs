using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEventObject
{
    public bool GetInteractable();
    public void Interact();
    public void SetUp();
}
