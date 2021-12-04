using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : BaseMech
{
    public Material activeMaterial;
    public Material deactiveMaterial;
    public Renderer buttonRenderer;

    private void Start()
    {
        if (buttonRenderer == null)
        {
            buttonRenderer = GetComponent<Renderer>();
        }

        ChangeMaterial(IsActivated());
    }

    public override void Activate()
    {
        base.Activate();
        ChangeMaterial(IsActivated());
    }

    private void ChangeMaterial(bool isActive)
    {
        if (isActive)
        {
            buttonRenderer.material = activeMaterial;
        }
        else
        {
            buttonRenderer.material = deactiveMaterial;
        }
    }

    public override void DeActivate()
    {
        base.DeActivate();
        ChangeMaterial(IsActivated());
    }
}
