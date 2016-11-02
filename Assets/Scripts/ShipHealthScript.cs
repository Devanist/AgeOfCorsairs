using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipHealthScript : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;

    void Awake()
    {
        currentHealth = startingHealth;
    }

    void Start ()
    {
	
	}
	
	void Update ()
    {
        healthSlider.value = currentHealth;
    }
}
