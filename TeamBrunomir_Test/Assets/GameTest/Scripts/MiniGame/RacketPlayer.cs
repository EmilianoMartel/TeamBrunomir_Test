using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RacketPlayer : MonoBehaviour
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

    void Move()
    {
        float movement = Input.GetAxisRaw("Vertical");
        Vector2 racketPosition = transform.position;
        racketPosition.y = Mathf.Clamp(racketPosition.y + movement * speed * Time.deltaTime, (yLimit -15.7f) , yLimit + 15.7f);
        transform.position = racketPosition;
    }


}
