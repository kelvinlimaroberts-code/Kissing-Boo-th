using UnityEngine;
using TMPro;

public class ChargeManager : MonoBehaviour
{
    public static ChargeManager Instance { get; private set; }

    [SerializeField] private GameSettings settings;
    [SerializeField] private TMP_Text chargeText;

    public int Charges { get; private set; }
    public bool HasCharge => Charges > 0;

    private void Awake()
    {
        Instance = this;
    }

    public void ResetCharges()
    {
        Charges = settings.chargesPerNight;
        UpdateText();
    }

    public bool TrySpendCharge()
    {
        if (Charges <= 0) return false;
        Charges--;
        UpdateText();
        return true;
    }

    private void UpdateText()
    {
        if (chargeText != null) chargeText.text = "Charges: " + Charges;
    }
}