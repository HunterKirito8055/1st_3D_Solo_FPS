//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

//attached to Player
public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private WeaponHandler[] weapons;

    int current_weapon_index = 0;


  // public Transform FPweapon;

    private void Start()
    {
       // FPweapon = this.gameObject.transform.GetChild(0).GetChild(2);
        weapons[current_weapon_index].gameObject.SetActive(true);
    }
    private void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShowSelectedWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ShowSelectedWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ShowSelectedWeapon(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ShowSelectedWeapon(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            ShowSelectedWeapon(4);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            ShowSelectedWeapon(5);
        }


    }//update

    void ShowSelectedWeapon(int index)
    {
        if (current_weapon_index == index)
        {
            return;
        }
        //turn off current weapon
        weapons[current_weapon_index].gameObject.SetActive(false);
        //turn on selected weapon
        weapons[index].gameObject.SetActive(true);
        //store the current selected weapon as index
        current_weapon_index = index;


        /*  Below im trying for foreach by taking child of child in parent of this object*/

        //foreach(Transform fpwaps in FPweapon)
        //{
        //    if (current_weapon_index == index)
        //    {
        //        fpwaps.gameObject.SetActive(true);
        //    }
        //    else
        //        fpwaps.gameObject.SetActive(false);
        //    current_weapon_index++;
        //}

    }

    public WeaponHandler GetSelectedWeapon()
    {
        //print("curr   " + current_weapon_index);
        //print("weap   " + weapons[current_weapon_index]);
        return weapons[current_weapon_index];

    }
    


}//class
