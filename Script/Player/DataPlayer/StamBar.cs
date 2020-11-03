using UnityEngine;
using UnityEngine.UI;

public class StamBar : MonoBehaviour
{
    public Slider fillChange;

    public void SetStam(int _stamina)
    {
        fillChange.value = _stamina;
    }

    public void AddStam(int _stamina)
    {
        fillChange.value += _stamina;
    }

    public void SetMaxStam(int _stamina)
    {
        fillChange.maxValue = _stamina;
        fillChange.value = _stamina;
    }
}
