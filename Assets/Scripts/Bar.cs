using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class Bar : MonoBehaviour
{
    [SerializeField] private Health _health;

    private Slider _slider;
    
    private void Awake()
        => _slider = GetComponent<Slider>();

    private void OnEnable()
    {
        _health.MaxValueChanged += SetMaxValue;
        _health.CurrentValueChanged += SetValue;
    }

    private void OnDisable()
    {
        _health.MaxValueChanged -= SetMaxValue;
        _health.CurrentValueChanged -= SetValue;
    }

    private void SetMaxValue(int value)
        => _slider.maxValue = value;

    public float GetMaxValue()
        => _slider.maxValue;

    private void SetValue(int value)
        => _slider.value = value;

    public float GetValue()
        => _slider.value;

    public bool IsFull()
        => Mathf.Approximately(_slider.value, _slider.maxValue);
}