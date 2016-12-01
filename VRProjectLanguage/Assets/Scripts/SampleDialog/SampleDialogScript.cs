using UnityEngine;
using System.Collections;

public class SampleDialogScript : MonoBehaviour {

    //Material change atrib
    public MeshRenderer _meshRenderer;
    public Color _color;
    public Color _alternativeColor;
    //AudioControlers
    public AudioSource _audioSource;
    public AudioClip _audioClip;
    // speech controller atrib
    float _volume = 40;
    int fLow = 200;
    int fHigh = 800;
    float[] freqData;
    int nSamples = 256;
    int fMax = 24000;
    float _voiceMinimumVolumeCoutOff = 0.1f;
    //average sound values
    int sizeFilter = 5;
    float[] filter;
    float filterSum;
    int posFilter = 0;
    int qSamples = 0;
    //mouth controllers
    public GameObject _mouth;
    public float _mouthIdlePosition_Y;
    //Animation controller
    public Animator _animationController;

	// Use this for initialization
	void Start () {
        _meshRenderer = GetComponent<MeshRenderer>();
        _color = _meshRenderer.material.color;
        _audioSource = GetComponent<AudioSource>();
        _animationController = GetComponent<Animator>();
        if (_audioClip.name != null)
        {
            _audioSource.clip = _audioClip;
        }
        else
        {
            Debug.Log("No hay archivo de audio cargado en el personaje");
        }
        freqData = new float[nSamples];
        _mouthIdlePosition_Y = _mouth.transform.position.y;
    }
	
	// Update is called once per frame
	void Update () {
        if (!_audioSource.isPlaying) _audioSource.Play();
        if (detectCharacterIsSpeaking())
        {
            speakAnimationController();
        } 
	}

    bool detectCharacterIsSpeaking()
    {
        return true;
    }

    void speakAnimationController()
    {
        float _speechVolumeResult = movingAverage(bandVol(fLow, fHigh)) * _volume;
        _animationController.SetFloat("_Intensity", _speechVolumeResult);
        if (_speechVolumeResult > _voiceMinimumVolumeCoutOff)
        {
            _animationController.SetBool("_Speaking", true);
            _meshRenderer.material.color = Color.blue;
            _mouth.transform.position = new Vector3 (_mouth.transform.position.x, _mouthIdlePosition_Y - _speechVolumeResult, _mouth.transform.position.z);
        }
        else
        {
            _meshRenderer.material.color = _color;
            _animationController.SetBool("_Speaking", false);
            _animationController.SetFloat("_Intensity", 0.0f);
        }
    }

    //Method unityAnswers http://answers.unity3d.com/questions/139323/any-way-of-quotautomaticquot-lip-syncing.html
    float bandVol (float fLow, float fHigh)
    {
        fLow = Mathf.Clamp(fLow, 20, fMax); // limit low...
        fHigh = Mathf.Clamp(fHigh, fLow, fMax); // and high frequencies
        _audioSource.GetSpectrumData(freqData, 0, FFTWindow.BlackmanHarris);
        int n1 = (int)Mathf.Floor(fLow * nSamples / fMax);
        int n2 = (int)Mathf.Floor(fHigh * nSamples / fMax);
        float sum = 0;
        //average the volumes of frequencies fLow to fHigh
        for (int i = n1; i <= n2; i++)
        {
            sum += freqData[i];
        }
        return (sum / ((n2 - n1) + 1));
    }

    float movingAverage (float sample)
    {
        if (qSamples == 0) filter = new float[sizeFilter];
        filterSum += sample - filter[posFilter];
        filter[posFilter++] = sample;
        if (posFilter > qSamples) qSamples = posFilter;
        posFilter = posFilter % sizeFilter;
        return (filterSum / qSamples);
    }

}
