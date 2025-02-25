using UnityEngine;
using UnityEngine.UI;

public class MuteToggle : MonoBehaviour
{
    public Toggle muteToggle;
    public AudioSource audioSource;

    private void Start()
    {
        muteToggle.isOn = audioSource.mute;
        muteToggle.onValueChanged.AddListener(SetMute);
    }

    private void SetMute(bool isMuted)
    {
        audioSource.mute = isMuted;
    }
}