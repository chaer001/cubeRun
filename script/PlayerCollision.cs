
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    //after collision 
    public PlayerMovement movement;

     
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Wall" || collision.collider.tag == "Obstacle")
        {
            movement.enabled = false;
            
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
