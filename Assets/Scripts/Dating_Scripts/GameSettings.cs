using UnityEngine;

[CreateAssetMenu(menuName = "Game Settings")]
public class GameSettings : ScriptableObject
{
    public int monstersPerRun = 3;
    public float dateTimerSeconds = 90f;
    public int chargesPerNight = 3;
}