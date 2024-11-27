using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public Transform bulletSpawnPoint; // The point where the bullet will spawn
    public float bulletSpeed = 10f; // Speed of the bullet
    public float fireRate = 0.2f; // Time between shots
    private float nextFireTime = 0f; // Time when the next shot can be fired
    public Vector3 rotationAdjustment = new Vector3(0, 0, 90);

    void Update()
    {
        // Check if the left mouse button is held down
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // Calculate the adjusted rotation
        Quaternion adjustedRotation = bulletSpawnPoint.rotation * Quaternion.Euler(0, 0, 0);

        // Instantiate the bullet at the bulletSpawnPoint position and adjusted rotation
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, adjustedRotation);

        // Get the Rigidbody component of the bullet
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // Apply force to the bullet to move it forward
        rb.velocity = bulletSpawnPoint.forward * bulletSpeed;
    }
}
