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


    public void ChangeDirection(string dir)
    {
        if (dir == "Forward")
        {
            if (isLeft)
            {
                transform.Rotate(0, 90, 0);
                isLeft = false;
            }
            if (isRight)
            {
                transform.Rotate(0, -90, 0);
                isRight = false;
            }
            isForward = true;
            isLeft = false;
            isRight = false;
        }

        if (dir == "Left")
        {
            isForward = false;
            isLeft = true;
            isRight = false;
            transform.Rotate(0, -90, 0);
        }

        if (dir == "Right")
        {
            isForward = false;
            isLeft = false;
            isRight = true;
            transform.Rotate(0, 90, 0);
        }
    }



}
