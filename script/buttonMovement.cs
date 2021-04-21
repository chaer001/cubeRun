
using UnityEngine;

public class buttonMovement : MonoBehaviour
{
    // ridgid boddy

    public Rigidbody rb;
    public GameObject Player;

    private float ScreenWidth;
    // forward force speed
    public float forwardForce = 2000f;

    //side force speed
    public float sideForce = 500f;

    // Update is called once per frame
    private void Start()
    {
        ScreenWidth = Screen.width;
        
    }
    void Update()
    {
        int i = 0;
        while (i < Input.touchCount)
        {
            if (Input.GetTouch(i).position.x > Screen.width / 2)
            {
                runCharacter(1f);
            }
            if (Input.GetTouch(i).position.x < Screen.width / 2)
            {
                runCharacter(-1f);
            }
            i++;
        }
    }

    private void runCharacter(float horizontal)
    {
        rb.AddForce(sideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }
}
