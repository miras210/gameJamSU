using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Mechanism
{
    public void Activate();
    public void DeActivate();
    public bool IsActivated();
    public bool IsInteractable();
}
