using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
            instance = this;
        else
        {
            //Destroy(gameObject);
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
}
