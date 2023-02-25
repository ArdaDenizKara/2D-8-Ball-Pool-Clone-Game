using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Generic.Enums;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    #region Fields
    
    public GameObject opponentWinScreen;
    public GameObject playerWinScreen;
    public Text playerWinText;
    public Text opponentWinText;
    public GameObject rack;
    public List<GameObject> cueList;
    public List<GameObject> cuePrefabList;
    BallManager ballManager;
    public GamePlayState gameplayState;
    Collisions collisionz;
    private static GameManager instance;
    public bool isFirstBallEntered;
    BallType playerBallType;
    BallType opponentBallType;
    public static GameManager Instance { get { return instance; } }
    #endregion
    #region Functions

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {
        gameplayState = Generic.Enums.GamePlayState.Start;
        isFirstBallEntered = false;
        SpawnRack();
        StartCoroutine(DestroyRack());
        StopCoroutine(DestroyRack());
        
    }
    public void SpawnRack()
    {
        Instantiate(rack, new Vector3(3.0315f, 0.13f, 0), rack.transform.rotation);


    }
    IEnumerator DestroyRack()
    {

        yield return new WaitForSeconds(1f);
        Destroy(GameObject.FindGameObjectWithTag("Rack"));

    }
    public void PlayerWon()
    {
        playerWinScreen.SetActive(true);
        playerWinText.text = "You Win ! ";
       
       
    }
    public void OpponentWon()
    {
        opponentWinScreen.SetActive(true);
        opponentWinText.text = "You Lose!";
        
    }
    public void StartGameButton()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    //public void IniteCue()
    //{
    //    foreach (GameObject cue in cuePrefabList)
    //    {
    //        var cueObject = GameObject.Instantiate(cue);
    //        cueList.Add(cueObject);
    //        cueObject.SetActive(false);
    //    }
        
    //}
    //public GameObject GetCue(Vector3 position, Vector3 rotation)
    //{
    //    var cue =  cueList.FirstOrDefault();
    //    cue.transform.position = position;
    //    cue.transform.rotation = Quaternion.Euler(rotation);

    //    cue.SetActive(true);
    //    return cue;
    //}
    //public void RemoveCue()
    //{
    //    var cue = cueList.FirstOrDefault();
    //    cue.SetActive(false);



    //}
    #endregion
}
