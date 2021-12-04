using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMech : MonoBehaviour, Mechanism
{
    [SerializeField]
    public BaseMech[] chainedMechanisms;
    public bool timed = false;
    public float timer;
    public bool activated = false;
    public bool interactable = true;
    public bool activateChainedMechanismsTogether;

    public bool forceActivationMode = false;

    public virtual void Activate()
    {
        if (!activated)
        {
            activated = true;
            //_renderer.material.color = Color.green;
            if (activateChainedMechanismsTogether)
            {
                ActivateChainedMechanisms();
            }
            if (timed)
            {
                StartCoroutine(ActivatedRoutine());
            }
        }
    }

    private void ActivateChainedMechanisms()
    {
        foreach (var cm in chainedMechanisms)
        {
           cm.Activate(); 
        }
    }

    IEnumerator ActivatedRoutine()
    {
        interactable = false;
        yield return new WaitForSeconds(timer);
        DeActivate();
        interactable = true;
    }

    public virtual void DeActivate()
    {
        if (activated)
        {
            activated = false;
        }
        DeActivateChainedMechanisms();
    }
    
    private void DeActivateChainedMechanisms()
    {
        foreach (var cm in chainedMechanisms)
        {
            cm.DeActivate(); 
        }
    }

    public bool IsActivated()
    {
        return activated;
    }

    public bool IsInteractable()
    {
        if (forceActivationMode)
        {
            return false;
        }
        return interactable;
    }

    
}
