using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum EnemyState
{
    PATROL,CHASE,ATTACK
}


public class EnemyControllerScript : MonoBehaviour
{
    public LayerMask detectionLayer;
    private EnemyAnimationScript enemy_Anim;    //getting component which is created
    private Transform myTransform;
    private Collider[] hitColliders;
    private NavMeshAgent navAgent;
    private float checkRate;
    private float nextCheck;
    private float detectionRadius = 10;

    //private EnemyState enemy_State;

    //public float walk_Speed = 0.5f;
    //public float run_Speed = 4f;

    //public float chase_Distance = 7f;
    //private float current_Chase_Distance;
    //public float attack_Distance = 1.8f;
    //public float chase_After_Attack_Distance = 2f;

    //public float patrol_Radius_min = 20f, patrol_Radius_max = 60f;
    //public float patrol_for_now = 15f;
    //private float patrol_Timer;

    //public float wait_before_attack = 2f;
    //private float attack_Timer;

    //private Transform target;

    void Start()
    {
        SetInitialReference();
    }

    void Update()
    {
        CheckPlayerInRange();
    }
   //// private void Awake()
   // {
   //     enemy_Anim = GetComponent<EnemyAnimationScript>();
   //     navAgent = GetComponent<NavMeshAgent>();

   //     target = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
   // }

    void SetInitialReference()
    {
        myTransform = transform;
        navAgent = GetComponent<NavMeshAgent>();
        checkRate = Random.Range(0.8f, 1.2f);
    }

    void CheckPlayerInRange()
    {
        if(Time.time> nextCheck && navAgent.enabled==true)
        {
            nextCheck = Time.time + checkRate;

            hitColliders = Physics.OverlapSphere(myTransform.position, detectionRadius, detectionLayer);

            if(hitColliders.Length>0)
            {
                navAgent.SetDestination(hitColliders[0].transform.position);
            }
        }
    }

}//class








