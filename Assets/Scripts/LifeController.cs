using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int hitPoints;
    [SerializeField] private bool enableDamage = false;
    private int maxHitPoints;
    public bool lowHealth;
    private float healerCounter = 0.00f;
    //private float damageCounter = 0.00f;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "Enemy")
        {
            hitPoints = 50;
        }
        if (gameObject.tag == "Player")
        {
            hitPoints = 150;
        }
        maxHitPoints = hitPoints;
    }

    // Update is called once per frame
    void Update()
    {
        IsHealthLow();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(enableDamage == true)
        {
            // Player receives 5 damage from collisioning with enemy
            if (gameObject.tag == "Player" && collision.gameObject.tag == "Enemy")
            {
                HealthLoss(5);
                Debug.Log(gameObject.name + hitPoints);
            }
            // Enemy recieves 10 damage whem collisioning with player
            if (collision.gameObject.tag == "Player")
            {
                HealthLoss(10);
                Debug.Log(gameObject.name + hitPoints);
            }
            
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        // Player receives 5 damage from collisioning with enemy over 2 seconds
        /*if (gameObject.tag == "Player" && collision.gameObject.tag == "Enemy")
        {
            damageCounter += Time.deltaTime;
            if (damageCounter >= 2.00f)
            {
                HealthLoss(5);
                Debug.Log(gameObject.name + hitPoints);
                damageCounter = 0.00f;
            }
            
        }*/

        // Player recovers 50 Hp every 2 seconds when on a Healing Area 
        if (gameObject.tag == "Player" && collision.gameObject.tag == "PlayerRecovery")
        {
            healerCounter += Time.deltaTime;
            if (healerCounter >= 3.00f)
            {
                HealthRecovery(50);
                healerCounter = 0.00f;
            }
        }

        // Enemy recieves 10 damage whem collisioning with player every second
        /*if (collision.gameObject.tag == "Player")
        {
            damageCounter += Time.deltaTime;
            if (damageCounter >= 1.00f)
            {
                HealthLoss(10);
                Debug.Log(gameObject.name + hitPoints);
                damageCounter = 0.00f;
            }
            
        }*/

        // Enemy recovers 10 Hp per second when on a Healing Area
        if (gameObject.tag == "Enemy" && collision.gameObject.tag == "EnemyRecovery")
        {
            healerCounter += Time.deltaTime;
            if (healerCounter >= 1.00f)
            {
                HealthRecovery(10);
                healerCounter = 0.00f;
            }
        }
    }

    // Health recovered with top of max HP
    private void HealthRecovery(int recovery)
    {
        if (hitPoints>= (maxHitPoints - recovery))
        {
            hitPoints = maxHitPoints;
        }
        if (hitPoints < (maxHitPoints - recovery))
        {
            hitPoints += recovery;
        }

    } 

    // Health loss and GameObject is destroyed when HP should drop below 0
    // If HP is at 40% maxHp or less then lowHealth is set
    private void HealthLoss(int damage)
    {
        if (hitPoints <= damage)
        {
            Destroy(gameObject);
        }
        if (hitPoints > damage)
        {
            hitPoints -= damage;
        }
       
    }

    private bool  IsHealthLow()
    {
        if (hitPoints <= (0.4 * maxHitPoints))
        {
            lowHealth = true;
        }
        if (hitPoints == maxHitPoints)
        {
            lowHealth = false;
        }
        return lowHealth;
    }
}
