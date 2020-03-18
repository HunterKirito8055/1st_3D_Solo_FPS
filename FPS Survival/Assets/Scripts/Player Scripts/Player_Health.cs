using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace s3
{
    public class Player_Health : MonoBehaviour
    {
        private GameManager_Master gameManager_Master;
        private PlayerMaster playerMaster;
        public int playerHealth;
        public Text healthText;

        void OnEnable()
        {
            SetInitialReferences();
            SetUI();
            playerMaster.EventPlayerHealthDeduction += DeductHealth;
            playerMaster.EventPlayerHealthIncrease += IncreasedHealth;
        }

        void OnDisable()
        {
            playerMaster.EventPlayerHealthDeduction -= DeductHealth;
            playerMaster.EventPlayerHealthIncrease -= IncreasedHealth;
        }
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(TestHealthDeduction());
        }

        
        void SetInitialReferences()
        {
            gameManager_Master = GameObject.Find("GameManger").GetComponent<GameManager_Master>();
            playerMaster = GetComponent<PlayerMaster>();

        }

        IEnumerator TestHealthDeduction()
        {
            yield return new WaitForSeconds(4);
            DeductHealth(100);
        }

        void DeductHealth(int healthChange)
        {
            playerHealth -= healthChange;

            if (playerHealth<=0)
            {
                playerHealth = 0;
                gameManager_Master.CallEventGameOver();
            }
            SetUI();
        }

        void IncreasedHealth(int healthChange)
        {
            playerHealth += healthChange;

            if(playerHealth>100)
            {
                playerHealth = 100;

            }
            SetUI();
        }

        void SetUI()
        {
            if(healthText!=null)
            {
                healthText.text = playerHealth.ToString();
            }
        }

    }

}
