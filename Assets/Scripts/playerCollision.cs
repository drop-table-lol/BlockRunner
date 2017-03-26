using UnityEngine;

public class playerCollision : MonoBehaviour
{
    public GameObject playerPieces;
    public PlayerMovement movement;

    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            Instantiate(playerPieces, transform.position, transform.rotation);
            FindObjectOfType<GameManager>().EndGame();
            Destroy(gameObject);

        }
    }

}
