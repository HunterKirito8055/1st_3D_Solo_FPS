using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // coz we atached to the zombie wich is AI
//attached on player and zombie
public class HealthStat : MonoBehaviour
{
    private EnemyAnimations enem_Anim;
    private NavMeshAgent navAgent;
    private Enemy enem_move;

    public float Health = 100f;
    public bool is_player, is_enemy;

    private bool is_died;

    private void Awake()
    {
        if (is_enemy)
        {
            enem_Anim = GetComponent<EnemyAnimations>();
            enem_move = GetComponent<Enemy>();
            navAgent = GetComponent<NavMeshAgent>();

        }
        if(is_player)
        {
            //in UI
        }

    }


    public void ApplyDamage(float damage)
    {
        if (is_died)
            return;
        Health -= damage;
        
        if(is_player)
        {
            //show in UI
        }
        if(is_enemy)
        {
            if(enem_move.Enemy_State == EnemyState.PATROL)
            {
                //if we hit enemy, enemy rages and finds us only if we increase distance range 
                enem_move.To_chase_Dist = 50f;
            }
        }

        if(Health <=0f)
        {
            ObjectDead();
            is_died = true;
        }
    }//damage


    void ObjectDead()
    {
        if(is_enemy)
        {
           
        }
    }







}//class








