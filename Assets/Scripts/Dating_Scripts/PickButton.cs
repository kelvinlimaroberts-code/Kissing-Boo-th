using UnityEngine;

public class PickButton : MonoBehaviour
{
    [SerializeField] private ProfileSelectScreen screen;
    [SerializeField] private MonsterData monster;

    public void Pick()
    {
        screen.TogglePick(monster);
    }
}