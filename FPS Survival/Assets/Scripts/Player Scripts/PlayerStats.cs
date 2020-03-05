using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private Image health_stats, stamina_stats;
    
    public void Display_Health(float health_val)
    {
        health_val /= 100f; 
        health_stats.fillAmount = health_val;
    }
    public void Display_Stamina(float stamina_val)
    {
        stamina_val /= 100f; 
        stamina_stats.fillAmount = stamina_val;
    }


}//class












