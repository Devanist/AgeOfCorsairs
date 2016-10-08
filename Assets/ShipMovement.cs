using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {

    private Rigidbody2D shipRigidBody2D;

    public float maxShipVelocity = 6;

    public  float shipVelocity = 0;
    public  float shipRotationAngle = 0;
    private float velocityChange;

    //w celu plynniejszego ruszania / zwalniania
    private bool speedUp = false;
    private bool slowDown = false;

    void Start() {
        shipRigidBody2D = GetComponent<Rigidbody2D>();
        velocityChange = (maxShipVelocity / 3) / 20;
    }

    void FixedUpdate() {

        if(speedUp) {
            Debug.Log("Wciskanie gory");

            if (shipVelocity < maxShipVelocity) {
                shipVelocity += velocityChange;
            }

        }
        else if(slowDown) {

            if(shipVelocity > -2) {
                shipVelocity -= velocityChange;
            }
            
        }

        shipRigidBody2D.velocity = new Vector2(0, shipVelocity);
        /*
        if (Input.GetKey(KeyCode.UpArrow)) {
            shipRigidBody2D.velocity = new Vector2(0, shipSpeed);
        }
        */
    }

    //Funkcje wywolywane w czasie nastapienia eventu zwiazanego ze sterowaniem dotykowym
    public void goForwardPressed() {
        speedUp = true;
    }

    public void goForwardReleased() {
        speedUp = false;
    }

    public void goBackwardPressed() {
        slowDown = true;
    }

    public void goBackwardReleased() {
        slowDown = false;
    }
}


