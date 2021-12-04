using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{

    public Image abilityImage1;

    [SerializeField]
    public TimeTravel TimeTravel;
    
    private float cooldown1;

    private bool isCooldown = false;
    // Start is called before the first frame update
    void Start()
    {
        abilityImage1.fillAmount = 0;
        cooldown1 = TimeTravel.cooldownTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCooldown)
        {
            abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;

            if (abilityImage1.fillAmount <= 0)
            {
                abilityImage1.fillAmount = 0;
                isCooldown = false;
            }
        }
    }

    void OnRewind(InputValue value)
    {
        if (!isCooldown)
        {
            isCooldown = true;
            abilityImage1.fillAmount = 1;
        }
    }
}
