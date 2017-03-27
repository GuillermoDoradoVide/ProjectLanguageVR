using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : SingletonComponent<SoundManager> {

	public List<AudioSource> sfxSources;
    public AudioSource musicSource;
	public AudioClip[] musicBox;
	[Header ("Sound variations")]
    [Range(0.8f, 1.0f)]
    public float lowPitchRange;
    [Range(1.0f, 1.2f)]
    public float highPitchRange;

	[Header ("Sound State")]
	public static bool isMuted = false;
	public const float maxVolume_Music = 1f;
	public const float maxVolume_SFX = 1f;
	public static float currentVolumenNormalized_Music = 1f;
	public static float currentVolumenNormalized_SFX = 1f;    
	// init methods
    private void Awake()
    {
		if (sfxSources == null) {
			sfxSources = new List<AudioSource> ();
		}
		if (musicSource == null) {
			musicSource = gameObject.AddComponent<AudioSource> () as AudioSource;
		}
    }

	// controller methods

	static float getMusicVolume() {
		return isMuted ? 0f : maxVolume_Music * currentVolumenNormalized_Music;
	}

	static float getSFXVolume() {
		return isMuted ? 0f : maxVolume_SFX * currentVolumenNormalized_SFX;
	}

	private void fadeMusicOut(float fadeDuration) {
		float toVolume = 0;
		if(musicSource.clip != null) {
			StartCoroutine (fadeMusic (toVolume, fadeDuration));
		}
		else {
			Debug.LogError ("Error: Could not fade Music out as Music AudioSource has no currently playing clip.");
		}
	}

	private void fadeMusicIn(AudioClip newMusic, float delay, float  fadeDuration) {
		StartCoroutine (fadeIn(newMusic, delay, fadeDuration));
	}

	private IEnumerator fadeIn(AudioClip newMusic, float delay, float  fadeDuration) {
		yield return new WaitForSeconds (delay);
		musicSource.clip = newMusic;
		musicSource.Play ();
		float toVolume = getMusicVolume ();
		StartCoroutine (fadeMusic (toVolume, fadeDuration));
	}

	private IEnumerator fadeMusic(float fadeToVolume, float duration) {
		float elapsed = 0;
		float t;
		float volume;
		float currentVolume = musicSource.volume;
		while (duration >= elapsed) {
			t = (elapsed / duration);
			volume = Mathf.Lerp (currentVolume, fadeToVolume * currentVolumenNormalized_Music, t);
			musicSource.volume = volume;
			elapsed += Time.deltaTime;
			yield return 0;
		}
		musicSource.volume = fadeToVolume * currentVolumenNormalized_Music;
	}

	public static void playMusic (AudioClip music, bool fade, float fadeDuration = 1f) {
		SoundManager manager = Instance;
		if(fade) {
			if(manager.musicSource.isPlaying) {
				manager.fadeMusicOut (fadeDuration/2f);
				manager.fadeMusicIn (music, fadeDuration/2f, fadeDuration/2f);
			}
			else {
				float delay = 0f;
				manager.fadeMusicIn (music, delay, fadeDuration);
			}
		}
		else {
			manager.musicSource.volume = getMusicVolume ();
			manager.musicSource.clip = music;
			manager.musicSource.Play ();
		}
	}

	public static void stopMusic (bool fade, float fadeDuration = 1f) {
		SoundManager manager = Instance;
		if(manager.musicSource.isPlaying) {
			if(fade){
				manager.fadeMusicOut (fadeDuration);
			}
			else {
				manager.musicSource.Stop ();
			}
		}
	}

	public static void playRandomMusic() {
		playMusic (SoundManager.Instance.musicBox[Random.Range(0,SoundManager.Instance.musicBox.Length)], true);
	}

	//[SECTCION] = SFX SOUND 
	/*************************/
	AudioSource getSFXSource() {
		AudioSource sfxSound = gameObject.AddComponent<AudioSource> () as AudioSource;
		sfxSound.loop = false;
		sfxSound.playOnAwake = false;
		sfxSound.volume = getSFXVolume ();
		sfxSources.Add (sfxSound);
		return sfxSound;
	}

	IEnumerator removeSFXSource(AudioSource sfxSound) {
		yield return new WaitForSeconds (sfxSound.clip.length);
		sfxSources.Remove (sfxSound);
		Destroy (sfxSound);
	}

	IEnumerator removeSFXSourceFixedLength(AudioSource sfxSound, float length) {
		yield return new WaitForSeconds (length);
		sfxSources.Remove (sfxSound);
		Destroy (sfxSound);
	}

	// SFX FUNCTIONS
	public static void playSFX(AudioClip sfxSound) {
		SoundManager manager = Instance;
		AudioSource source = manager.getSFXSource ();
		source.volume = getSFXVolume ();
		source.clip = sfxSound;
		source.Play ();
		manager.StartCoroutine (manager.removeSFXSource(source));
	}

	public static void playSFXRandomized (AudioClip sfxSound) {
		SoundManager manager = Instance;
		AudioSource source = manager.getSFXSource ();
		source.volume = getSFXVolume ();
		source.clip = sfxSound;
		source.pitch = Random.Range (manager.lowPitchRange, manager.highPitchRange);
		source.Play ();
		manager.StartCoroutine (manager.removeSFXSource(source));		
	}

	public static void playSFXFixedDuration(AudioClip sfxSound, float duration, float volumenMultiplier = 1.0f) {
		SoundManager manager = Instance;
		AudioSource source = manager.getSFXSource ();
		source.volume = getSFXVolume () * volumenMultiplier;
		source.clip = sfxSound;
		source.loop = true;
		source.pitch = Random.Range (0.85f, 1.2f);
		source.Play ();
		manager.StartCoroutine (manager.removeSFXSourceFixedLength(source, duration));	
	}


	// volume control functions

	public static void disableSoundImmediate() {
		SoundManager manager = Instance;
		manager.StopAllCoroutines ();
		if(manager.sfxSources != null) {
			for (int i = 0; i < manager.sfxSources.Count - 1; i++) {
				manager.sfxSources [i].volume = 0;
			}
		}
		manager.musicSource.volume = 0;
		isMuted = true;
	}

	public static void enableSoundImmediate() {
		SoundManager manager = Instance;
		if(manager.sfxSources != null) {
			for (int i = 0; i < manager.sfxSources.Count - 1; i++) {
				manager.sfxSources [i].volume = getSFXVolume();
			}
		}
		manager.musicSource.volume = getMusicVolume();
		isMuted = false;
	}

	public static void setGlobalVolume(float newVolume) {
		currentVolumenNormalized_Music = newVolume;
		currentVolumenNormalized_SFX = newVolume;
		adjustSoundImmediate();
	}

	public static void setSFXVolume (float newVolume) {
		currentVolumenNormalized_SFX = newVolume;
		adjustSoundImmediate();
	}

	public static void setMusicVolume (float newVolume) {
		currentVolumenNormalized_SFX = newVolume;
		adjustSoundImmediate();
	}

	public static void adjustSoundImmediate() {
		SoundManager manager = Instance;
		if(manager.sfxSources != null) {
			for (int i = 0; i < manager.sfxSources.Count - 1; i++) {
				manager.sfxSources [i].volume = getSFXVolume();
			}
		}
		Debug.Log ("Music volume: " + getMusicVolume());
		manager.musicSource.volume = getMusicVolume();
		Debug.Log ("Music volume is now: " + getMusicVolume());
	}

	// sound manager methods

	public static void setMusicBox(params AudioClip[] musics)
	{
		Debug.Log ("setMusicBox");
		Instance.musicBox = musics;
	}
}
