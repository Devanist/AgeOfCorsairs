using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Assets.Enums;
using Debug = UnityEngine.Debug;

public class ShipShootingScript : MonoBehaviour
{
    private Renderer _renderer;
    private List<GameObject> _bullets;
    private float _shipHeight;
    private float _shipWidth;
    private int _activeCannonAmmount;
    private CannonOrientation _cannonOrientation;

    public float Range = 4f;
    public GameObject Bullet;
    public ShootingPosition ShootingPosition = ShootingPosition.Left;
    public int RightCannonAmount = 4;
    public int LeftCannonAmount = 4;
    public int FrontCannonAmount = 2;
    public int BackCannonAmount = 2;

    // Use this for initialization
    void Start()
    {
        _renderer = GetComponent<Renderer>();

        _shipHeight = _renderer.bounds.size.y;
        _shipWidth = _renderer.bounds.size.x;

        if (ShootingPosition == ShootingPosition.Left || ShootingPosition == ShootingPosition.Back)
            Range *= -1;

        _activeCannonAmmount = GetCannonAmmountByShootingPosition();
        _cannonOrientation = GetCannonOrientationByShootingPosition();

        GenerateBulletPool();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
            Fire();
    }

    private void Fire()
    {
        var currentTransform = transform.localRotation;
        transform.localRotation = new Quaternion(0, 0, 0, 1);

        float gapSize = GetGapSize();

        transform.localRotation = currentTransform;

        Vector3 firstBulletTempPosition;

        if (_activeCannonAmmount == 1)
        {
            firstBulletTempPosition = new Vector3(transform.position.x, transform.position.y, -1);
        }
        else
        {
            if (_cannonOrientation == CannonOrientation.Horizontal)
                firstBulletTempPosition = new Vector3(transform.position.x - _shipWidth / 2, transform.position.y, -1);
            else
                firstBulletTempPosition = new Vector3(transform.position.x, transform.position.y - _shipHeight / 2, -1);
        }


        for (int i = 0; i < _bullets.Count; i++)
        {
            if (!_bullets[i].activeInHierarchy)
            {
                var bulletMoveScript = _bullets[i].GetComponent<BulletMoveScript>();
                Vector3 bulletStartPosition;
                Vector3 bulletTargetPosition;

                if (_cannonOrientation == CannonOrientation.Horizontal)
                    bulletStartPosition = new Vector3(firstBulletTempPosition.x + i * gapSize, firstBulletTempPosition.y, -1);
                else
                    bulletStartPosition = new Vector3(firstBulletTempPosition.x, firstBulletTempPosition.y + i * gapSize, -1);

                bulletStartPosition = RotatePointAroundPivot(bulletStartPosition, transform.position,
                     transform.rotation.eulerAngles);

                _bullets[i].transform.position = bulletStartPosition;
                _bullets[i].transform.localRotation = transform.localRotation;


                if (_cannonOrientation == CannonOrientation.Horizontal)
                    bulletTargetPosition = new Vector3(firstBulletTempPosition.x + i * gapSize, firstBulletTempPosition.y + Range, -1);
                else
                    bulletTargetPosition = new Vector3(firstBulletTempPosition.x + Range, firstBulletTempPosition.y + i * gapSize, -1);

                bulletTargetPosition = RotatePointAroundPivot(bulletTargetPosition,
                    transform.position,
                     transform.rotation.eulerAngles);


                bulletMoveScript.TargetPosition = bulletTargetPosition;

                _bullets[i].SetActive(true);

            }
        }
    }

    private int GetCannonAmmountByShootingPosition()
    {
        switch (ShootingPosition)
        {
            case ShootingPosition.Back:
                return BackCannonAmount;
            case ShootingPosition.Front:
                return FrontCannonAmount;
            case ShootingPosition.Left:
                return LeftCannonAmount;
            case ShootingPosition.Right:
                return RightCannonAmount;
            default:
                return FrontCannonAmount;
        }
    }

    private CannonOrientation GetCannonOrientationByShootingPosition()
    {
        switch (ShootingPosition)
        {
            case ShootingPosition.Back:
            case ShootingPosition.Front:
                return CannonOrientation.Horizontal;
            case ShootingPosition.Left:
            case ShootingPosition.Right:
                return CannonOrientation.Vertical;
            default:
                return CannonOrientation.Horizontal;
        }
    }

    private float GetGapSize()
    {
        switch (ShootingPosition)
        {
            case ShootingPosition.Back:
                return _shipWidth / BackCannonAmount;
            case ShootingPosition.Front:
                return _shipWidth / FrontCannonAmount;
            case ShootingPosition.Left:
                return _shipHeight / LeftCannonAmount;
            case ShootingPosition.Right:
                return _shipHeight / RightCannonAmount;
            default:
                return _shipWidth / FrontCannonAmount;
        }
    }

    private Vector3 RotatePointAroundPivot(Vector3 point, Vector3 pivot, Vector3 angles)
    {
        Vector3 dir = point - pivot;
        dir = Quaternion.Euler(angles) * dir;
        point = dir + pivot;
        return point;
    }

    private void GenerateBulletPool()
    {
        _bullets = new List<GameObject>();

        for (int i = 0; i < _activeCannonAmmount; i++)
        {
            var bullet = Instantiate(Bullet);
            bullet.SetActive(false);
            _bullets.Add(bullet);
        }
    }
}
