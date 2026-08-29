using UnityEngine;

public class MonsterVisualDisplay : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private MonsterData currentData;

    public void SetMonster(MonsterData data)
    {
        currentData = data;
        spriteRenderer.sprite = data.normalVisual;
    }

    public void SetTell(bool isTell)
    {
        spriteRenderer.sprite = isTell ? currentData.imposterVisual : currentData.normalVisual;
    }
}