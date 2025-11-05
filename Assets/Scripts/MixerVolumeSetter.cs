using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class MixerVolumeSetter : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixerGroup;
    
    private Slider _slider;
    private float _currentVolume;

    private void Awake()
    {
        _slider = GetComponent<Slider>();
        _mixerGroup.audioMixer.GetFloat(_mixerGroup.name, out _currentVolume);
    }

    private void OnEnable()
        => _slider.onValueChanged.AddListener(SetVolume);

    private void OnDisable()
        => _slider.onValueChanged.RemoveListener(SetVolume);

    private void SetVolume(float value)
    {
        const float MinValue = 0f;
        const int VolumeMultiplier = 20;

        _currentVolume = Mathf.Approximately(value, MinValue) ? AudioMixerCharacteristics.MinVolume : Mathf.Log10(value) * VolumeMultiplier;
        _mixerGroup.audioMixer.SetFloat(_mixerGroup.name, _currentVolume);
    }
}