using UnityEngine;
using UnityEngine.Audio;

public class VolumeControls : MonoBehaviour
{
    public AudioMixer masterMixer;
    
    public void SetSFX(float sfx)
    {
        masterMixer.SetFloat("sfx", sfx);
    }

    public void SetMusic(float music)
    {
        masterMixer.SetFloat("music", music);
    }

    public void SetOnOff(float volume)
    {
        masterMixer.SetFloat("volume", volume);
    }
}
