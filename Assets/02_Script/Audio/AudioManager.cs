using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource sfxSource;

    public AudioSource BgmSource => bgmSource;
    public AudioSource SfxSource => sfxSource;

    [SerializeField] private List<AudioData> bgmClips;
    [SerializeField] private List<AudioData> sfxClips;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(transform);
        }
    }

    public void SetBgmVolume(float value)
    {
        bgmSource.volume = value;
    }

    public void SetSfxVolume(float value)
    {
        sfxSource.volume = value;
    }

    public void StartBgm(string name)
    {
        AudioData data = bgmClips.Find(x => x.audioName == name);
        if (ReferenceEquals(data, null)) return;

        bgmSource.clip = data.audioClip;
        bgmSource.Play();
    }

    public void StartSfx(string name)
    {
        AudioData data = sfxClips.Find(x => x.audioName == name);
        if (ReferenceEquals(data, null)) return;

        sfxSource.clip = data.audioClip;
        sfxSource.Play();
    }
}
