using UnityEngine;

public class PhoneCheck : MonoBehaviour
{
    [SerializeField] private SeatedLookCamera cam;
    [SerializeField] private float lookDownThreshold = 15f;
    [SerializeField] private GameObject phoneUI;
    [SerializeField] private ProfileCardUI card;

    public MonsterData CurrentDate { get; set; }

    public bool IsPhoneOut => Input.GetKey(KeyCode.Space) && cam.CurrentPitch >= lookDownThreshold;

    private void Update()
    {
        phoneUI.SetActive(IsPhoneOut);
        if (IsPhoneOut && CurrentDate != null)
        {
            card.Show(CurrentDate);
        }
    }
}

