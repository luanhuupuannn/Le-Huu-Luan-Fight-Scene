using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hp : MonoBehaviour
{
    public Image hp;
    public void updateHp(float nowhp, float maxhp)
    {
        hp.fillAmount = nowhp/maxhp;
    }
    
}
