using System.Collections.Generic;
using UnityEngine;

public class ProfileSelectScreen : MonoBehaviour
{
    [SerializeField] private GameSettings settings;
    [SerializeField] private List<MonsterData> fullRoster;

    private readonly List<MonsterData> selected = new List<MonsterData>();

    public bool ReadyToStart => selected.Count == settings.monstersPerRun;

    public void TogglePick(MonsterData monster)
    {
        if (selected.Contains(monster))
        {
            selected.Remove(monster);
        }
        else if (selected.Count < settings.monstersPerRun)
        {
            selected.Add(monster);
        }
    }

    public List<MonsterData> GetSelection() => new List<MonsterData>(selected);
}

