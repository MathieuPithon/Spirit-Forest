using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXp : MonoBehaviour
{
    
    public XpBar xpBar;
    public int currentXp;
    public int maxXp = 10;

    void Start()
    {
        currentXp = 0;
        xpBar.SetXp(currentXp);
    }

 
    public void XpGain(int gain)
    {
        if  (currentXp + gain >= maxXp)
        {
            currentXp = (currentXp+gain)- maxXp;
            xpBar.SetXp(currentXp);
            xpBar.SetLvl(1);
        }else
        {
            currentXp += gain;
            xpBar.SetXp(currentXp);
        }
    }
}
