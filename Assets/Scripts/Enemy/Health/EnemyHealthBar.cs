using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
    Initialise la barre des points de vies
**/
public class EnemyHealthBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;

//permet de définir le nombre de pv max que le héros peut avoir, c'est cette valeur que les potions de HealthBuff permettent d'augmenter
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    //Permet de définir les points de vies du héros pour l'instance actuelle
    public void SetHealth(float health)
    {
        slider.value = health;
    }
}
