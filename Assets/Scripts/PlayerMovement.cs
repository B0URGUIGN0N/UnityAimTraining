using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float customGravity = 20f; // Gravit� personnalis�e
    private bool isGrounded;
    [SerializeField] private Transform cameraTransform; // R�f�rence � la cam�ra

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Mouvement horizontal
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Direction de la cam�ra
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // On ignore la composante verticale de la direction de la cam�ra
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();

        // Calcul du mouvement en fonction de la direction de la cam�ra
        Vector3 movement = forward * moveVertical + right * moveHorizontal;
        rb.velocity = new Vector3(movement.x * speed, rb.velocity.y, movement.z * speed);

        // Saut
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        // Applique la gravit� personnalis�e
        if (!isGrounded)
        {
            rb.AddForce(Vector3.down * customGravity, ForceMode.Acceleration);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        // V�rifie si le joueur est au sol
        isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        // Le joueur n'est plus au sol
        isGrounded = false;
    }
}
