using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class CombatEnemy : MonoBehaviour
{
    public Hp hp;
    float maxhp = 10;
    float nowhp ;
    public GameObject Enemytag;
    Animator animator;
    string nameAni = "Idle";
    int randCombat = 0;

    // Start is called before the first frame update
    void Start()
    {
        nowhp = maxhp;
        hp.updateHp(nowhp, maxhp);
        animator = GetComponent<Animator>();
    }
    public void uphp()
    {
        maxhp += 50;
        nowhp = maxhp;

    }
    // Update is called once per frame
    void Update()
    {
        hp.updateHp(nowhp, maxhp);

        if (nowhp <= 0) 
        {
            Destroy(Enemytag.gameObject);
            animator.SetBool("knock", true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "hitplayer")
        {
            AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0); // Lấy thông tin về layer 0
            // Kiểm tra nếu state hiện tại có tên trùng với idleStateName
            if (stateInfo.IsName(nameAni) || animator.GetBool("block") || !animator.GetBool("block"))
            {
                nowhp -= 0.5f;
               // hp.updateHp(nowhp, maxhp);
                animator.SetBool("block", true);
                Invoke("offani", 0.5f);
            }
            else {
                nowhp--;
              //  hp.updateHp(nowhp, maxhp);
                animator.SetBool("hit", true);
                Invoke("offani", 0.5f);

                

            }
           

            
        }
    }
    public void combat()
    {
        randCombat = Random.Range(1,5);
       if(randCombat == 1) 
        {
            animator.SetBool("punch1", true);
        }
       else if  (randCombat == 2)
        {
            animator.SetBool("punch2", true);
        }
        else if (randCombat == 3)
        {
            animator.SetBool("jump1", true);
        }
        else
        {
            animator.SetBool("jump2", true);
        }
        Invoke("offani", 1.5f);
    }
    void offani()
    {
        animator.SetBool("punch1", false);
        animator.SetBool("punch2", false);
        animator.SetBool("jump1", false);
        animator.SetBool("jump2", false);
        animator.SetBool("hit", false);
        animator.SetBool("block", false);

    }
}
