using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float speed = 5f; // Vitesse du mouvement
    private Vector3 randomDirection;

    void Start()
    {
        // G�n�rer une direction al�atoire sur X et Y, Z reste inchang�
        GenerateRandomDirection();
    }

    void Update()
    {
        // D�placer l'objet dans la direction al�atoire
        transform.position += randomDirection * speed * Time.deltaTime;
    }

    void GenerateRandomDirection()
    {
        // G�n�rer des valeurs al�atoires pour X et Y entre -1 et 1
        float randomX = Random.Range(-1f, 1f);
        float randomY = Random.Range(-1f, 1f);

        // La direction al�atoire avec Z constant
        randomDirection = new Vector3(randomX, randomY, 0).normalized;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Exemple : changer de direction al�atoirement en cas de collision
        GenerateRandomDirection();
    }
}
