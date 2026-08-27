using UnityEngine;

public class StartNightButton : MonoBehaviour
{
    [SerializeField] private ProfileSelectScreen screen;
    [SerializeField] private RoundManager roundManager;

    public void TryStart()
    {
        if (!screen.ReadyToStart)
        {
           return;
        }
        roundManager.StartRound(screen.GetSelection());
        screen.gameObject.SetActive(false);
    }
}