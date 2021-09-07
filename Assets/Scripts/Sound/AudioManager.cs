using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    public OnOffToggle onOff;

    private bool isAllMute;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            CheckIfMute();
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in instance.sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnAwake;
        }
        CheckIfMute();

    }

    private void CheckIfMute()
    {
        instance.isAllMute = PlayerPrefs.GetInt("IsMute") == 1 ? true : false;

        if (instance.isAllMute == true && onOff != null)
        {
            onOff.ToggleKnob();
            ToggleMute();
        }
    }

    public void Play(string name)
    {
        foreach (Sound s in instance.sounds)
        {
            if(s.name == name)
            {
                s.source.Play();
            }
        }
    }

    public void ResetAllPitch()
    {
        foreach (Sound s in instance.sounds)
        {
            s.pitch = 1.0f;
            s.source.pitch = s.pitch;
        }
    }

    public void ToggleMute()
    {
        bool isMute = !instance.sounds[0].source.mute;
        instance.isAllMute = isMute;
        int temp = isMute ? 1 : 0;
        PlayerPrefs.SetInt("IsMute", temp);

        foreach (Sound s in instance.sounds)
        {
            s.source.mute = isMute;
        }
    }
}
