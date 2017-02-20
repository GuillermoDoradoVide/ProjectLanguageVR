using UnityEngine;
using System.Collections;

public class DialogScript : MonoBehaviour {

    public AudioClip dialog;
    public AudioSource audioSource;
    public Animator animationController;
    public AnimationState animationState;
    // speech controller atrib
    float volume = 40;
    int fLow = 200;
    int fHigh = 800;
    float[] freqData;
    int nSamples = 256;
    int fMax = 24000;
    float voiceMinimumVolumeCoutOff = 0.001f;
    //average sound values
    int sizeFilter = 5;
    float[] filter;
    float filterSum;
    int posFilter = 0;
    int qSamples = 0;
    //new
    public int qSamples2 = 1024;        // array size
    public float refValue = 0.1f;    // RMS value for 0 dB
    public float rmsValue;            // sound level - RMS
    public float dbValue;            // sound level - dB
    public float volume2 = 2;        // set how much the scale will vary
    private float[] samples;        // audio sample

    private void Start()
    {
        samples = new float[qSamples2];
        freqData = new float[nSamples];
        if (dialog == null)
        {
            Debug.Log("No hay archivo de audio cargado.");
        }
    }

    private void OnEnable()
    {
        EventManager.addDialogListener(setNewAudioClip);
    }

    private void OnDisable()
    {
        EventManager.removeDialogListener(setNewAudioClip);
    }

    public bool playUpdateDialog()
    {
        if (audioSource.isPlaying)
        {
            speakAnimationController();
            return true;
        }
        else
        {
			animationController.SetLayerWeight (2, 0);
            return false;
        }
    }

    public void initDialog()
    {
        audioSource.clip = dialog;
        audioSource.Play();
    }

    public void stopDialog()
    {
        Debug.Log("parar el dialogo.");
        audioSource.Stop();
		animationController.SetLayerWeight (2, 0);
    }

    public void pauseDialog()
    {
        Debug.Log("pausar el dialogo");
        audioSource.Pause();
		animationController.SetLayerWeight (2, 0);
    }

    public void continueDialog()
    {
        audioSource.UnPause();
    }

    private void setNewAudioClip(AudioClip audioClip)
    {
        dialog = audioClip;
    }

    private void speakAnimationController()
    {
        GetVolume();
        float speechVolumeResult = movingAverage(bandVol(fLow, fHigh)) * volume;
		animationController.SetLayerWeight (2, speechVolumeResult * 2);

        if (speechVolumeResult < voiceMinimumVolumeCoutOff)
        {
			animationController.SetLayerWeight (2, 0);
        }
    }

    //Method unityAnswers http://answers.unity3d.com/questions/139323/any-way-of-quotautomaticquot-lip-syncing.html
    private float bandVol(float fLow, float fHigh)
    {
        fLow = Mathf.Clamp(fLow, 20, fMax); // limit low...
        fHigh = Mathf.Clamp(fHigh, fLow, fMax); // and high frequencies
        audioSource.GetSpectrumData(freqData, 0, FFTWindow.BlackmanHarris);
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

    private float movingAverage(float sample)
    {
        if (qSamples == 0) filter = new float[sizeFilter];
        filterSum += sample - filter[posFilter];
        filter[posFilter++] = sample;
        if (posFilter > qSamples) qSamples = posFilter;
        posFilter = posFilter % sizeFilter;
        return (filterSum / qSamples);
    }

    private void GetVolume()
    {
        audioSource.GetOutputData(samples, 0);    // fill array with samples
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

}
