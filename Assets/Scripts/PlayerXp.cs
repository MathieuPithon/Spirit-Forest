using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class PlayerXp : MonoBehaviour
{
    public GameObject levelUpAlarmUI;
    public Text levelUpAlarm;
    public XpBar xpBar;
    public CaracteristicsWindow levelUpSideUI;
    public int currentXp;
    public int maxXp;
    public int caracteristicsPoints = 0;
    
    public Animator fadeSystem;


    void Start()
    {
        maxXp = 10;
        currentXp = 0;
        xpBar.SetXp(currentXp);
    }

    private void Update()
    {
        
        if (caracteristicsPoints > 0)
        {
            levelUpAlarm.text = "Vous avez 1 point de compétence à dépenser ! Appuyez sur 'C' pour améliorer une de vos statistiques";
            levelUpAlarmUI.SetActive(true);
            if(caracteristicsPoints > 1)
                levelUpAlarm.text = $"Vous avez {caracteristicsPoints} points de compétence à dépenser !" +
                    $" Appuyez sur 'C' pour améliorer une de vos statistiques";
        }        
        else levelUpAlarmUI.SetActive(false);

        
    }
    public void XpGain(int gain)
    {
        if  (currentXp + gain >=maxXp)
        {
            currentXp = (currentXp+gain)-maxXp;
            maxXp += 2;
            xpBar.SetXp(currentXp);
            xpBar.SetLvl(1, maxXp);
            caracteristicsPoints += 1;
            levelUpSideUI.levelUpUI.SetActive(true);
        }
        else
        {
            currentXp += gain;
            xpBar.SetXp(currentXp);
        }
    }
    
}
