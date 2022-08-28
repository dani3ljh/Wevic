using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    
    void Awake()
    {
        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = s.playOnStart;
        }
    }
    
    // Playsound method returns the length of the sound
    public float PlaySound(string name)
    {
        Sound s = System.Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning($"Sound {name} not found!");
            return 0f;
        }
        s.source.Play();
        return s.clip.length;
    }
}
