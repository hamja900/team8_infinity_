using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public enum SfxIndex
{
    PAttackSound,PickUpSound,UsePotion
}

public class SoundManager : SingletoneBase<SoundManager>
{

    SoundData soundData;
    AudioSource[] chan;
    [Range(0, 1f)] public float volume = 1;
    private void Awake()
    {
        soundData = Resources.Load<SoundData>("SoundData");
        chan = new AudioSource[soundData.sfxs.Length];
        for (int i = 0; i < soundData.sfxs.Length; i++)
        {
            this.gameObject.AddComponent<AudioSource>().playOnAwake = false;
            chan[i] = gameObject.GetComponents<AudioSource>()[i];
        }
    }
    public void Play(SfxIndex index)
    {
        for (int i = 0; i < soundData.sfxs.Length; i++)
        {
            if (!chan[i].isPlaying)
            {
                chan[i].clip = soundData.sfxs[(int)index];
                chan[i].volume = volume;
                chan[i].Play();
                return;
            }
        }
    }
}
