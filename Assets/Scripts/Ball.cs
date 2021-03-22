using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameObject paddle;
    private Vector2 distanceVector;

    private bool hasStarted;

    [SerializeField] private AudioClip[] ballSounds;
    [SerializeField] private float randomFactor;
    private Rigidbody2D rigidBody;

    // Start is called before the first frame update
    void Start()
    {
        distanceVector = transform.position - paddle.transform.position;//ball position-paddle position
        hasStarted = false;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
            
        }
        LaunchOnMouseClick();
    }
    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))//mouse left click
        {
            rigidBody.velocity = new Vector2(2f, 15f);
            hasStarted = true;
        }
    }
    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + distanceVector;//ball position 
    }

    private void OnCollisionEnter2D(Collision2D other)//ball audio
    {
        Vector2 randomDirection = new Vector2(Random.Range(0f,randomFactor),Random.Range(0f,randomFactor));//random direction
       //Debug.Log(other.gameObject.name);

       if (hasStarted && other.gameObject.tag.Equals("block"))
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            GetComponent<AudioSource>().PlayOneShot(clip);
            rigidBody.velocity += randomDirection;
        }
         //&& other.gameObject.name.Equals("Block")
    }
}
