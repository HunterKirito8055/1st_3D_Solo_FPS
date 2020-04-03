using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAttack : MonoBehaviour
{
    public float damage = 4f;
    public float radius = 1f;// arround axe point
    public LayerMask layerMask;

    Collider[] hits;
    private void Update()
    {
        hits = Physics.OverlapSphere(transform.position, radius, layerMask);

        if(hits.Length>0)
        {
            print("axe attacked :" + hits[0].gameObject.name);
            gameObject.SetActive(false);
            
        }
    }




}//class




