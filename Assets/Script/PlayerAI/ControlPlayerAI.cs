using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ControlPlayerAI : MonoBehaviour
{
     float speed = 1f;
    private Transform target;
    private bool isCollidingWithPlayer = false;
    Animator ani;
    float time =0f;
    float timecombat = 3.5f;
    public CombatPlayerAI combatPlayerAI;
    private void Start()
    {
        ani = GetComponent<Animator>();
    }
    void Update()
    {
        if (!isCollidingWithPlayer)
        {
            FindNearestPlayer();
            if (target != null)
            {
                ani.SetBool("walk", true);
                Vector3 direction = (target.position - transform.position).normalized;
                transform.position += direction * speed * Time.deltaTime;
                if (direction != Vector3.zero) 
                {
                    Quaternion lookRotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f); 
                }
            }
        }
        else
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                combatPlayerAI.combat();
                time = timecombat;
            }
        }
    }

    void FindNearestPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Enemy");
        if (players.Length > 0)
        {
            target = players
                .OrderBy(player => Vector3.Distance(transform.position, player.transform.position))
                .FirstOrDefault()?.transform;
        }
        else
        {
            target = null;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            isCollidingWithPlayer = true;
            ani.SetBool("walk", false);
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Invoke("delay", 3f);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isCollidingWithPlayer = true;
            ani.SetBool("walk", false);

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isCollidingWithPlayer = true;
            ani.SetBool("walk", false);

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Invoke("delay", 3f);
        }
    }
    void delay()
    {
        isCollidingWithPlayer = false;
    }
   public void upspeed()
    {
        speed += 0.2f;
    }
    public void uptimecombat()
    {
        timecombat -= 0.2f;
    }
    
}