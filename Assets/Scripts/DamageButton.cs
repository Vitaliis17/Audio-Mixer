using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DamageButton : MonoBehaviour
{
    [SerializeField] private int _damage;

    [SerializeField] private Health _health;

    private Button _button;

    private void Awake()
        => _button = GetComponent<Button>();

    private void OnEnable()
        => _button.onClick.AddListener(Attack);

    private void OnDisable()
        => _button.onClick.RemoveListener(Attack);

    private void Attack()
        => _health.TakeDamage(_damage);
}