using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLevel : MonoBehaviour
{
    public ControlEnemy controlEnemy;
    public CombatEnemy combbatEnemy;
    public CombatPlayer combatPlayer;

    int rand;

    int intLevel;


    private void Start()
    {
       intLevel= PlayerPrefs.GetInt("level");
        uplevel();
    }
     void uplevel()
    {
        for (int i = 2; i < intLevel*2; i++)
        {

            rand = Random.Range(1, 5);
            if (rand == 1)
            {
                combbatEnemy.uphp();
                Debug.Log("tăng máu");
            }
            else if (rand == 2)
            {
                controlEnemy.upspeed();
                Debug.Log("tăng tốc độ");

            }
            else if (rand == 3)
            {
                controlEnemy.uptimecombat();
                Debug.Log("giảm hồi chiêu");

            }
            else { combatPlayer.updamein();
                Debug.Log("tăng dame");
            }
        }
    }


}
