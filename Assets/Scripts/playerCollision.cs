﻿using UnityEngine;

public class playerCollision : MonoBehaviour
{
    public GameObject playerPieces;
    public PlayerMovement movement;

    public bool isInvincible = false;





    void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.collider.tag == "Obstacle")
        {
            if (isInvincible)
            {
                collisionInfo.gameObject.GetComponent<ExplodeObstacle>().explodeNow = true;
                FindObjectOfType<Score>().AddScore(50);

            }

            else
            {
                movement.enabled = false;
                Instantiate(playerPieces, transform.position, transform.rotation);;
                FindObjectOfType<GameManager>().EndGame();
                FindObjectOfType<Score>().StopScore();
                Destroy(gameObject);
            }
        }
    }


}
