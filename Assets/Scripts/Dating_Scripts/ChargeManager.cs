using UnityEngine;
using UnityEngine.UI;

public class ChargeManager : MonoBehaviour
{
    public static ChargeManager Instance { get; private set; }

    [SerializeField] private GameSettings settings;
    [SerializeField] private Image[] chargeIcons;

    public int Charges { get; private set; }
    public bool HasCharge => Charges > 0;

    private void Awake()
    {
        Instance = this;
    }

    public void ResetCharges()
    {
        Charges = settings.chargesPerNight;
        UpdateIcons();
    }

    public bool TrySpendCharge()
    {
        if (Charges <= 0) return false;
        Charges--;
        UpdateIcons();
        return true;
    }

    private void UpdateIcons()
    {
        for (int i = 0; i < chargeIcons.Length; i++)
        {
            chargeIcons[i].enabled = i < Charges;
        }
    }
}