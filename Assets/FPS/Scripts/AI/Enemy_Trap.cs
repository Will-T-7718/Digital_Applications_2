using System.Collections.Generic;
using Unity.FPS.AI;
using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Enemy_Trap : MonoBehaviour
{
    public float Damage;
    public DamageArea area;
    public NavMeshAgent navMesh;
    public DetectionModule detector;
    public Actor actor;
    public Collider[] colliders;
    public Health health;

    [Tooltip("Layers this trap can collide with")]
    public LayerMask layers = -1;

    void Die()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        health.OnDie += Die;        
    }

    void OnTriggerEnter(Collider other)
    {

        var damageable = other.gameObject.GetComponent<Damageable>();

        if(damageable == null)
        {
            return;
        }

        this.area.InflictDamageInArea
            (
                this.Damage, this.transform.position,
                layers, QueryTriggerInteraction.Collide,
                this.gameObject
            );

        Die();



    }

    void Update()
    {
        detector.HandleTargetDetection(actor, colliders);
        if (!detector.IsSeeingTarget)
        {
            return;
        }
        else
        {
            navMesh.SetDestination(detector.KnownDetectedTarget.transform.position);

        }
    }
}
