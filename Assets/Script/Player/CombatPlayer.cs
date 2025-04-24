using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CombatPlayer : MonoBehaviour
{

    public Hp hp;
    public float maxhp = 100;
    public float nowhp ;
    float damein =1f;
    public GameObject panelloss;

    public Animator ani;
    float timeDelay = 0.6f;
    float timeDelayJump = 0;
    float timeDelayPunch = 0;

    string nameAni= "Idle";

    private void Start()
    {
        nowhp = maxhp;
        hp.updateHp(nowhp, maxhp);
    }

    // Update is called once per frame
    void Update()
    {
        if (nowhp <= 0)
        {
            ani.SetBool("knock", true);
            Invoke("loss", 3f);
        }
        timeDelayJump -= Time.deltaTime;
        if (timeDelayJump < 0.1f && timeDelayJump > 0)
        {
            ani.SetBool("jump1", true);
            Invoke("offaniCombat", 1f);
        }
        timeDelayPunch -= Time.deltaTime;
        if (timeDelayPunch < 0.1f && timeDelayPunch > 0)
        {
            ani.SetBool("punch1", true);
            Invoke("offaniCombat", 1f);
        }
    }


    public void Clickpunch()
    {
        if (timeDelayPunch > 0 && timeDelayPunch < 0.5f)
        {
            ani.SetBool("punch2", true);
            Invoke("offaniCombat", 1.5f);
            timeDelayPunch = 0;
        }
        else
        {
            timeDelayPunch = 0.6f;
        }
    }
    public void Clickjump()
    {
        if (timeDelayJump >0 && timeDelayJump < 0.5f)
        {
            ani.SetBool("jump2", true);
            Invoke("offaniCombat", 1.5f);
            timeDelayJump = 0;
        }
        else
        {
            timeDelayJump = 0.6f;
        }
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="hitenemy")
        {
            AnimatorStateInfo stateInfo = ani.GetCurrentAnimatorStateInfo(0); // Lấy thông tin về layer 0
            // Kiểm tra nếu state hiện tại có tên trùng với idleStateName
            if (stateInfo.IsName(nameAni)|| ani.GetBool("block")|| !ani.GetBool("block"))
            {
                nowhp -= damein/2;
                hp.updateHp(nowhp, maxhp);
                ani.SetBool("block", true);
                Invoke("offaniCombat", 0.5f);
            }
            else
            {
                nowhp-= damein;
                hp.updateHp(nowhp, maxhp);
                ani.SetBool("hit", true);
                Invoke("offaniCombat", 0.5f);
            }          
        }
    }
    void loss() { panelloss.SetActive(true);
        Time.timeScale = 0;
    }

    void offaniCombat()
    {
        ani.SetBool("jump2", false);
        ani.SetBool("jump1", false);
        ani.SetBool("punch2", false);
        ani.SetBool("punch1", false);
        ani.SetBool("hit", false);
        ani.SetBool("block", false);


    }
    public void updamein()
    {
        damein++;
    }
}
