using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementNeuille : MonoBehaviour
    
{
    public bool ismovingleft = true;
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ismovingleft)
        {
            transform.Translate(Vector3.left * Time.deltaTime* speed);
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime* speed);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Collison dummy")
        {
            Debug.Log("Collison dummy");
            if (ismovingleft)
            {
                ismovingleft = false;
            }
            else
            {
                ismovingleft = true;
            }
        }
        if (collision.gameObject.tag == "Balle")
        {
            ScoreManager.Instance.IncrementScore(1);
            
        }
    }
}
