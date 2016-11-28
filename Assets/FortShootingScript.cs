using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;

public class FortShootingScript : MonoBehaviour {

    private Renderer _renderer;
    private CircleCollider2D _rangeCollider;
    private bool shouldFire;
    private float lastShootTime;
    private float lastMortarShootTime;
    private GameObject PlayerShip;
    private Vector3 lastPlayerPosition;
    private GameObject _mt;

    public GameObject MortarTarget;
    public GameObject Bullet;
    public float MortarFactor = 180.0f;
    public float FiringSpeed = 5.0f;
    public float FiringMortarSpeed = 8.0f;
    List<GameObject> _bullets = new List<GameObject>();
    List<GameObject> _mortarBullets = new List<GameObject>();

// Use this for initialization
void Start () {
        _renderer = GetComponent<Renderer>();
        _rangeCollider = GetComponent<CircleCollider2D>();
        PlayerShip = GameObject.Find("Ship");
        shouldFire = false;
        lastShootTime = 0.0f;
        lastMortarShootTime = 0.0f;

        _mt = Instantiate(MortarTarget);
        _mt.SetActive(false);

        for (int i = 0; i < 3; i++) {
            var bullet = Instantiate(Bullet);
            bullet.SetActive(false);
            _bullets.Add(bullet);
        }

        for(int i = 0; i < 5; i++) {
            var bullet = Instantiate(Bullet);
            bullet.SetActive(false);
            _mortarBullets.Add(bullet);
        }

    }
	
	// Update is called once per frame
	void Update () {
	    if(shouldFire == true && Time.time - lastShootTime > FiringSpeed) {
            lastShootTime = Time.time;
            Fire();
        }
        if(shouldFire == true && Time.time - lastMortarShootTime > FiringMortarSpeed) {
            lastMortarShootTime = Time.time;
            MortarFire();
        }
        lastPlayerPosition = new Vector3(PlayerShip.transform.position.x, PlayerShip.transform.position.y, PlayerShip.transform.position.z);
	}

    //Wystrzał z moździerza, kule spadają z góry ekranu w miejsce, w które gracz może wpłynąć w następnej chwili.
    private void MortarFire() {
        Vector3 bulletStartPosition;
        Vector3 bulletTargetPosition;
        Vector3 playerPosition = PlayerShip.transform.position;

        float[] shootingOffsetX = { -0.2f, -0.1f, 0, 0.2f, 0.1f };
        float[] shootingOffsetY = { -0.2f, 0.1f, 0, 0.2f, -0.3f };

        for (int i = 0; i < 5; i++) {

            if (!_mortarBullets[i].activeInHierarchy) {
                var bulletMoveScript = _mortarBullets[i].GetComponent<MortarBulletMoveScript>();
                bulletMoveScript.MortarTarget = _mt;
                bulletStartPosition = new Vector3(playerPosition.x - 3.0f, playerPosition.y - 8.0f, -10.1f);

                bulletTargetPosition = new Vector3(
                    playerPosition.x + (playerPosition.x - lastPlayerPosition.x) * MortarFactor + shootingOffsetX[i], 
                    playerPosition.y + (playerPosition.y - lastPlayerPosition.y) * MortarFactor + shootingOffsetY[i], 
                    playerPosition.z
                );

                Debug.Log((playerPosition.x - lastPlayerPosition.x) * MortarFactor);
                Debug.Log((playerPosition.y - lastPlayerPosition.y) * MortarFactor);

                if(i == 2) {
                    bulletMoveScript.isCentral = true;
                };

                _mt.SetActive(true);
                _mt.transform.position = bulletTargetPosition;                

                _mortarBullets[i].transform.position = bulletStartPosition;
                bulletMoveScript.TargetPosition = bulletTargetPosition;

                _mortarBullets[i].SetActive(true);
                SoundManager.instance.CannonFire();
            }

        }

    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(this.tag == "Enemy Island") {
            shouldFire = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider) {
        shouldFire = false;
    }

    //Wystrzał z dział
    private void Fire() {

        Vector3 bulletStartPosition;
        Vector3 bulletTargetPosition;

        Vector3 playerPosition = PlayerShip.transform.position;

        float[] shootingOffset = { -0.2f, 0, 0.2f };

        for(int i = 0; i < 3; i++) {

            if (!_bullets[i].activeInHierarchy) {
                var bulletMoveScript = _bullets[i].GetComponent<MortarBulletMoveScript>();

                bulletStartPosition = new Vector3(transform.position.x + shootingOffset[i], transform.position.y + shootingOffset[i], transform.position.z);

                //Osobna referencja na wypadek gdybyśmy chcieli strzelać przed gracza
                bulletTargetPosition = playerPosition;
                bulletTargetPosition.x += shootingOffset[i];
                bulletTargetPosition.y += shootingOffset[i];

                _bullets[i].transform.position = bulletStartPosition;

                bulletMoveScript.TargetPosition = bulletTargetPosition;
                _bullets[i].SetActive(true);
                SoundManager.instance.CannonFire();
            }

        }

    }
}
