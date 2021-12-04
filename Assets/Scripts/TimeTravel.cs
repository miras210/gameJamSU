using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TimeTravel : MonoBehaviour
{
    [SerializeField]
    private CharacterController _controller;

    private List<Vector3> positions;
    
    public bool isRewinding = false;
    // Start is called before the first frame update
    void Start()
    {
        positions = new List<Vector3>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (isRewinding)
            Rewind();
        else
        {
            Record();
        }
    }

    void Rewind()
    {
        if (positions.Count > 0)
        {
            transform.position = positions[positions.Count - 1];
            positions.RemoveAt(positions.Count-1);
        }
        else
        {
            StopRewind();
        }
    }

    void Record()
    {
        if (positions.Count > Mathf.Round(2f / Time.fixedDeltaTime))
        {
            positions.RemoveAt(0);
        }
        positions.Add(transform.position);
    }

    void OnRewind(InputValue value)
    {
        StartRewind();
    }

    public void StartRewind()
    {
        isRewinding = true;
    }

    public void StopRewind()
    {
        isRewinding = false;
    }
}
