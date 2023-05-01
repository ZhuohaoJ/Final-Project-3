using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunShooting : MonoBehaviour
{
    //Gun stats
    public int damage;

    public float timeBetweenShots;
    public float bulletSpread;
    public float range;
    public float reloadTime;
    public float timeBetweenShooting;

    public int magazineSize;
    public int bulletsPerTap;

    public bool allowButtonHold;

    private int bulletsLeft;
    private int bulletsShot;

    // State of the weapon
    private bool shooting;
    private bool readyToShoot;
    private bool reloading;

    //References
    public Camera _camera;
    public Transform attackPoint;
    public RaycastHit rayHit;

    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();

        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
        
    }

    private void Shoot()
    {
        readyToShoot = false;

        //Bullet spread
        float x = Random.Range(-bulletSpread, bulletSpread);
        float y = Random.Range(-bulletSpread, bulletSpread);

        
        //Calculate direction of spread
        Vector3 direction = _camera.transform.forward + new Vector3(x, y, 0);

        Debug.DrawRay(_camera.transform.position, direction * range, Color.cyan, 1);


        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);


    }

    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }
}
