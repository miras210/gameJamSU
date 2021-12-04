using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TimeTravel : MonoBehaviour
{
    [SerializeField]
    private CharacterController _controller;

    [SerializeField] private PlayerMovement _movement;

    [SerializeField] private GameObject _tracePrefab;
    [SerializeField] private LineRenderer _traceLine;

    private List<Vector3> positions;
    
    private bool isRewinding = false;

    public float cooldownTime = 8f;

    private float nextRewindTime;
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
        SpawnTraceLine();
    }

    private void SpawnTraceLine()
    {
        _traceLine.positionCount = positions.Count;
        _traceLine.SetPositions(positions.ToArray());
    }

    void SpawnTrace(Vector3 tracePosition)
    {
        _tracePrefab.transform.position = tracePosition;
        
        // Instantiate(_tracePrefab, tracePosition, transform.rotation);
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
            nextRewindTime = Time.time + cooldownTime;
            StopRewind();
        }
    }

    void Record()
    {
        if (positions.Count > Mathf.Round(2f / Time.fixedDeltaTime))
        {
            SpawnTrace(positions[0]);
            positions.RemoveAt(0);
        }
        positions.Add(transform.position);
    }

    void OnRewind(InputValue value)
    {
        if (Time.time < nextRewindTime)
        {
            StopRewind();
        }
        else
        {
            StartRewind();
        }
    }

    public void StartRewind()
    {
        _movement.Movable = false;
        _movement._direction = Vector3.zero;
        isRewinding = true;
    }

    public void StopRewind()
    {
        _movement.Movable = true;
        isRewinding = false;
    }
}