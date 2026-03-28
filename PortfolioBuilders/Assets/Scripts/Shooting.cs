using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.25f;

    private float nextFireTime;

    public void Shoot()
    {
        if (Time.time < nextFireTime) return;

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        nextFireTime = Time.time + fireRate;
    }
}
