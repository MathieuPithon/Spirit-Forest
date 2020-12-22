using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXp : MonoBehaviour
{
    
    public XpBar xpBar;
    public int currentXp;
    public int maxXp;

    void Start()
    {
        maxXp = 10;
        currentXp = 0;
        xpBar.SetXp(currentXp);
    }

 
    public void XpGain(int gain)
    {
        if  (currentXp + gain >=maxXp)
        {
            currentXp = (currentXp+gain)-maxXp;
            maxXp += 2;
            xpBar.SetXp(currentXp);
            xpBar.SetLvl(1, maxXp);
        }else
        {
            currentXp += gain;
            xpBar.SetXp(currentXp);
        }
    }
}
