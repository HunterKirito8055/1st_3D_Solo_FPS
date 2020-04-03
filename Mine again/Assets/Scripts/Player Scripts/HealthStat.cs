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

    private PlayerStats playerstats;

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
            playerstats = GetComponent<PlayerStats>();
        }

    }


    public void ApplyDamage(float damage)
    {
        if (is_died)
            return;

        Health -= damage;
        print("health " + Health);
        
        if(is_player)
        {
            playerstats.Display_Healthstats(Health);
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
            GetComponent<Animator>().enabled = false;
            GetComponent<BoxCollider>().isTrigger = false;
            GetComponent<Rigidbody>().AddTorque(-transform.forward * 10f);

            enem_move.enabled = false;
            navAgent.enabled = false;
            enem_Anim.enabled = false;

        }
        if(is_player)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag(Tags.ENEMY_TAG);
            for(int i=0; i<enemies.Length; i++)
            {
                enemies[i].GetComponent<Enemy>().enabled = false;
            }

            GetComponent<PlayerAttacks>().enabled = false;
            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<WeaponManager>().GetSelectedWeapon().gameObject.SetActive(false);
        }

        if(tag == Tags.PLAYER_TAG)
        {
            Invoke("RestartGame", 3f);
        }
        else
        {
            Invoke("TurnOffGameObject", 3f);
        }

    }//die

    void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GamePlay");
    }

    void TurnOffGameObject()
    {
        gameObject.SetActive(false);
    }




}//class








