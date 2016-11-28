using UnityEngine;
using System.Collections;
using Assets.Enums;

public class ShipCollisionScript : MonoBehaviour
{
    public GameObject ShipLeftSideShootingArrow;
    public GameObject ShipRightSideShootingArrow;


    private ShipHealthScript _shipHealthScript;

    // Use this for initialization
    void Start()
    {
        _shipHealthScript = GetComponent<ShipHealthScript>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "Mortar Bullet")
        {
            if (collider.transform.position.x < transform.position.x
                && transform.rotation.z >= -0.90
                && transform.rotation.z <= 0.90)
            {
                _shipHealthScript.AddHealth(-5,ShipSide.Left);

                if(_shipHealthScript.LeftSideHealth==0)
                    ShipLeftSideShootingArrow.SetActive(false);
            }
            else if (collider.transform.position.x < transform.position.x
               && (transform.rotation.z < -0.90 || transform.rotation.z > 0.90))
            {
                _shipHealthScript.AddHealth(-5, ShipSide.Right);

                if (_shipHealthScript.RightSideHealth == 0)
                    ShipRightSideShootingArrow.SetActive(false);
            }
        }
    }


}
