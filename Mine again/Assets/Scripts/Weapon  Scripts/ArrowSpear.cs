using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpear : MonoBehaviour
{
    private Rigidbody Rbody;

    public float speed = 2f;
    public float deactivate_after = 3f;
    public float damage = 15f;

    private void Awake()
    {
        Rbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Invoke("DestroGameObject", deactivate_after);
    }


    void DestroGameObject()
    {
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }//destroy
    private void OnTriggerEnter(Collider other)
    {
        
    }//ONtrigger

    public void Throw(Camera mainCam)
    {
        Rbody.velocity = mainCam.transform.forward * speed;
        //lookat is like the object facing the z-direction 
        //and we shld make it lookat some point/object by passing parameters below
        this.transform.LookAt(transform.position + Rbody.velocity);
    }


}//class




