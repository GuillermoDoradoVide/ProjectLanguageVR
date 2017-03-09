using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : SingletonComponent<SoundManager> {

    public AudioSource sfxSource;
    public AudioSource musicSource;
    [Range(0.8f, 1.0f)]
    public float lowPitchRange;
    [Range(1.0f, 1.2f)]
    public float highPitchRange;
    [SerializeField]
    private AudioClip[] musicBox;

    private void Awake()
    {

    }

    public void playSingleSFXSound(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Play();
    }

	public void playSingleRandomSFXSound(AudioClip clip)
	{
		sfxSource.clip = clip;
		float randomPitch = Random.Range(lowPitchRange, highPitchRange);
		sfxSource.pitch = randomPitch;
		sfxSource.Play();
	}

	public bool getSfxSoundFinished() {
		return sfxSource.isPlaying;
	}

    public void playRandomSFXSound(params AudioClip[] clips)
    {
        int randomIndex = Random.Range(0, clips.Length);
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        sfxSource.clip = clips[randomIndex];
        sfxSource.pitch = randomPitch;
        sfxSource.Play();
    }

    public void setNewMusicBox(params AudioClip[] songs)
    {
        musicBox = songs;
        musicSource.clip = songs[0];
    }

    public void playRandomMusicSong()
    {
        int randomIndex = Random.Range(0, musicBox.Length);
        musicSource.clip = musicBox[randomIndex];
        musicSource.Play();
    }

    public void playMusicSong(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }
}
