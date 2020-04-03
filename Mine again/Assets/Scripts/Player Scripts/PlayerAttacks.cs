using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To player object
public class PlayerAttacks : MonoBehaviour
{

    private WeaponManager _weaponManager;

    [SerializeField]
    public float firepower = 17f;
    public float damage = 20f;
    float nextBulletTime;

    private Animator ZoomAnim;
    private bool isZoom;
    private Camera mainCame;
    private bool isAiming;

    private GameObject Cross;

    //for arrow and spear
    [SerializeField]
    private GameObject arrowPrefab, spearPrefab;

    [SerializeField]
    private Transform ArrowstartPoint, SpearStartpoint;

    private void Awake()
    {
        _weaponManager = GetComponent<WeaponManager>();
        ZoomAnim = GameObject.FindWithTag(Tags.ZOOM_CAMERA).GetComponent<Animator>();
        Cross = GameObject.FindWithTag(Tags.CROSSHAIR);
        mainCame = Camera.main;
    }

    private void Update()
    {
        ZoomInOut();
        WeaponShooting();
    }
     void WeaponShooting()
    {
        //assault firing continuosly.
        if (_weaponManager.GetSelectedWeapon()._firetype == WeaponFireType.MULTIPLE)
        {
            if (Input.GetMouseButton(0) && Time.time > nextBulletTime)
            {
                //assualt rifles fires like 3 bullets a sec. so to calculate. 
                // time = 100%, then 3 bullets is like 33% time..
                nextBulletTime = Time.time + 1f / firepower;
                //Debug.Log("next " + nextBulletTime);
                //Debug.Log("times " + Time.time);
                _weaponManager.GetSelectedWeapon().Shoot_Anim();

                BulletFire();
            }

        }//fire type Multiple

        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                //handling AXE 
                if (_weaponManager.GetSelectedWeapon().tag == Tags.AXE_TAG)
                {
                    _weaponManager.GetSelectedWeapon().Shoot_Anim();
                }

                //handling shoot for once
                if(_weaponManager.GetSelectedWeapon()._bullettype == WeaponBulletType.BULLET)
                {
                    _weaponManager.GetSelectedWeapon().Shoot_Anim();
                    BulletFire();
                }
                else//for arrow and spears.. we get Bool value from zoom in outo nly
                {
                   if(isAiming)
                    {
                        
                        if(_weaponManager.GetSelectedWeapon()._bullettype == WeaponBulletType.ARROW)
                        {
                            //arrow throw dude...
                            ThrowingPrefabs(true);
                        }
                        else if(_weaponManager.GetSelectedWeapon()._bullettype ==WeaponBulletType.SPEAR)
                        {
                            //spear mechanisms
                            ThrowingPrefabs(false);
                        }
                        _weaponManager.GetSelectedWeapon().Shoot_Anim();
                    }

                }//we have arrow or spear
            }//if inputing mouse button 0
        }//else
    }//weapon shoot

    void ZoomInOut()
    {
        //for pistol shotgun and rifle
        if(_weaponManager.GetSelectedWeapon()._weaponAim == WeaponAim.AIM)
        {
            //zoom only work if we press and hold right mouse button
            if(Input.GetMouseButtonDown(1))
            {
                ZoomAnim.Play(AnimationTags.ZOOM_IN_ANIM);
                //wehn zooming, no crosshair OK..!
                Cross.SetActive(false);
            }
            else if(Input.GetMouseButtonUp(1))
            {
                ZoomAnim.Play(AnimationTags.ZOOM_OUT_ANIM);
                Cross.SetActive(true);
            }
        }//for pistal shotgun and rifle

        //for bow and spear we need fire after aiming only.. so..
        if(_weaponManager.GetSelectedWeapon()._weaponAim == WeaponAim.SELF_AIM)
        {
            //right click and then aim bro..
            if(Input.GetMouseButtonDown(1))
            {
                _weaponManager.GetSelectedWeapon().Aim(true);
                isAiming = true;
            }
            else if(Input.GetMouseButtonUp(1))
            {
                _weaponManager.GetSelectedWeapon().Aim(false);
                isAiming = false;
            }
        }//selfaims duhhhhh

        /* after this zoominout, we get isAiming bool value and 
         * then the in WeaponShoot the shooting is done there in selfaim shoot */
    }//zoom IN OUT



    void ThrowingPrefabs(bool thrown)
    {
        if(thrown)
        {
            GameObject _arrow = Instantiate(arrowPrefab);
            _arrow.transform.position = ArrowstartPoint.position;
            _arrow.GetComponent<ArrowSpear>().Throw(mainCame);
        }
        else
        {
            GameObject _spear = Instantiate(spearPrefab);
            _spear.transform.position = SpearStartpoint.position;
            _spear.GetComponent<ArrowSpear>().Throw(mainCame);
        }
    }//throwing

    void BulletFire()
    {
        RaycastHit hit;
        if(Physics.Raycast(mainCame.transform.position,mainCame.transform.forward,out hit))
        {
            if(hit.transform.tag == Tags.ENEMY_TAG)
            {
                hit.transform.GetComponent<HealthStat>().ApplyDamage(damage);
            }
            //print("hit tar : " + hit.transform.gameObject.name);
        }
    }



}//class







