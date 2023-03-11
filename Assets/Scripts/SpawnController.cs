using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject prefab; 
    [SerializeField] private float spawnRate = 1f;

    public bool CanSpawn { get; set; } = true; 

    private IEnumerator SpawnCoroutine() 
    {
        while (CanSpawn)
        {
            Instantiate(prefab, new Vector3(Random.Range(-3f, 3f), 10f, 0f), Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnCoroutine()); 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject); 
        }
    }
}

