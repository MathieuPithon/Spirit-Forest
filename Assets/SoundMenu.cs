
using UnityEngine;
using UnityEngine.UI;

public class SoundMenu : MonoBehaviour
{
    public Slider mainVolume;
    public Text mainTxt;
    public Slider musicVolume;
    public Text musicTxt;
    public Slider soundVolume;
    public Text soundTxt;
    public Slider voiceVolume;
    public Text voiceTxt;

    void Update()
    {
        mainTxt.text = mainVolume.value.ToString();
        musicTxt.text = musicVolume.value.ToString();
        soundTxt.text = soundVolume.value.ToString();
        voiceTxt.text = voiceVolume.value.ToString();
    }
}
