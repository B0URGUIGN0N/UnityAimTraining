using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float speed = 5f; // Vitesse du mouvement
    private Vector3 randomDirection;

    void Start()
    {
        // Générer une direction aléatoire sur X et Y, Z reste inchangé
        GenerateRandomDirection();
    }

    void Update()
    {
        // Déplacer l'objet dans la direction aléatoire
        transform.position += randomDirection * speed * Time.deltaTime;
    }

    void GenerateRandomDirection()
    {
        // Générer des valeurs aléatoires pour X et Y entre -1 et 1
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);

        // La direction aléatoire avec Z constant
        randomDirection = new Vector3(randomX, randomY, 0).normalized;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Exemple : changer de direction aléatoirement en cas de collision
        GenerateRandomDirection();
    }
}
