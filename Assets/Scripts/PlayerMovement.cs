
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
    bool isJumping = false;
    bool jumpEnabled = false; //The level should load this.
    bool isFat = true; //The level should load this.
                       //bool isRotated = false;

    // fixedupdate is better for physics
    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (Input.GetKey("d")) //right
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))//left
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }


        if (Input.GetKey("space") && jumpEnabled)//jump
        {
            Debug.Log("Jump!");
            Jump();
        }

        if (rb.position.x < -9f || rb.position.x > 9f)
        {
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



    public void AddJumpForce(int _jumpToAdd)
    {
        jumpForce += _jumpToAdd;
    }
}
