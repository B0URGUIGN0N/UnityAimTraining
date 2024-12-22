using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    public GameObject targetPrefab;
    public GameObject movementArea;
    public int targetLimit = 10;
    public float spawnInterval = 2.0f;
    public float moveSpeed = 5.0f;
    public float targetLifetime = 5.0f;

    public List<GameObject> targets = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnTargets());
    }

    IEnumerator SpawnTargets()
    {
        while (true)
        {
            if (targets.Count < targetLimit)
            {
                Vector3 spawnPosition = GetRandomPosition();
                GameObject newTarget = Instantiate(targetPrefab, spawnPosition, Quaternion.identity);
                targets.Add(newTarget);
                StartCoroutine(MoveAndDestroyTarget(newTarget));
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    Vector3 GetRandomPosition()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(-movementArea.transform.localScale.x / 2, movementArea.transform.localScale.x / 2),
            Random.Range(-movementArea.transform.localScale.y / 2, movementArea.transform.localScale.y / 2),
            0 // Fixer Z à 0
        );
        return movementArea.transform.position + randomPosition;
    }

    IEnumerator MoveAndDestroyTarget(GameObject target)
    {
        Vector3 randomDirection = new Vector3(
            Random.Range(-1.0f, 1.0f),
            Random.Range(-1.0f, 1.0f),
            0 // Fixer Z à 0
        ).normalized;

        float elapsedTime = 0;

        while (elapsedTime < targetLifetime)
        {
            target.transform.position += randomDirection * moveSpeed * Time.deltaTime;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Debug.Log("Target destroyed");
        targets.Remove(target);
        Destroy(target);
    }
}
