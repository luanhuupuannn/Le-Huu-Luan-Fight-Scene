using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class ControlEnemy : MonoBehaviour
{
     float speed = 1f;
    private Transform target;
    private bool isCollidingWithPlayer = false;
    Animator ani;
    float time =0f;
    float timecombat = 3.5f;
    public CombatEnemy combatEnemy;
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
                // Tính toán vector di chuyển
                Vector3 direction = (target.position - transform.position).normalized;
                // Di chuyển đối tượng theo hướng đó với tốc độ đã đặt
                transform.position += direction * speed * Time.deltaTime;
                // Xoay đối tượng theo hướng di chuyển
                if (direction != Vector3.zero) // Đảm bảo không có phép chia cho 0
                {
                    Quaternion lookRotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f); // Sử dụng Slerp để xoay mượt mà
                }
            }
        }
        else
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                combatEnemy.combat();
                time = timecombat;
            }
        }
    }

    void FindNearestPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length > 0)
        {
            // Tìm Player gần nhất bằng cách so sánh khoảng cách
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
        if (collision.gameObject.CompareTag("Player"))
        {
            isCollidingWithPlayer = true;
            ani.SetBool("walk", false);
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("delay", 3f);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCollidingWithPlayer = true;
            ani.SetBool("walk", false);

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCollidingWithPlayer = true;
            ani.SetBool("walk", false);

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
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