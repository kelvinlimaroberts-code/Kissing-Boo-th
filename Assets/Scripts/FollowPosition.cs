using UnityEngine;

public class FollowPosition : MonoBehaviour
{
    public Transform Leader;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Leader.position;
        this.transform.rotation = Leader.rotation;
    }
}
