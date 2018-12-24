using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sounds
{
    BUTTON_SOUND = 0,
    END_SOUND = 1
}

public class SoundManagerScriptGM : MonoBehaviour
{
    private float soundLevel;

    public AudioClip buttonSound;
    public AudioClip endSound;

    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        		
	}

    public void UpdateSoundLevel(float soundLvl)
    {
        soundLevel = soundLvl;
        transform.GetComponent<AudioSource>().volume = soundLvl;
    }

    public void SetSoundLevel()
    {
        gameObject.AddComponent<AudioSource>();
        gameObject.GetComponent<AudioSource>().playOnAwake = false;
        gameObject.GetComponent<AudioSource>().clip = buttonSound;
        if (PlayerPrefs.HasKey("SoundLevelGM"))
        {
            UpdateSoundLevel(PlayerPrefs.GetFloat("SoundLevelGM"));
        }
        else
        {
            UpdateSoundLevel(1.0f);
            PlayerPrefs.SetFloat("SoundLevelGM", 1.0f);
        }
    }

    public float GetSoundLevel()
    {
        return soundLevel;
    }

    public void PlaySound(Sounds sound)
    {
        int index = (int)sound;
        switch (index)
        {
            case 0:
                gameObject.GetComponent<AudioSource>().PlayOneShot(buttonSound);
                break;
            case 1:
                gameObject.GetComponent<AudioSource>().PlayOneShot(endSound);
                break;
            default:
                break;
        }
    }
}
