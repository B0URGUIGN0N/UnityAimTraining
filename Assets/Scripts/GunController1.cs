using UnityEngine;

public class GunController1 : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public Transform bulletSpawnPoint; // The point where the bullet will spawn
    public float bulletSpeed = 10f; // Speed of the bullet
    public Vector3 rotationAdjustment = new Vector3(0, 0, 90); // Rotation adjustment

    void Update()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Calculate the adjusted rotation
        Quaternion adjustedRotation = bulletSpawnPoint.rotation * Quaternion.Euler(rotationAdjustment);

        // Instantiate the bullet at the bulletSpawnPoint position and adjusted rotation
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, adjustedRotation);

        // Get the Rigidbody component of the bullet
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        // Apply force to the bullet to move it forward
        rb.velocity = -bulletSpawnPoint.forward * bulletSpeed;
    }
}
