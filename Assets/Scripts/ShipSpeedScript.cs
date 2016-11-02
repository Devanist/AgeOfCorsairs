using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class ShipSpeedScript : MonoBehaviour
{
    public Rigidbody2D shipRigidBody2D;
    public float startingSpeed = 0;
    public float currentSpeed;
    public Text currentSpeedText;

    private Vector2 oldShipPos;


    void Start ()
    {
        currentSpeed = startingSpeed;
        oldShipPos = shipRigidBody2D.position;
    }
	
	void Update ()
    {
        Vector2 shipPos= shipRigidBody2D.position;
        if (shipPos.x != oldShipPos.x || shipPos.y != oldShipPos.y)
        {
            currentSpeed = getCurrentSpeed(shipPos, oldShipPos);
        }
        currentSpeedText.text = Math.Round(currentSpeed,2).ToString();
        oldShipPos = shipPos;
    }

    private float getCurrentSpeed(Vector2 shipPos, Vector2 oldShipPos)
    {
        return distanceBetweenPoints(shipPos, oldShipPos) * 60;
    }

    private float distanceBetweenPoints(Vector2 A, Vector2 B)
    {
        return (float)Math.Sqrt((B.x - A.x) * (B.x - A.x) + (B.y - A.y) * (B.y - A.y));
    }
}

