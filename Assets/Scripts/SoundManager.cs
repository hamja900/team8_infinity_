using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public enum SfxIndex
{
    PAttackSound,PickUpSound,UsePotion,Walk
}

public class SoundManager : SingletoneBase<SoundManager>
{
    SoundData soundData;
    [Header("Bgm")]
    AudioSource audio;
    [Range(0, 1)] public float volum = 1;
    [Header("Sfx")]
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
        audio = gameObject.AddComponent<AudioSource>();
        audio.playOnAwake = false;
    }
    public void Play(SfxIndex index)
    {
        for (int i = 0; i < soundData.sfxs.Length; i++)
        {
            if (!chan[i].isPlaying)
            {
                chan[i].clip = soundData.sfxs[(int)index];
                chan[i].volume = volume;
                chan[i].pitch = 1f;
                chan[i].Play();
                return;
            }
        }
    }
    public void Play(SfxIndex index,float Pitch)
    {
        for (int i = 0; i < soundData.sfxs.Length; i++)
        {
            if (!chan[i].isPlaying)
            {
                chan[i].clip = soundData.sfxs[(int)index];
                chan[i].volume = volume;
                chan[i].pitch = Pitch;
                chan[i].Play();
                return;
            }
        }
    }
}
