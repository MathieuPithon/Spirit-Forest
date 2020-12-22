using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    public PlayerXp playerXp;
    public Slider slider;
    public Text txt;
    public int currentLevel;
    
    
    void Start () 
    {
        currentLevel = 1;
        DisplayXp();
     }

    public void SetXp(int xp)
    {
        slider.value = xp;
        DisplayXp();
    }
    public void SetLvl(int lvl, int maxXp)
    {
        currentLevel += lvl;
        slider.maxValue = maxXp;
        DisplayXp();
    }
    public void DisplayXp()
    {
        txt.text = "Level " + currentLevel +"\nCurrentXp: " + playerXp.currentXp + "/" + playerXp.maxXp;
    }
}
