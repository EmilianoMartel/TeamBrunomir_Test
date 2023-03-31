using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaManager : MonoBehaviour
{
    public Ball ball;

    private float yLimit;
    [SerializeField] private float speed = 5f;

    void Start()
    {
        yLimit = gameObject.transform.position.y;
    }
        
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (ball.transform.position.y >= gameObject.transform.position.y)
        {            
            float movement = 1f;
            Vector2 racketPosition = transform.position;
            racketPosition.y = Mathf.Clamp(racketPosition.y + movement * speed * Time.deltaTime, (yLimit - 15.7f), yLimit + 15.7f);
            transform.position = racketPosition;
        }
        if (ball.transform.position.y <= gameObject.transform.position.y)
        {
            float movement = -1f;
            Vector2 racketPosition = transform.position;
            racketPosition.y = Mathf.Clamp(racketPosition.y + movement * speed * Time.deltaTime, (yLimit - 15.7f), yLimit + 15.7f);
            transform.position = racketPosition;
        }
    }
}
