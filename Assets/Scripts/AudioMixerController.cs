using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class AudioMixerController : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixerGroup;
    
    private Button _button;
    private float _currentVolume;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _mixerGroup.audioMixer.GetFloat(_mixerGroup.name, out _currentVolume);
    }

    private void OnEnable()
        => _button.onClick.AddListener(SwapVolumeState);

    private void OnDisable()
        => _button.onClick.RemoveListener(SwapVolumeState);

    private void SwapVolumeState()
    {
        if (IsTurnedOn())
        {
            TurnOff();
            return;
        }

        TurnOn();
    }

    private bool IsTurnedOn()
    {
        if (_mixerGroup.audioMixer.GetFloat(_mixerGroup.name, out float volume))
            return volume > AudioMixerCharacteristics.MinVolume;

        return false;
    }

    private void TurnOff()
        => _mixerGroup.audioMixer.SetFloat(_mixerGroup.name, AudioMixerCharacteristics.MinVolume);
    
    private void TurnOn()
        => _mixerGroup.audioMixer.SetFloat(_mixerGroup.name, _currentVolume);
}