using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RacketPlayer : MonoBehaviour
{
    [SerializeField] private float speed = 50f;
    [SerializeField] private float yBoundMin = 214f;
    
    void Update()
    {
        Move();
    }

    void Move()
    {
        float movement = Input.GetAxisRaw("Vertical");
        Vector2 racketPosition = transform.position;
        racketPosition.y = Mathf.Clamp(racketPosition.y + movement * speed * Time.deltaTime, yBoundMin, yBoundMin+300f);
        transform.position = racketPosition;
    }


}
