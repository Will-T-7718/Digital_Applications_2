using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal.Commands;
using Unity.FPS.AI;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    [Tooltip("Delay between spawning enemies")]
    [Range(0.0f, 10.0f)]
    public float delay;
    [Tooltip("Prefab to spawn enemies")]
    public GameObject prefab;
    [Tooltip("Transform to spawn enemies at")]
    public Transform location;
    [Tooltip("Stop spawning enemies once this threshold is reached")]
    [Range(1, 100)]
    public int maxCount;
    [Tooltip("Only track self enemies, or all enemies in the scene")]
    public bool selfTracking = true;

    EnemyManager manager;
    List<GameObject> children = new();


    void Start()
    {
        manager = FindAnyObjectByType<EnemyManager>();

    }   

    IEnumerator tick()
    {
        while (true)
        {
            children.RemoveAll(c => c == null);
            yield return new WaitForSeconds(delay);
            int count;
            if (selfTracking)
            {
                count = children.Count;
            }

            else
            {
                count = manager.NumberOfEnemiesRemaining;
            }

            if (count >= maxCount)
            {
                continue;
            }

            var child = Instantiate(prefab, location);

            children.Add(child);
            
        }
           
    }

    void Update()
    {
        
    }
}
