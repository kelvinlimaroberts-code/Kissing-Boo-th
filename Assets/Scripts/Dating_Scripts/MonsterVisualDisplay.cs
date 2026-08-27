using UnityEngine;

public class MonsterVisualDisplay : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;

    public void SetMonster(MonsterData data)
    {
        spriteRenderer.sprite = data.normalVisual;
    }
}