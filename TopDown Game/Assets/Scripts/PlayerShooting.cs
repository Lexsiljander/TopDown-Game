using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    public CameraShake cameraShake;

    public bool hasShot = false;
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if(hasShot == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {

                Shoot();

                cameraShake.StartShake(0.2f, 1f);
                hasShot = true;
                StartCoroutine(shotCooldown());
                FindObjectOfType<AudioManager>().Play("Shoot");
            }
        }
       
    }

    void Shoot()
    {
       GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
       Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
       rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }

    IEnumerator shotCooldown()
    {
        yield return new WaitForSeconds(1);
        hasShot = false;
    }
}
