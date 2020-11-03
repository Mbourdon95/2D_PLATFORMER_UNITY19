using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider fillChange;

    public void SetMana(int _mana)
    {
        fillChange.value = _mana;
    }

    public void AddMana(int _mana)
    {
        fillChange.value += _mana;
    }

    public void SetMaxMana(int _mana)
    {
        fillChange.maxValue = _mana;
        fillChange.value = _mana;
    }
}
