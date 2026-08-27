using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PickButton : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private ProfileSelectScreen screen;
    [SerializeField] private MonsterData monster;
    [SerializeField] private TMP_Text label;
    private bool picked;

    private void Start()
    {
        label.text = monster.monsterName;
    }

    public void Pick()
    {
        screen.TogglePick(monster);
        picked = !picked;
        background.color = picked ? Color.yellow : Color.white;
    }
}