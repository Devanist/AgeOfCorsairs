using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipHealthScript : MonoBehaviour
{
    public int maxHealth = 100;
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;

    private double oldHealthProcent;
    void Awake()
    {
        healthSlider.maxValue = maxHealth;
        currentHealth = startingHealth;    
    }

    void Start ()
    {
	
	}
	
	void Update ()
    {
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
        double healthProcent = ((double)currentHealth / (double)maxHealth) * 100;
        SoundManager.instance.BurnSound(healthProcent);
    }
}
