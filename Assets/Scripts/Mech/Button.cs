using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, Mechanism
{
    public LayerMask targetLayer;

    public float reachRadius;

    public bool activated = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        activated = true;
    }

    public void DeActivate()
    {
        activated = false;
    }

    public bool IsActivated()
    {
        return activated;
    }

    public bool IsInteractable()
    {
        return true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, reachRadius);
    }
}
