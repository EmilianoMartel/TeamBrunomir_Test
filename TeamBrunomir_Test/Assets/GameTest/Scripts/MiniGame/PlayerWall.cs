using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWall : MonoBehaviour
{
    public MiniGame miniGame;
    public Ball ball;
    public SecondSceneScript secondScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            miniGame.iaScore++;
            if (miniGame.iaScore < 5)
            {
                secondScene.MiniGame("IaScore");
            }
            ball.Launch();
        }
    }
}
