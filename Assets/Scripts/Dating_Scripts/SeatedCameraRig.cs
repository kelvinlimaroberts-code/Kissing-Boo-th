using System.Collections;
using UnityEngine;

public class SeatedCameraRig : MonoBehaviour
{
    [SerializeField] private float moveTime = 1.2f;

    public void MoveToSeat(Transform seat)
    {
        StartCoroutine(Glide(seat.position, seat.rotation));
    }

    private IEnumerator Glide(Vector3 targetPos, Quaternion targetRot)
    {
        Vector3 startPos = transform.position;
        Quaternion startRot = transform.rotation;
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime / moveTime;
            transform.position = Vector3.Lerp(startPos, targetPos, t);
            transform.rotation = Quaternion.Slerp(startRot, targetRot, t);
            yield return null;
        }
    }
}

