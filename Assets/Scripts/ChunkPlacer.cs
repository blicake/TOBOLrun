using System.Collections.Generic;
using UnityEngine;

public class ChunkPlacer : MonoBehaviour
{
    [SerializeField] private Transform PlayerTransform;
    [SerializeField] private Chunk[] ChunkPrefubs;
    [SerializeField] private Chunk[] FirstChunks;

    private Chunk newChunk;
    private int jump;
    private int slide;
    private int money;
    private List<GameObject> spawnedChunks = new List<GameObject>();

    private void Start()
    {
        jump = 0;
        slide = 0;
        money = 0;
        for (int i = 0; i < FirstChunks.Length; i++)
        {
            spawnedChunks.Add(FirstChunks[i].gameObject);
        }
    }

    private void Update()
    {
        if (!Player._pause)
        { 
            if (PlayerTransform.position.z > (spawnedChunks[spawnedChunks.Count - 1].GetComponent<Chunk>().End.position.z - 100))
            {
                TryChunk();
                Debug.Log(spawnedChunks.Count);
                if (spawnedChunks.Count > 7)
                {
                    var temp = spawnedChunks[0].gameObject;
                    spawnedChunks.Remove(spawnedChunks[0]);
                    Destroy(temp);
                }
            }
        }
    }

    private void TryChunk()
    {
        newChunk = ChunkPrefubs[Random.Range(0, ChunkPrefubs.Length)];
        if (newChunk.gameObject.tag == "jump" && jump < 2)
        {
            jump++;
            money = 0;
            slide = 0;
            SpawnChunk(newChunk);
            return;
        }
        if (newChunk.gameObject.tag == "slide" && slide < 2)
        {
            jump = 0;
            money = 0;
            slide++;
            SpawnChunk(newChunk);
            return;
        }
        if (newChunk.gameObject.tag == "money" && money < 2)
        {
            jump = 0;
            money++;
            slide = 0;
            SpawnChunk(newChunk);
            return;
        }
        //TryChunk();
    }

    private void SpawnChunk(Chunk newChunk)
    {
        Chunk nc = Instantiate(newChunk);
        nc.gameObject.transform.position = spawnedChunks[spawnedChunks.Count - 1].GetComponent<Chunk>().End.position;
        spawnedChunks.Add(nc.gameObject);
    }
}
