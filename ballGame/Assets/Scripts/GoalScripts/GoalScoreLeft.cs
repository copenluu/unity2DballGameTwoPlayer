using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalScoreLeft : MonoBehaviour
{
    #region Public Variables
    #endregion
    #region Inspector Variables
    [SerializeField] private TextMeshProUGUI rightScore;
    [SerializeField] private GameObject ballPos;
    [SerializeField] private GameObject playerLeft;
    [SerializeField] private GameObject playerLeftGK;
    [SerializeField] private GameObject playerRight;
    [SerializeField] private GameObject playerRightGK;
    #endregion
    #region Private Variables
    private float scoreValue;
    private Vector2 playerLeftPosition;
    private Vector2 playerLeftGKPosition;
    private Vector2 playerRightPosition;
    private Vector2 playerRightGKPosition;
    #endregion
    #region Components
    BallMovement resetBall;
    WildcardSpawn spawnReset;
    #endregion

    private void Start()
    {

        resetBall = GameObject.FindGameObjectWithTag("ball").GetComponent<BallMovement>();
        spawnReset = GameObject.FindGameObjectWithTag("wildcardSpawner").GetComponent<WildcardSpawn>();
        playerLeftGKPosition = playerLeftGK.transform.position;
        playerLeftPosition = playerLeft.transform.position;
        playerRightPosition = playerRight.transform.position;
        playerRightGKPosition = playerRightGK.transform.position;
    }

    #region Triggers
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ball"))
        {
            AddScore();
            DeleteWildcards("wildcardSpeed");
            DeleteWildcards("wildcardDirection");
            DeleteWildcards("wildcardTeleport");
            DeleteWildcards("wildcardSmall");
        }
    }

    #endregion

    #region Methods
    private void AddScore()
    {
        scoreValue++;
        rightScore.text = scoreValue.ToString();
        //play audio

        resetBall.rndSpeed = 0f;
        StartCoroutine(resetBall.BallMove());
        ballPos.transform.position = new Vector2(0, 0);

        playerLeft.transform.position = playerLeftPosition;
        playerLeftGK.transform.position = playerLeftGKPosition;
        playerRight.transform.position = playerRightPosition;
        playerRightGK.transform.position = playerRightGKPosition;
    }

    private void DeleteWildcards(string tag)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
        foreach (GameObject target in gameObjects)
        {
            GameObject.Destroy(target);
        }
        spawnReset.spawnTimer = 0;
    }
    #endregion
}
