using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DisappearAfterTime : MonoBehaviour
{
    public float delay = 3.0f; // Temps en secondes avant que l'objet disparaisse

    void Start()
    {
        StartCoroutine(Disappear());
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false); // Désactive l'objet
    }
}

