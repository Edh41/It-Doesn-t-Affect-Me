using UnityEngine;
using System;


public class AIexample : MonoBehaviour
{
    // Variables: Player Distance, Chase Range, Attack Range, Idle Position
    [SerializeField]
    private float chaseRange = 5.0f;

    [SerializeField]
    private float attackRange = 1.0f, attackCooldown = 1.0f, CooldownTimer;

    [SerializeField]
    private float speed = 4.0f;

    [SerializeField]
    private GameObject AttackOrigin = AttackPoint;

    private Vector3 HomeLocation;

    private bool isInCooldown = false;

    void Start()
    {
        HomeLocation = transform.position;
        CooldownTimer = attackCooldown;
    }

    void Update()
    {
        var playerLocation = FindObjectOfType<PlayerController>().gameObject.transform.position;
        var playerDistance = Vector3.Distance(playerLocation, gameObject.transform.position);

        if(playerDistance < chaseRange)
        {
            transform.LookAt(playerLocation);
            transform.position += transform.forward * Time.deltaTime * speed;

            if(playerDistance < attackRange)
            {
                Attack();
            }
        }

        else if(transform.position != HomeLocation)
        {
            transform.LookAt(HomeLocation);
            transform.position += transform.forward * Time.deltaTime * speed;
            if(Vector3.Distance(HomeLocation, transform.position) < .1f)
            {
                transform.position = HomeLocation;
            }
        }

        if(isInCooldown)
        {
            CooldownTimer -= Time.deltaTime;

            if(CooldownTimer <= 0f)
            {
                isInCooldown = false;
                CooldownTimer = attackCooldown
            }
        }
    }

    private void Attack()
    {
        Debug.Log("Attacking")

        if(isInCooldown == false)
        {
            var hits = Physics.SphereCastAll(AttackOrigin.transform.position, .05f, transform.forward, .25f);

            foreach (var hit in hits)
            {
                if(hit.transform.GameObject.TryGetComponent<CharacterController>(out CharacterController controller))
                {
                    controller.Health -= 1;
                    Debug.Log(controller.Health);
                }
            }

            isInCooldown = true;
        }

        
    }
}
