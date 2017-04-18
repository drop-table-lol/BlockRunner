using UnityEngine;

public class followPlayer : MonoBehaviour {

    public Transform player;
    public Vector3 forwardOffset;
    public Vector3 rightOffset;
    public Vector3 leftOffset;
    bool isForward = true;
    bool isRight = false;
    bool isLeft = false;

    void Update()
    {
        if (player != null && isForward)
            transform.position = player.position + forwardOffset;

        if (player != null && isRight)
            transform.position = player.position + rightOffset;

        if (player != null && isLeft)
            transform.position = player.position + leftOffset;
    }





}
