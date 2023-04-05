using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    public float playerScore = 0f;
    public float iaScore = 0f;
    public SecondSceneScript secondScene;

    [SerializeField] const string PLAYER_WIN = "player";
    [SerializeField] const string IA_WIN = "win";
    
    void Update()
    {
        GameOver();
    }

    private void GameOver()
    {
        if (playerScore >= 2)
        {
            secondScene.EndScene(PLAYER_WIN);
        }
        if (iaScore >= 2)
        {
            secondScene.EndScene(IA_WIN);
        }
    }
}
