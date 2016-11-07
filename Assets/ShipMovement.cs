using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {

    private Rigidbody2D shipRigidBody2D;

    public  static float currentShipForce = 0;
    public  float maxShipForce     = 100;
    public  float shipTurnPower    = 1.5f;
    public  float forceChange;

    //public float maxShipVelocity = 6;
    //public float shipVelocity = 0;
    //public  float shipRotationAngle = 0;
    //private float velocityChange;

    //w celu plynniejszego ruszania / zwalniania
    private bool speedUp     = false;
    private bool slowDown    = false;
    private bool rotateLeft  = false;
    private bool rotateRight = false;

    void Start() {
        shipRigidBody2D = GetComponent<Rigidbody2D>();
        //shipRigidBody2D.centerOfMass = new Vector3(0, -0.5f, 0);
        forceChange = (maxShipForce / 3) / 20;
    }

    void FixedUpdate() {

        if(speedUp) {

            if (currentShipForce < maxShipForce) {
                currentShipForce += forceChange;

            }

        }
        else if(slowDown) {

            if( currentShipForce > - (maxShipForce / 5) ) {
                currentShipForce -= forceChange;
            }
            
        }

        if(rotateLeft) {
            transform.Rotate(Vector3.forward * shipTurnPower);

        }

        if(rotateRight) {
            transform.Rotate(Vector3.forward * -shipTurnPower);

        }

        //shipRigidBody2D.MoveRotation(4);
        shipRigidBody2D.AddForce(transform.up * currentShipForce);
        //shipRigidBody2D.velocity = new Vector2(0, shipVelocity);
        //shipRigidBody2D.AddForce(transform.up);
        //shipRigidBody2D.
        //shipRigidBody2D.MoveRotation(4);
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

    public void rotateLeftPressed() {
        rotateLeft = true;
    }

    public void rotateLeftReleased() {
        rotateLeft = false;
    }

    public void rotateRightPressed() {
        rotateRight = true;
    }

    public void rotateRightReleased() {
        rotateRight = false;
    }

}


