using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    #region Fields
    DragandShoot dragandshoot;
    [SerializeField]
    BallManager ballManager;
    Ball balls;
    bool playerWon;
    bool gameEnded = false;
    #endregion
    #region Functions
    private void Start()
    {
        

    }
    private void Update()
    {


    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("StripedBall"))
        {
            Destroy(collision.gameObject);
            ballManager.ballsonSceneList.Remove(collision.gameObject);
            ballManager.playerBalls.Remove(collision.gameObject);
            ballManager.opponentBalls.Remove(collision.gameObject);

            if (GameManager.Instance.isFirstBallEntered == false && GameManager.Instance.gameplayState == Generic.Enums.GamePlayState.PlayerTurn)
            {
                AddPlayerBallStriped();
                GameManager.Instance.isFirstBallEntered = true;
                ballManager.playerBalls.Remove(collision.gameObject);
            }
            if (GameManager.Instance.isFirstBallEntered ==false && GameManager.Instance.gameplayState == Generic.Enums.GamePlayState.OpponentTurn)
            {
                AddOpponentBallStriped();
                GameManager.Instance.isFirstBallEntered = true;
                ballManager.opponentBalls.Remove(collision.gameObject);
            }
         
        }
        else if (collision.CompareTag("SolidBall"))
        {
            Destroy(collision.gameObject);
            ballManager.ballsonSceneList.Remove(collision.gameObject);
            ballManager.playerBalls.Remove(collision.gameObject);
            ballManager.opponentBalls.Remove(collision.gameObject);
            if (GameManager.Instance.isFirstBallEntered == false && GameManager.Instance.gameplayState == Generic.Enums.GamePlayState.PlayerTurn)
            {
                AddPlayerBallsSolid();
                GameManager.Instance.isFirstBallEntered = true;
                ballManager.playerBalls.Remove(collision.gameObject);
            }
            if (GameManager.Instance.isFirstBallEntered == false && GameManager.Instance.gameplayState == Generic.Enums.GamePlayState.OpponentTurn)
            {
                AddOpponentBallSolid();
                GameManager.Instance.isFirstBallEntered = true;
                ballManager.opponentBalls.Remove(collision.gameObject);
            }
        }
        else if (collision.CompareTag("BlackBall"))
        {
            ballManager.ballsonSceneList.Remove(collision.gameObject);
            ballManager.blackBallList.Remove(collision.gameObject);
            Destroy(collision.gameObject);
            
        }

        if (collision.CompareTag("WhiteBall"))
        {
            ballManager.ResetWhiteBallPosition();
        }
        GameOver();
    }
    private void GameOver()
    {
         if (ballManager.playerBalls.Count == 0 && ballManager.blackBallList.Count == 0)
        {
            gameEnded = true;
            GameManager.Instance.PlayerWon();
        }
        else if (ballManager.opponentBalls.Count == 0 && ballManager.blackBallList.Count == 0)
        {
            gameEnded = true;
            GameManager.Instance.OpponentWon();
        }
       else if (GameManager.Instance.gameplayState == Generic.Enums.GamePlayState.PlayerTurn && ballManager.blackBallList.Count == 0 && ballManager.ballsonSceneList.Count >= 1)
        {
            GameManager.Instance.OpponentWon();
        }
        else if (GameManager.Instance.gameplayState == Generic.Enums.GamePlayState.OpponentTurn && ballManager.blackBallList.Count == 0 && ballManager.ballsonSceneList.Count >= 1)
        {
            GameManager.Instance.PlayerWon();
        }       
    }
    public void AddPlayerBallsSolid()
    {
        foreach (GameObject solidBall in ballManager.solidBallList)
        {
            ballManager.playerBalls.Add(solidBall);
        }
        foreach (GameObject stripedBall in ballManager.stripedBallList)
        {
            ballManager.opponentBalls.Add(stripedBall);
        }
    }
    public void AddPlayerBallStriped()
    {
        foreach (GameObject stripedBall in ballManager.stripedBallList)
        {
            ballManager.playerBalls.Add(stripedBall);

        }
        foreach (GameObject solidBall in ballManager.solidBallList)
        {
            ballManager.opponentBalls.Add(solidBall);
        }
    }
    public void AddOpponentBallStriped()
    {
        foreach (GameObject stripedBall in ballManager.stripedBallList)
        {
            ballManager.opponentBalls.Add(stripedBall);
        }
        foreach (GameObject solidBall in ballManager.solidBallList)
        {
            ballManager.playerBalls.Add(solidBall);
        }
    }
    public void AddOpponentBallSolid()
    {
        foreach (GameObject solidBall in ballManager.solidBallList)
        {
            ballManager.opponentBalls.Add(solidBall);
        }
        foreach (GameObject stripedBall in ballManager.stripedBallList)
        {
            ballManager.playerBalls.Add(stripedBall);
        }
    }
    #endregion
}
