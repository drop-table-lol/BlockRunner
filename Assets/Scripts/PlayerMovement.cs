
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public Transform tr;
    public Animation rotate;
    public Animation unrotate;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public float jumpForce = 500f;
    public float lastxpos = 0; //For turning
    public float lastzpos = 0; //For turning
    [SerializeField]
    bool isForward = true;
    [SerializeField]
    bool isLeft = false;
    [SerializeField]
    bool isRight = false;
    bool isJumping = false;
    bool jumpEnabled = false; //The level should load this.
    bool isFat = true; //The level should load this.
                       //bool isRotated = false;



    // fixedupdate is better for physics
    void FixedUpdate()
    {

        //FORWARD
        if (isForward)
            rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (isRight)
            rb.AddForce(forwardForce * Time.deltaTime, 0, 0);

        if (isLeft)
            rb.AddForce(-forwardForce * Time.deltaTime, 0, 0);



        //RIGHT
        if (Input.GetKey("right") || Input.GetKey("d")) //right
        {
            if (isForward)
                rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

            if (isLeft)
                rb.AddForce(0, 0, sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);

            if (isRight)
                rb.AddForce(0, 0, -sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);
        }


        //LEFT
        if (Input.GetKey("left") || Input.GetKey("a")) //left
        {
            if (isForward)
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

            if (isLeft)
                rb.AddForce(0, 0, -sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);

            if (isRight)
                rb.AddForce(0, 0, sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);
        }


        if (Input.GetKey("space") && jumpEnabled)//jump
        {
            Debug.Log("Jump!");
            Jump();
        }

        if ((isForward) && (rb.position.x < lastxpos - 9f || rb.position.x > lastxpos + 9f))
        {
            //TODO
            //find player
            //delete player
            //explode copy
            Debug.Log("GG, player went too far on x");
            FindObjectOfType<GameManager>().EndGame();
        }

        if ((isLeft || isRight) && (rb.position.z < lastzpos - 9f || rb.position.z > lastzpos + 9f))
        {
            //TODO
            //find player
            //delete player
            //explode copy
            Debug.Log("GG, player went too far on z");
            FindObjectOfType<GameManager>().EndGame();

        }

    }


    void Update()
    {
        if (isFat)
        {
            if (Input.GetKeyDown("q")) // rotate left
            {
                //if ((!rotate.isPlaying || unrotate.isPlaying) && !isRotated)
                //rotate.Play();
                tr.Rotate(0, 90, 0);

            }

            if (Input.GetKeyDown("e")) // rotate left
            {
                //if ((!rotate.isPlaying || unrotate.isPlaying) && isRotated)
                //unrotate.Play();
                tr.Rotate(0, 90, 0);
            }
        }
    }





    void Jump()
    {
        if (isJumping == false)
        {
            isJumping = true;
            rb.AddForce(0, jumpForce, 0, ForceMode.VelocityChange);
            Invoke("Land", .3f);
        }
    }

    void Land()
    {
        rb.AddForce(0, -jumpForce * 2, 0, ForceMode.VelocityChange);
        isJumping = false;
    }


    public void ChangeDirection(string _direction) //This will be accessed by the "track" on turns
    {
        Debug.Log("Changing Dir");
        if (_direction == "Forward")
        {
            lastxpos = transform.position.x;
            isForward = true;
            isLeft = false;
            isRight = false;

        }

        if (_direction == "Left")
        {
            lastzpos = transform.position.z;
            isForward = false;
            isLeft = true;
            isRight = false;
        }

        if (_direction == "Right")
        {
            lastzpos = transform.position.z;
            isForward = false;
            isLeft = false;
            isRight = true;
        }
    }



    public void AddJumpForce(int _jumpToAdd)
    {
        jumpForce += _jumpToAdd;
    }
}
