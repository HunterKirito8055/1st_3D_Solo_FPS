using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;// add this

//to cannibal object


    public enum EnemyState { PATROL,CHASE, ATTACK}
public class Enemy : MonoBehaviour
{
 
    public float walk_speed = 1f;
    public float chase_speed = 4f;

    public float To_chase_Dist = 7f; //when ptarget is in this distance , then chases
    public float attack_dist = 1f; //from 1 unit away to player
    public float chase_after_dist = 2f;
    private float current_chase_dist;


    public float patrol_radius_min = 15f, patrol_radius_max = 45f;
    public float patrol_time_to_change = 15f;// after this seconds, change the random destinatin to patrol

    private float patrol_timer;

    public float wait_before_attack =2f;
    private float attack_timer;


    private EnemyState _enemystate;
    private Transform Target;   //our player
    private EnemyAnimations enemyAnim;
    private NavMeshAgent navAgent;

    [SerializeField]
    private GameObject AttackPoint;

    private void Awake()
    {
        enemyAnim = GetComponent<EnemyAnimations>();
        navAgent = GetComponent<NavMeshAgent>();

        Target = GameObject.FindWithTag(Tags.PLAYER_TAG).transform;
    }

    private void Start()
    {
        _enemystate = EnemyState.PATROL; //Initially needs to be in patrol state and shold not chase right away.. duhh

        /* EXPERIMENT
         */
        patrol_timer = patrol_time_to_change;// note this.. and experiment later..
        attack_timer = wait_before_attack;// this much time waits and then attacks


        //memorise when doing HEALTH script.. 
        //when he hits bullet, zombie goes angry and increase
        //chase distance to find us, but after that
        // we need to reset to default chase distance
        current_chase_dist = To_chase_Dist;
    }

    private void Update()
    {
        if(_enemystate == EnemyState.CHASE)
        {
            Chase();    
        }
        if(_enemystate == EnemyState.PATROL)
        {
            Patrol();
        }
        if (_enemystate == EnemyState.ATTACK)
        {
            Attack();
        }
    }

    void Chase()
    {
        navAgent.isStopped = false;
        navAgent.speed = chase_speed;

        navAgent.SetDestination(Target.position);//towards player

        if(navAgent.velocity.sqrMagnitude>0)
        {
            enemyAnim.Chase(true);
        }
        else
        {
            enemyAnim.Chase(false);
        }

        //if the distance between enemy and player is less than atack distance.. ie 2 or wahtever
        // attack shold happen
        if (Vector3.Distance(transform.position, Target.position) <= attack_dist)
        {
            enemyAnim.Chase(false);
            enemyAnim.Walk(false);
            _enemystate = EnemyState.ATTACK;


            //reset the chase distance when it is changed from diffrnt script
            if(To_chase_Dist != current_chase_dist)
            {
                To_chase_Dist = current_chase_dist;
            }

        }          
       else if(Vector3.Distance(transform.position, Target.position) > To_chase_Dist)
       {
                //player is not free from zombie..
                // make enemy to get back from attack to patrol
                enemyAnim.Chase(false);
            enemyAnim.Walk(true);
                _enemystate = EnemyState.PATROL;

            //reset the patrolling timer so function can calc the new patrol destination
            patrol_timer = patrol_time_to_change;
            //reset the chase distance when it is changed from diffrnt script
            if (To_chase_Dist != current_chase_dist)
            {
                To_chase_Dist = current_chase_dist;
            }
        }//else if

        

    }//chase

    void Attack()
    {
        navAgent.velocity = Vector3.zero;
        navAgent.isStopped = true;

        attack_timer += Time.deltaTime;
        if(attack_timer >wait_before_attack)
        {
            enemyAnim.Attack();
            attack_timer = 0;
        }
        if (Vector3.Distance(transform.position, Target.position) >
            attack_dist + chase_after_dist)
        {
            _enemystate = EnemyState.CHASE;
        }
    
    
    }   //attack


    void Patrol()
    {
       
        navAgent.isStopped = false;
        navAgent.speed = walk_speed;

        //patrol timing until change to another direction moving
        patrol_timer += Time.deltaTime;

        if(patrol_timer > patrol_time_to_change)
        {
            SettingRandomDestination();
            patrol_timer = 0;// reset  again this if condition is validated ;P
        }

        if(navAgent.velocity.sqrMagnitude >0)
        {
            enemyAnim.Walk(true);
        }

        else
        {
            enemyAnim.Walk(false);
        }


        //if the distance from enemy to target is less than chase.. then chase
        if(Vector3.Distance(this.transform.position, Target.position)<=To_chase_Dist)
        {
            enemyAnim.Walk(false);
            _enemystate = EnemyState.CHASE;//after this,.. itchecks in update and Chase funcion is enabled
        }



    }//patrol


    void SettingRandomDestination()
    {
        /*from here to....*/

        float randRadius = Random.Range(patrol_radius_min, patrol_radius_max);

        Vector3 randPosition = Random.insideUnitSphere * randRadius;// between 15 to 45 becomes radius of sphere
        randPosition += transform.position;

        NavMeshHit navHit; //like raycastHIT


        //samplePosition means in the navmesh, it checks whether the random position is on the mesh or outside.. 
        // and if it is outside, then it wont take any value,
        NavMesh.SamplePosition(randPosition, out navHit, randRadius,-1); 
        /* checking the random point to patrol the enemy*/


        navAgent.SetDestination(navHit.position);
    }






    void Turn_on_attackPoint()
    {
        AttackPoint.SetActive(true);
    }
    void Turn_off_attackPoint()
    {
        if (AttackPoint.activeInHierarchy)
        {   
            AttackPoint.SetActive(false);
        }
    }





    public EnemyState Enemy_State
    {
        get; set;
    }











}//class
