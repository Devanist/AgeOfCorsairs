using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ShipSpeedScript : MonoBehaviour
{
    public Rigidbody2D shipRigidBody2D;
    public double startingSpeed = 0;
    public double currentSpeed = 0;
    public Text currentSpeedText;

    private double oldSpeed;
    void Start ()
    {
        currentSpeed = startingSpeed;
    }

	void Update ()
    {
        double currentShipForce = ShipMovement.currentShipForce;
        currentSpeed = Math.Round(getCurrentSpeed(currentShipForce),2);
        currentSpeedText.text = Math.Round(currentSpeed, 2).ToString();
        SoundManager.instance.PlaySnailSound(currentSpeed);
        oldSpeed = currentSpeed;
    }

    private double getCurrentSpeed(double currentShipForce)
    {
        return currentShipForce/12.5;
    }
}

