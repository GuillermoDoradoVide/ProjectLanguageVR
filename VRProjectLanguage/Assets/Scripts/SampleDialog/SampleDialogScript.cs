using UnityEngine;
using System.Collections;
using System;

public class SampleDialogScript : StateScript
{
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
    float _voiceMinimumVolumeCoutOff = 0.001f;
    //average sound values
    int sizeFilter = 5;
    float[] filter;
    float filterSum;
    int posFilter = 0;
    int qSamples = 0;
    //mouth controllers
    public GameObject _mouth;
    public GameObject _intensity;
    public float _mouthIdlePosition_Y;
    //Animation controller
    public Animator _animationController;
    public AnimationState _animationState;
    public bool _finished = false;

    //new
    public int qSamples2 = 1024;        // array size
    public float refValue = 0.1f;    // RMS value for 0 dB
    public float rmsValue;            // sound level - RMS
    public float dbValue;            // sound level - dB
    public float volume2 = 2;        // set how much the scale will vary
    private float[] samples;        // audio sample

    // Use this for initialization
    public override void doAtStart()
    {
        if (_audioClip != null)
        {
            _color = _meshRenderer.material.color;
            _audioSource = GetComponent<AudioSource>();
            //_animationController = GetComponent<Animator>();
            samples = new float[qSamples2];
            freqData = new float[nSamples];
            _mouthIdlePosition_Y = _mouth.transform.position.y;
        }
        else
        {
            Debug.Log("No hay archivo de audio cargado en el estado");
        }
    }

    // Update is called once per frame
    public override void doUpdate()
    {
        playSound();
    }

    public void StartSound()
    {
        //Debug.Log("StartSound: " + _audioClip.name);
        _audioSource.clip = _audioClip;
        _audioSource.PlayOneShot(_audioSource.clip);
    }

    public void playSound()
    {
        if (_audioSource.isPlaying)
        {
            speakAnimationController();
        }
        else
        {
            _animationController.SetFloat("_Intensity", 0);
            changeThisStateToFinished();
        }
    }

    public void speakAnimationController()
    {
        GetVolume();
        _intensity.transform.localScale = new Vector3(_intensity.transform.localScale.x, /*volume2 * */rmsValue, _intensity.transform.localScale.z);

        float _speechVolumeResult = movingAverage(bandVol(fLow, fHigh)) * _volume;
        //Debug.Log("Final: " + _speechVolumeResult);
        _animationController.SetFloat("_Frequency", _speechVolumeResult);
        //_animationController.Play("Talk", -1, rmsValue * 2);

        //_animationState = _animationController.GetCurrentAnimatorStateInfo(0);
        _animationController.SetFloat("_Intensity", rmsValue);
        if (_speechVolumeResult > _voiceMinimumVolumeCoutOff)
        {
            _animationController.SetBool("_Speaking", true);
            _meshRenderer.material.color = Color.blue;
            _mouth.transform.position = new Vector3(_mouth.transform.position.x, _mouthIdlePosition_Y - _speechVolumeResult, _mouth.transform.position.z);
        }
        else
        {
            _meshRenderer.material.color = _color;
            _animationController.SetBool("_Speaking", false);
            _animationController.SetFloat("_Intensity", 0.0f);
        }
        //Debug.Log("Comparación: [" + movingAverage(bandVol(fLow, fHigh)) + "] :: [" + rmsValue + "]");
    }

    //Method unityAnswers http://answers.unity3d.com/questions/139323/any-way-of-quotautomaticquot-lip-syncing.html
    float bandVol(float fLow, float fHigh)
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
        //Debug.Log("Inicial: " + (sum / ((n2 - n1) + 1)));
        return (sum / ((n2 - n1) + 1));
    }

    float movingAverage(float sample)
    {
        if (qSamples == 0) filter = new float[sizeFilter];
        filterSum += sample - filter[posFilter];
        filter[posFilter++] = sample;
        if (posFilter > qSamples) qSamples = posFilter;
        posFilter = posFilter % sizeFilter;
        return (filterSum / qSamples);
    }

    void GetVolume()
    {
        _audioSource.GetOutputData(samples, 0);    // fill array with samples
        float sum = 0;
        for (int i = 0; i < qSamples2; i++)
        {
            sum += samples[i] * samples[i];    // sum squared samples
        }
        rmsValue = Mathf.Sqrt(sum / qSamples2);    // rms = square root of average
        dbValue = 20 * Mathf.Log10(rmsValue / refValue);    // calculate dB
        if (dbValue < -160)
        {
            dbValue = -160;        // clamp it to -160 dB min
        }
    }
    [ContextMenu("prueba de context menu")]
    void pruebaDeContextMenu()
    {
        Debug.Log("Hola Guillermo, ¿Qué tal el context menu?");
    }
}
