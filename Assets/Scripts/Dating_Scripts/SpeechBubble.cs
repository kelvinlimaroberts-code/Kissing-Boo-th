using UnityEngine;
using TMPro;
using System.Collections;

public class SpeechBubble : MonoBehaviour
{
    [SerializeField] private TMP_Text bubbleText;
    [SerializeField] private float charInterval = 0.03f;
    [SerializeField] private float popDuration = 0.25f;
    [SerializeField] private float popOvershoot = 1.3f;

    private Coroutine revealRoutine;

    public void Show(string text)
    {
        gameObject.SetActive(true);
        if (revealRoutine != null) StopCoroutine(revealRoutine);
        revealRoutine = StartCoroutine(RevealBubbly(text));
    }

    private IEnumerator RevealBubbly(string text)
    {
        bubbleText.text = text;
        bubbleText.maxVisibleCharacters = 0;
        bubbleText.ForceMeshUpdate();

        int totalChars = bubbleText.textInfo.characterCount;

        for (int i = 0; i < totalChars; i++)
        {
            bubbleText.maxVisibleCharacters = i + 1;
            bubbleText.ForceMeshUpdate();
            yield return StartCoroutine(AnimatePop(i));
            yield return new WaitForSeconds(charInterval);
        }
    }

    private IEnumerator AnimatePop(int charIndex)
    {
        TMP_TextInfo textInfo = bubbleText.textInfo;
        TMP_CharacterInfo charInfo = textInfo.characterInfo[charIndex];
        if (!charInfo.isVisible) yield break;

        int matIndex = charInfo.materialReferenceIndex;
        int vertIndex = charInfo.vertexIndex;
        Vector3[] liveVerts = textInfo.meshInfo[matIndex].vertices;

        // cache the TRUE full-size vertices once, before any scaling touches them
        Vector3[] originalVerts = new Vector3[4];
        for (int v = 0; v < 4; v++) originalVerts[v] = liveVerts[vertIndex + v];
        Vector3 mid = (originalVerts[0] + originalVerts[2]) / 2f;

        float t = 0f;
        while (t < popDuration)
        {
            t += Time.deltaTime;
            ApplyScale(matIndex, vertIndex, originalVerts, mid, BounceEase(Mathf.Clamp01(t / popDuration)));
            yield return null;
        }
        ApplyScale(matIndex, vertIndex, originalVerts, mid, 1f);
    }

    private void ApplyScale(int matIndex, int vertIndex, Vector3[] originalVerts, Vector3 mid, float scale)
    {
        Vector3[] verts = bubbleText.textInfo.meshInfo[matIndex].vertices;
        for (int v = 0; v < 4; v++)
        {
            verts[vertIndex + v] = mid + (originalVerts[v] - mid) * scale;
        }
        bubbleText.UpdateVertexData(TMP_VertexDataUpdateFlags.Vertices);
    }

    private float BounceEase(float t)
    {
        float c1 = 1.70158f * popOvershoot;
        float c3 = c1 + 1f;
        float x = t - 1f;
        return 1f + c3 * x * x * x + c1 * x * x;
    }
}