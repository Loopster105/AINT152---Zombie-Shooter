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

        GameObject bullet = PoolManager.current.GetPooledObject("Bullet 1");
        if (bullet != null)
        {
            bullet.transform.position = bulletSpawn.position;
            bullet.transform.rotation = bulletSpawn.rotation;
            bullet.SetActive(true);
        }

        if (FindObjectOfType<AudioManager>() != null)
        {
            FindObjectOfType<AudioManager>().PlaySound("");
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