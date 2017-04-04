
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public Transform tr;
    public GameObject remains;
    public Camera playerCam;
    public float forwardForce = 2000f;
    public float sidewaysForce = 500f;
    public float jumpForce = 500f;
    public float lastxpos = 0; //For turning
    public float tracksize;
    bool isJumping = false;
    public bool jumpEnabled = false; //The level should load this.


    // fixedupdate is better for physics
    void FixedUpdate()
    {

        //FORWARD
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        //RIGHT
        if (Input.GetKey("right") || Input.GetKey("d")) //right
                rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);

        //LEFT
        if (Input.GetKey("left") || Input.GetKey("a")) //left
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);




        if (Input.GetKey("space") && jumpEnabled)//jump
        {
            Debug.Log("Jump!");
            Jump();
        }


        if (rb.position.x < lastxpos - tracksize || rb.position.x > lastxpos + tracksize)
        {

            Debug.Log("BG, player went too far on x");
            Instantiate(remains, transform.position, transform.rotation);
            Destroy(gameObject);
            FindObjectOfType<GameManager>().EndGame();
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

    public void AddSpeedForce(int _speedtoAdd)
    {
        forwardForce += _speedtoAdd;
    }

    public void AddSize(int _sizeToAdd)
    {
        Vector3 change = new Vector3(.1F *_sizeToAdd, 0.1F * _sizeToAdd, 0.1F * _sizeToAdd);
        tr.localScale -= change;
    }
}