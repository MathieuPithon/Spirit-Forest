using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXp : MonoBehaviour
{
    
    public XpBar xpBar;
    public int currentXp;
    public int maxXP;

    void Start()
    {
        maxXP = 10;
        currentXp = 0;
        xpBar.SetXp(currentXp);
    }

 
    public void XpGain(int gain)
    {
        if  (currentXp + gain >=maxXP)
        {
            currentXp = (currentXp+gain)-maxXP;
            maxXP += 2;
            xpBar.SetXp(currentXp);
            xpBar.SetLvl(1, maxXP);
        }else
        {
            currentXp += gain;
            xpBar.SetXp(currentXp);
        }
    }
}
