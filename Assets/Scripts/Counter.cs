using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Counter : MonoBehaviour
{
    [SerializeField] private Health _health;

    private TextMeshProUGUI _text;

    private int _currentValue;
    private int _maxValue;

    private void Awake()
        => _text = GetComponent<TextMeshProUGUI>();

    private void OnEnable()
    {
        _health.MaxValueChanged += SetMax;
        _health.CurrentValueChanged += SetCurrent;
    }

    private void OnDisable()
    {
        _health.MaxValueChanged -= SetMax;
        _health.CurrentValueChanged -= SetCurrent;
    }

    public void SetCurrent(int current)
    {
        _currentValue = current;

        SetText();
    } 

    public void SetMax(int max)
    {
        _maxValue = max;

        SetText();
    }

    private void SetText()
    {
        const char Separator = '\\';

        _text.text = _currentValue.ToString() + Separator + _maxValue.ToString();
    }
}
