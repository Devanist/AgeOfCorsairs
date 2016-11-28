using UnityEngine;
using System.Collections;
using Assets.Enums;
using UnityEngine.UI;

public class ShipHealthScript : MonoBehaviour
{
    public const int MaxSideHealth = 50;

    public int maxHealth = 100;
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;

    private double oldHealthProcent;
    public int LeftSideHealth = MaxSideHealth;
    public int RightSideHealth = MaxSideHealth;


    void Awake()
    {
        healthSlider.maxValue = maxHealth;
        currentHealth = startingHealth;    
    }

    void Start()
    {

    }

    void Update()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        double healthProcent = ((double)currentHealth / (double)maxHealth) * 100;
        SoundManager.instance.BurnSound(healthProcent);
    }


    public void AddHealth(int health, ShipSide shipSide)
    {
        switch (shipSide)
        {
            case ShipSide.Left:
                LeftSideHealth += health;
                if (LeftSideHealth < 0)
                    LeftSideHealth = 0;

                if (LeftSideHealth > MaxSideHealth)
                    LeftSideHealth = MaxSideHealth;
                break;
            case ShipSide.Right:
                RightSideHealth += health;
                if (RightSideHealth < 0)
                    RightSideHealth = 0;

                if (RightSideHealth > MaxSideHealth)
                    RightSideHealth = MaxSideHealth;
                break;
        }

        currentHealth += health;
        if (currentHealth < 0)
            currentHealth = 0;

        if (currentHealth > 100)
            currentHealth = 100;

    }
}
