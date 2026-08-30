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

    public void UpdateMonsterSprite(Dialogue line)
    {
        spriteRenderer.sprite = line.currentEmotion != null
            ? line.currentEmotion
            : currentData.normalVisual;
    }
}