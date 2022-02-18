using UnityEngine.UI;
using UnityEngine;
using System.Collections;

//Cyriaque - C'est pas moi qui l'ai fait mais en vrai il est ez a comprendre

public class Esprit_Xp : MonoBehaviour
{
    public GameObject levelUpAlarmUI;
    public Text levelUpAlarm;
    public XpBar xpBar;
    public GameObject levelUpSideUI;

    private int currentXp = 0;
    private int maxXp = 10;
    private int caracteristicsPoints = 0;




    void Start()
    {
        xpBar.SetXp(currentXp);
    }

    private void Update()
    {
        if (caracteristicsPoints > 0)
        {
            levelUpAlarm.text = $"Vous avez {caracteristicsPoints} points de compétence à dépenser !" +
                    $" Appuyez sur 'C' pour améliorer une de vos statistiques";
        }
        else levelUpAlarmUI.SetActive(false);


    }
    public void XpGain(int gain)
    {
        if (currentXp + gain >= maxXp)
        {
            currentXp = (currentXp + gain) - maxXp;
            maxXp += 2;
            xpBar.SetXp(currentXp);
            xpBar.SetLvl(1, maxXp);
            caracteristicsPoints += 1;
            levelUpSideUI.SetActive(true);
        }
        else
        {
            currentXp += gain;
            xpBar.SetXp(currentXp);
        }
    }

}
