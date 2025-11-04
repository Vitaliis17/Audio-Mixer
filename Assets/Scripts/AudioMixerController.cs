using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;

    private readonly float _minVolume = -80f;

    private float _currentVolume;

    private void Awake()
        => _audioMixer.GetFloat(ExposedParameterNames.MasterVolume, out _currentVolume);

    public void SwapVolumeState()
    {
        if (IsTurnedOn())
        {
            TurnOff();
            return;
        }

        TurnOn();
    }

    public void SetMasterVolume(float volume)
        => SetVolume(volume, ExposedParameterNames.MasterVolume);

    public void SetButtonsVolume(float volume)
        => SetVolume(volume, ExposedParameterNames.ButtonsVolume);

    public void SetBackgroundVolume(float volume)
        => SetVolume(volume, ExposedParameterNames.BackgroundVolume);

    private void SetVolume(float value, string name)
    {
        _currentVolume = Mathf.Log10(value) * 20;

        _audioMixer.SetFloat(name, _currentVolume);
    }

    private bool IsTurnedOn()
    {
        if (_audioMixer.GetFloat(ExposedParameterNames.MasterVolume, out float volume))
            return volume > _minVolume;

        return false;
    }

    private void TurnOff()
        => _audioMixer.SetFloat(ExposedParameterNames.MasterVolume, _minVolume);
    
    private void TurnOn()
        => _audioMixer.SetFloat(ExposedParameterNames.MasterVolume, _currentVolume);
}
