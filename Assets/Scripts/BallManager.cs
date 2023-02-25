using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Generic.Enums;
public class BallManager : MonoBehaviour
{
    #region  Fields
    
    [SerializeField]
    public List<GameObject> whiteBallList = new List<GameObject>();
    [SerializeField]
    public List<GameObject> solidBallList = new List<GameObject>();
    [SerializeField]
    public List<GameObject> stripedBallList = new List<GameObject>();
    [SerializeField]
    public List<GameObject> blackBallList = new List<GameObject>();
    [SerializeField]
    public List<GameObject> ballsonSceneList = new List<GameObject>();
    // Prefab Lists//
    [SerializeField]
    public List<GameObject> whiteBallPrefabList = new List<GameObject>();
    [SerializeField]
    public List<GameObject> solidBallPrefabList = new List<GameObject>();
    [SerializeField]
    public List<GameObject> stripedBallPrefabList = new List<GameObject>();
    [SerializeField]
    public List<GameObject> blackBallPrefabList = new List<GameObject>();
    // player and opponent  ball list
    [SerializeField]
    public List<GameObject> opponentBalls = new List<GameObject>();
    [SerializeField]
    public List<GameObject> playerBalls = new List<GameObject>();
    [SerializeField]
    GameManager gameManager;
    
    
    Ball ballType;
    // BALL POSITION LIST//
    public Vector3[] whiteBallPosition;
    public Vector3[] SolidBallPositions;
    public Vector3[] StripedBallPositions;
    public Vector3[] blackBallPoisiton;


    #endregion
    #region Functions
    
    private void Start()
    {
        
        SetWhiteBallList();
        SetSolidBallList();
        SetStripedBallList();
        SetBlackBallList();
        AddAllBallsToBallsOnSceneList();

    }
    //private void Start()
    //{
        
        
    //}
    public void SetWhiteBallList()
    {
        foreach (GameObject ball in whiteBallPrefabList)
        {
            
            var createdWhiteBall = GameObject.Instantiate(ball, whiteBallPosition[0], Quaternion.identity);
            
            whiteBallList.Add(createdWhiteBall);
            
        }

    }
    public void ResetWhiteBallPosition()
    {
        Rigidbody2D whiteBallRB = whiteBallList[0].GetComponent<Rigidbody2D>();
        whiteBallRB.velocity = Vector2.zero;
        whiteBallRB.angularVelocity = 0f;
        whiteBallList[0].transform.position = whiteBallPosition[0];
       
    }
    public void SetSolidBallList()
    {
        List<int> UsedIndexes = new List<int>();
        foreach (GameObject solidBall in solidBallPrefabList)
        {
            //TODO RANDOM SAYI URET TEKRARLAMA OLMADAN TOPLARI POSITIONLARLA ESITLE
            int random = Random.Range(0, 8);
            while (UsedIndexes.Contains(random))
            {
                random = Random.Range(0, 8);
            }
            UsedIndexes.Add(random);
            var createdSolidBall = GameObject.Instantiate(solidBall, SolidBallPositions[random], Quaternion.identity);
            solidBallList.Add(createdSolidBall);

        }
    }
    public void SetStripedBallList()
    {
        List<int> UsedIndexes = new List<int>();
        foreach (GameObject stripedBall in stripedBallPrefabList)
        {
            int random = Random.Range(0, 6);
            while (UsedIndexes.Contains(random))
            {
                random = Random.Range(0, 6);
            }
            UsedIndexes.Add(random);
            var createdStripedBall = GameObject.Instantiate(stripedBall, StripedBallPositions[random], Quaternion.identity);
            stripedBallList.Add(createdStripedBall);

        }

    }
    public void SetBlackBallList()
    {
        foreach (GameObject blackBall in blackBallPrefabList)
        {
            var createdBlackBall = GameObject.Instantiate(blackBall, blackBallPoisiton[0], Quaternion.identity);
            blackBallList.Add(createdBlackBall);
        }
    }
    public void AddAllBallsToBallsOnSceneList()
    {
        foreach (var solidBall in solidBallList)
        {
            ballsonSceneList.Add(solidBall);
        }
        foreach (var stripedBall in stripedBallList)
        {
            ballsonSceneList.Add(stripedBall);
        }
        foreach (var blackBall in blackBallList)
        {
            ballsonSceneList.Add(blackBall);
        }
    }
    #endregion
}
