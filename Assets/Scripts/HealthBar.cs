using UnityEngine;
using UnityEngine.UI;
//responsable de l'affichage et de la gestion des HP
public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue); //normalized transforme la valeur en valeur comprise entre 0 et 1
    }

}
