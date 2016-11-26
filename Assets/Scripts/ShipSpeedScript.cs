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

    private Vector2 oldShipPos;


    void Start ()
    {
        currentSpeed = startingSpeed;
        oldShipPos = shipRigidBody2D.position;
    }

	void Update ()
    {
        Vector2 shipPos = shipRigidBody2D.position;
        if (shipPos.x != oldShipPos.x || shipPos.y != oldShipPos.y)
        {
            double currentShipForce = ShipMovement.currentShipForce;
            currentSpeed = getCurrentSpeed(currentShipForce);
        }
        currentSpeedText.text = Math.Round(currentSpeed, 2).ToString();
        oldShipPos = shipPos;
    }

    private double getCurrentSpeed(double currentShipForce)
    {
        return currentShipForce/12.5;
    }
}

