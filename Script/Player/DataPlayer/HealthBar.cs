using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider fillChange;

    public void SetHealth(int _health)
    {
        fillChange.value = _health;
    }

    public void AddHealth(int _health)
    {
        fillChange.value += _health;
    }
    public void SetMaxHealth(int _health)
    {
        fillChange.maxValue = _health;
        fillChange.value = _health;
    }

}
