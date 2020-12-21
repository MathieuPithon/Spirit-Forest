﻿using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    public Slider slider;
    public Text txt;
    public int currentLevel;
    
    void Start () 
    {
        currentLevel = 1;
         txt.text = "Level " + currentLevel;
     }

    public void SetXp(int xp)
    {
        slider.value = xp;
    }
    public void SetLvl(int lvl, int maxXp)
    {
        slider.maxValue = maxXp;
        currentLevel += lvl;
        txt.text = "Level " + currentLevel;
    }
}
