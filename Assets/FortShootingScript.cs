using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class FortShootingScript : MonoBehaviour {

    private Renderer _renderer;
    private CircleCollider2D _rangeCollider;
    private bool shouldFire;
    private float lastShootTime;
    private GameObject PlayerShip;

    public GameObject Bullet;
    public float FiringSpeed = 5.0f;
    List<GameObject> _bullets = new List<GameObject>();

// Use this for initialization
void Start () {
        _renderer = GetComponent<Renderer>();
        _rangeCollider = GetComponent<CircleCollider2D>();
        PlayerShip = GameObject.Find("Ship");
        shouldFire = false;
        lastShootTime = 0.0f;

        for (int i = 0; i < 3; i++) {
            var bullet = Instantiate(Bullet);
            bullet.SetActive(false);
            _bullets.Add(bullet);
        }
    }
	
	// Update is called once per frame
	void Update () {
	    if(shouldFire == true && Time.time - lastShootTime > FiringSpeed) {
            Debug.Log("firing!");
            lastShootTime = Time.time;
            Fire();
        }
	}

    void OnTriggerEnter2D(Collider2D collider) {
        if(this.tag == "Enemy Island") {
            shouldFire = true;
            Debug.Log("trigger");
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        shouldFire = false;
    }

    private void Fire() {

        Vector3 bulletStartPosition;
        Vector3 bulletTargetPosition;        

        Vector3 playerPosition = PlayerShip.transform.position;

        for(int i = 0; i < 3; i++) {

            if (!_bullets[i].activeInHierarchy) {
                var bulletMoveScript = _bullets[i].GetComponent<BulletMoveScript>();

                bulletStartPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

                //Osobna referencja na wypadek gdybyśmy chcieli strzelać przed gracza
                bulletTargetPosition = playerPosition;

                _bullets[i].transform.position = bulletStartPosition;

                bulletMoveScript.TargetPosition = bulletTargetPosition;
                _bullets[i].SetActive(true);
            }

        }

    }
}
