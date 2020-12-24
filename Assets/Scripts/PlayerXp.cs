using UnityEngine.UI;
using UnityEngine;

public class PlayerXp : MonoBehaviour
{
    public GameObject levelUpAlarmUI;
    public Text levelUpAlarm;
    public XpBar xpBar;
    public int currentXp;
    public int maxXp;
    public int caracteristicsPoints = 0;

    void Start()
    {
        maxXp = 10;
        currentXp = 0;
        xpBar.SetXp(currentXp);
    }

    private void Update()
    {
        levelUpAlarm.text = "Vous avez pris un niveau ! Appuyez sur 'C' pour améliorer une de vos statistiques";
        if (caracteristicsPoints > 0)
            levelUpAlarmUI.SetActive(true);
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
            
        }else
        {
            currentXp += gain;
            xpBar.SetXp(currentXp);
        }
    }
}
