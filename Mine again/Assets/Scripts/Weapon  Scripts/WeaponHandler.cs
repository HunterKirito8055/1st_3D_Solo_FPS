using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attached to all weapons
public enum WeaponAim
{ NONE, SELF_AIM /*for only Spear */, AIM }

public enum WeaponFireType
{
    SINGLE, MULTIPLE
}
public enum WeaponBulletType
{
    BULLET, ARROW, SPEAR, NONE/*for axe*/
}

public class WeaponHandler : MonoBehaviour
{
    private Animator anim;
    [SerializeField]
    GameObject MuzzleFlash;

    [SerializeField]
    AudioSource shootSound, reloadSound;

    public WeaponAim _weaponAim;
    
    public WeaponBulletType _bullettype;
  
    public WeaponFireType _firetype;
   
    public GameObject _attackpoint;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void Shoot_Anim()
    {
        anim.SetTrigger(AnimationTags.SHOOT_TRIGGER);
    }

    public void Aim(bool canAim)
    {
        anim.SetBool(AnimationTags.AIM_PARAMETER, canAim);
    }
    private void Turn_on_muzzleFlash()
    {
        MuzzleFlash.SetActive(true);
    } 
    private void Turn_off_muzzleFlash()
    {
        MuzzleFlash.SetActive(false);
    }

    void Play_ShootSound()
    {
        shootSound.Play();
    }
    void Play_ReloadSound()
    {
        reloadSound.Play();
    }

    void Turn_on_attackPoint()
    {
        _attackpoint.SetActive(true);
    }
    void Turn_off_attackPoint()
    {
        if(_attackpoint.activeInHierarchy)
        {
            _attackpoint.SetActive(false);
        }
    }





}//class









