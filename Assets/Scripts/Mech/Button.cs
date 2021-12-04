using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, Mechanism
{
    public LayerMask targetLayer;

    public float reachRadius;
    public bool timed = false;
    public float timer;
    public bool activated = false;
    public bool interactable = true;

    private Renderer _renderer;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Activate()
    {
        if (!activated)
        {
            activated = true;
            Debug.Log("Activated");
            _renderer.material.color = Color.green;
            if (timed)
            {
                StartCoroutine(ActivatedRoutine());
            }
        }
    }

    IEnumerator ActivatedRoutine()
    {
        interactable = false;
        yield return new WaitForSeconds(timer);
        DeActivate();
        interactable = true;
    }

    public void DeActivate()
    {
        if (activated)
        {
            activated = false;
            _renderer.material.color = Color.red;
        }
    }

    public bool IsActivated()
    {
        return activated;
    }

    public bool IsInteractable()
    {
        return interactable;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, reachRadius);
    }
}
