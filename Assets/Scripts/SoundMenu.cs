
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundMenu : MonoBehaviour
{
    public Slider mainVolume;
    public Text mainTxt;
    public AudioMixer audioMixer;

    public GameObject player;
        

    void Update()
    {
        mainTxt.text = ((mainVolume.value+80)*1.25).ToString();

    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
