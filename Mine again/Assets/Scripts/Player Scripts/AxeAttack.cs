using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAttack : MonoBehaviour
{
    public float damage = 4f;
    public float radius = 1f;// arround axe point
    public LayerMask layerMask;

    
    private void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, layerMask);
       

        if(hits.Length>0)
        {
            hits[0].gameObject.GetComponent<HealthStat>().ApplyDamage(damage);
            gameObject.SetActive(false);

            
        }
    }




}//class




