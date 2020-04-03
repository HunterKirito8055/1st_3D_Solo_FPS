using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private Image health_stats, stamina_stats;

    public void Display_Healthstats(float healthval)
    {
        healthval /= 100f;
        health_stats.fillAmount = healthval;
    }
    public void Display_Staminastats(float staminaval)
    {
        staminaval /= 100f;
        stamina_stats.fillAmount = staminaval;
    }

}//class
