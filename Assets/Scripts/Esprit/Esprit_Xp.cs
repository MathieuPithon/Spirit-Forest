using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class Esprit_Xp : MonoBehaviour
{
    public GameObject levelUpAlarmUI;
    public Text levelUpAlarm;
    public XpBar xpBar;
    public GameObject levelUpSideUI;

    [HideInInspector]
    public int currentXp = 0;
    [HideInInspector]
    public int maxXp = 10;
    [HideInInspector]
    public int caracteristicsPoints = 0;



    void Start()
    {
        xpBar.SetXp(currentXp);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            XpGain(10);
        }
        if (caracteristicsPoints > 0)
        {
            levelUpAlarm.text = $"Vous avez {caracteristicsPoints} points de compétence à dépenser !" +
                    $" Appuyez sur 'C' pour améliorer une de vos statistiques";
            levelUpAlarmUI.SetActive(true);
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
