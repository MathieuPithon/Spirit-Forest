using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXp : MonoBehaviour
{
    
    public XpBar xpBar;
    public int currentXp;

    void Start()
    {
        currentXp = 0;
        xpBar.SetXp(currentXp);
    }

 
    public void XpGain(int gain)
    {
        if  (currentXp + gain >=10)
        {
            currentXp = (currentXp+gain)-10;
            xpBar.SetXp(currentXp);
            xpBar.SetLvl(1);
        }else
        {
            currentXp += gain;
            xpBar.SetXp(currentXp);
        }
    }
}
