using UnityEngine;

public class LaunchOnContact : MonoBehaviour {

    public Rigidbody rb;
    [SerializeField]
    int jumpForce = 10;
    [SerializeField]
    int slowForce = 1000;
    [SerializeField]
    bool slowPlayer = false;

    void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.tag == "Player")
        {
            Debug.Log("Launched Player");
            if (rb == null)
            {
                Debug.Log("Player not found");
            }
            rb.AddForce(0, jumpForce, 0);
            if (slowPlayer)
            {
                rb.AddForce(0, 0, -slowForce);
                
            }

        }
    }
}
