using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet2 : MonoBehaviour {

    public Transform bulletSpawn;
    public float fireTime = 0.5f;
    private bool isFiring = false;
    void SetFiring()
    {
        isFiring = false;
    }

    void Fire()
    {
        isFiring = true;

        GameObject bulletD = PoolManager.current.GetPooledObject("BulletD");
        if (bulletD != null)
        {
            bulletD.transform.position = bulletSpawn.position;
            bulletD.transform.rotation = bulletSpawn.rotation;
            bulletD.SetActive(true);
        }

        if (FindObjectOfType<AudioManager>() != null)
        {

            FindObjectOfType<AudioManager>().Play("PlayerFire");

        }
        Invoke("SetFiring", fireTime);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!isFiring)
            {
                Fire();
            }
        }
    }
}