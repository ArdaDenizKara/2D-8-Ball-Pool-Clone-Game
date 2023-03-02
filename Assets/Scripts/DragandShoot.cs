using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Generic.Enums;

public class DragandShoot : MonoBehaviour
{
    #region Fields
    Vector3 distance = new Vector3(4.2f, 0, 0);
    public float power;
    private float enemyPower = 300f;
    public Rigidbody2D rb;
    public Vector2 minPower;
    public Vector2 maxPower;
    private Vector2 enemyVecPower;
    Camera cam;
    Vector3 whiteBallPos;
    Vector3 whiteBallUpdatedPos;
    Quaternion whiteBallRotation;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;
    Vector3 lastPosition;
    public LineRendering lr;
    public AudioSource audioSource;
    [SerializeField]
    GamePlay gameplay;
    bool isEnemyTurnCalled = false;
    bool isPlayerTurnCalled = true;
    BallManager ballManager;
    #endregion
    #region Functions
    public void Start()
    {
        gameplay = GetComponent<GamePlay>();
        cam = Camera.main;
        lr = GetComponent<LineRendering>();
        StartCoroutine(StartState());
        whiteBallPos = GameObject.FindGameObjectWithTag("WhiteBall").transform.position;
        whiteBallRotation = GameObject.FindGameObjectWithTag("WhiteBall").transform.rotation;  /*ballManager.whiteBallList[0].transform.rotation;*/
    }
    public void Update()
    {
        bool isGameplayStateStart = GameManager.Instance.gameplayState == Generic.Enums.GamePlayState.Start;
        bool isPlayerTurn = GameManager.Instance.gameplayState == Generic.Enums.GamePlayState.PlayerTurn;
        bool isEnemyTurn = GameManager.Instance.gameplayState == Generic.Enums.GamePlayState.OpponentTurn;
        bool isBallNotMoving = rb.velocity == Vector2.zero && rb.angularVelocity == 0;
        if (isPlayerTurn && isPlayerTurnCalled && isBallNotMoving)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                startPoint.z = 15;
            }
            if (Input.GetMouseButton(0))
            {
                Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                currentPoint.z = 15;
                whiteBallPos = GameObject.FindGameObjectWithTag("WhiteBall").transform.position;
                whiteBallRotation = GameObject.FindGameObjectWithTag("WhiteBall").transform.rotation;
                lr.RenderLine(startPoint, currentPoint);
            }
            if (Input.GetMouseButtonUp(0))
            {
                endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
                endPoint.z = 15;
                force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
                rb.AddForce(force * power, ForceMode2D.Impulse);
                lr.EndRenderLine();
                StartCoroutine(EnemyTurn());
                isEnemyTurnCalled = false;
                isPlayerTurnCalled = false;
                SoundManager.Instance.PlaySound();
            }
        }
        else if (isEnemyTurn && isEnemyTurnCalled == false && isBallNotMoving)
        {
            rb.AddForce(force * enemyPower, ForceMode2D.Force);
            SoundManager.Instance.PlaySound();
            StartCoroutine(PlayerTurn());
            isPlayerTurnCalled = true;
            isEnemyTurnCalled = true;
        }
    }
    IEnumerator PlayerTurn()
    {
        yield return new WaitForSeconds(5f);
        GameManager.Instance.gameplayState = Generic.Enums.GamePlayState.PlayerTurn;
    }
    IEnumerator EnemyTurn()
    {
        yield return new WaitForSeconds(5f);
        GameManager.Instance.gameplayState = Generic.Enums.GamePlayState.OpponentTurn;
    }
    IEnumerator StartState()
    {
        yield return new WaitForSeconds(1f);
        GameManager.Instance.gameplayState = Generic.Enums.GamePlayState.PlayerTurn;
    }
    #endregion
}
