using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Enum to identify enemy types
    private enum EnemyType
    {
        Watcher,
        Chaser,
        Attacker,
    }

    [SerializeField] private GameObject player;
    [SerializeField] private EnemyType enemyType;
    private float lookSpeed = 0.00f;
    private float speed = 0.0f;
    //private int attackDamage = 0;

    // Start is called before the first frame update
    void Start()
    {
        ModeSelector(enemyType);
    }

    // Update is called once per frame
    void Update()
    {
        ModeSelector(enemyType);
    }

    // enemy tyupe is asigned lookspeed, speed, look method and movement method
    private void ModeSelector(EnemyType enemyType)
    {
        switch (enemyType)
        {
            case EnemyType.Watcher:
                lookSpeed = 2.00f;
                speed = 0.00f;
                LookAtPlayer();
                break;

            case EnemyType.Chaser:
                lookSpeed = 4.00f;
                speed = 4.00f;
                LookAtPlayer();
                if (PlayerDistance() > 4.00f)
                {
                    ChasePlayer();
                }
                break;

            case EnemyType.Attacker:
                lookSpeed = 6.00f;
                speed = 6.00f;
                LookAtPlayer();
                if (PlayerDistance() >= 4.00f)
                {
                    ChasePlayer();
                }
                break;

            default:
                break;
        }
    }

    //look method using lerp
    private void LookAtPlayer()
    {
        Quaternion newRotation = Quaternion.LookRotation(player.transform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, lookSpeed * Time.deltaTime);
    }

    //movement method to chase the player
    private void ChasePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    //method to calculate remaining distance to the player
    private float PlayerDistance()
    {
        float distance = (player.transform.position - transform.position).sqrMagnitude;
        return distance;
    }
}
