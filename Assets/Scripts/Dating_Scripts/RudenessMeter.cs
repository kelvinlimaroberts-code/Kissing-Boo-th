using UnityEngine;
using UnityEngine.Events;

public class RudenessMeter : MonoBehaviour
{
    [SerializeField] private PhoneCheck phoneCheck;
    [SerializeField] private float maxValue = 100f;
    [SerializeField] private float fillRate = 20f;
    [SerializeField] private float drainRate = 10f;

    public UnityEvent onCaughtBeingRude;

    private float value;

    public float Value01 => value / maxValue;

    private void Update()
    {
        if (phoneCheck.IsPhoneOut)
        {
            value += fillRate * Time.deltaTime;
            if (value >= maxValue)
            {
                onCaughtBeingRude.Invoke();
            }
        }
        else
        {
            value = Mathf.Max(0f, value - drainRate * Time.deltaTime);
        }
    }
}

