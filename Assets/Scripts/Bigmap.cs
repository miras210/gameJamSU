using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Bigmap : MonoBehaviour
{

    public RawImage map;

    private bool showMap;
    // Start is called before the first frame update
    void Start()
    {
        showMap = false;
        map.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnBigmap(InputValue value)
    {
        if (showMap)
        {
            map.gameObject.SetActive(false);
            showMap = false;
        }
        else
        {
            map.gameObject.SetActive(true);
            showMap = true;
        }
    }
}
