using UnityEngine;

public class Target : MonoBehaviour
{
    public float minX = -10f; // Minimum allowed X position
    public float maxX = 10f;  // Maximum allowed X position
    public float minY = -10f; // Minimum allowed Y position
    public float maxY = 10f;  // Maximum allowed Y position

    void Update()
    { /*
        List<GameObject> targets = TargetSpawner.targets;*/
        CheckBounds();
    }

    private void CheckBounds()
    {
        Vector3 position = transform.position;

        // Check if the target's position is outside the allowed intervals
        if (position.x < minX || position.x > maxX || position.y < minY || position.y > maxY)
        {
            Destroy(gameObject); // Destroy the target if it is out of bounds
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Balle")
        {
            ScoreManager.Instance.IncrementScore(1);
            Destroy(gameObject); // Destroy the target when it collides with another object
        }
       
    }


}

    