using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public float interactionRadius;
    [SerializeField]
    private LayerMask mechLayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnInteract()
    {
        Collider[] mechs = Physics.OverlapSphere(transform.position, interactionRadius, mechLayer);
        foreach (var mech in mechs)
        {
            Mechanism m = mech.GetComponent<Mechanism>();
            if (m != null && m.IsInteractable())
            {
                if (!m.IsActivated())
                {
                    m.Activate();
                }
                else
                {
                    m.DeActivate();
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
