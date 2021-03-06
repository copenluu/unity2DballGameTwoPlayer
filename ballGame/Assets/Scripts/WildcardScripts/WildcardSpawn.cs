using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WildcardSpawn : MonoBehaviour
{
    #region Public Variables
    public float spawnTimer = 0f;
    #endregion
    #region Inspector Variables
    [SerializeField] private int numToSpawn;
    [SerializeField] private List<GameObject> spawnPool;
    [SerializeField] private GameObject spawnRange;
    [SerializeField] float spawnSpeed = 10f;
    #endregion
    #region Private Variables
    private bool timerstatus = true;
    #endregion
    #region Components
    AudioSource popClip;
    #endregion

    private void Start()
    {
        popClip = GetComponent<AudioSource>();
    }

    private void Update()
    {
        SpawnRate();
    }



    #region Method
    public void SpawnObjects()
    {
        int randomItem = 0;
        GameObject toSpawn;
        MeshCollider c = spawnRange.GetComponent<MeshCollider>();

        float screenX, screenY;
        Vector2 pos;

        for (int i = 0; i < numToSpawn; i++)
        {
            randomItem = Random.Range(0, spawnPool.Count);
            toSpawn = spawnPool[randomItem];

            screenX = Random.Range(c.bounds.min.x, c.bounds.max.x);
            screenY = Random.Range(c.bounds.min.y, c.bounds.max.y);

            pos = new Vector2(screenX, screenY);
            Instantiate(toSpawn, pos, toSpawn.transform.rotation);
            popClip.Play();
        }
    }

    private void SpawnRate()
    {
        if (timerstatus)
        {
            spawnTimer += Time.deltaTime;
        }

        if (spawnTimer > spawnSpeed)
        {
            SpawnObjects();
            spawnTimer = 0f;
        }
    }

    #endregion

}
