using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class Ball : MonoBehaviour
{
    public MiniGame miniGame;

    private Rigidbody2D ballRb;
    private float originalPositionY;
    private float originalPositionX;
    private float originalPositionZ;

    [SerializeField] private float initialVelocity = 5f;
    [SerializeField] private float velocityMultiplier = 1.2f;

    void Start()
    {
        originalPositionX = gameObject.transform.position.x;
        originalPositionY = gameObject.transform.position.y;
        originalPositionZ = gameObject.transform.position.z;
        ballRb = GetComponent<Rigidbody2D>();
        Launch();
    }

    public void Launch()
    {
        gameObject.transform.position = new Vector3(originalPositionX, originalPositionY, originalPositionZ);
        float xVelocity = Random.Range(0,2) == 0 ? 1 : -1;
        float yVelocity = Random.Range(0,2) == 0 ? 1 : -1;
        ballRb.velocity = new Vector2(xVelocity,yVelocity) * initialVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Racket"))
        {
            ballRb.velocity *= velocityMultiplier;
        }
        if (collision.gameObject.CompareTag("IaWall"))
        {
            Debug.Log("ia");
            miniGame.playerScore++;
            Launch();
        }
        if (collision.gameObject.CompareTag("PlayerWall"))
        {
            Debug.Log("player");
            miniGame.iaScore++;
            Launch();
        }
    }
}