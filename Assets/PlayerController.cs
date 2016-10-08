using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D shipRigidBody2D;

    public float shipSpeed = 7;
    public float shipForce = 1000;
    public float shipRotationAngle = 0;
	
    void Start() {
        shipRigidBody2D = GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void FixedUpdate () {
	    
        if( Input.GetKey(KeyCode.UpArrow) ) {
            shipRigidBody2D.velocity = new Vector2(shipSpeed, shipRigidBody2D.velocity.y);
        }

	}
}
