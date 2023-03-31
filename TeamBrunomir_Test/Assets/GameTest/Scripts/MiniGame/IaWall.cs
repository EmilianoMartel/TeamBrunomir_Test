using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaWall : MonoBehaviour
{
    public MiniGame miniGame;
    public Ball ball;
    public SecondSceneScript secondScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Ball")
        {
            miniGame.playerScore++;
            if (miniGame.playerScore < 5)
            {
                secondScene.MiniGame("PlayerScore");
            }
            ball.Launch();
        }
    }
}

