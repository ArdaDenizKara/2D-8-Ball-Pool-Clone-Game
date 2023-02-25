using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Generic.Enums;

public class GamePlay : MonoBehaviour
{
    public GameObject[] balls;
    #region Fields
    public GameObject whiteBall;
    public GameObject rack;
    DragandShoot dragandShoot;
    BallManager ballManager;
    public GamePlayState gameplayState;
    #endregion    
    #region  Functions
    public void Start()
    {
        SpawnRack();
        //gameplayState = GamePlayState.Start;
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
    
    
    #endregion
}

