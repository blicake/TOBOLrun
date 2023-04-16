using System.Collections.Generic;
using UnityEngine;

public class ChunkPlacer : MonoBehaviour
{
    [SerializeField] private Transform PlayerTransform;
    [SerializeField] private Chunk[] ChunkPrefubs;
    [SerializeField] private Chunk[] FirstChunks;

    private Chunk newChunk;

    private List<Chunk> spawnedChunks = new List<Chunk>();

    private void Start()
    {
        for (int i = 0; i < FirstChunks.Length; i++)
        {
            spawnedChunks.Add(FirstChunks[i]);
        }
    }

    private void Update()
    {
        if (!Player._pause)
        { 
            if (PlayerTransform.position.z > (spawnedChunks[spawnedChunks.Count - 1].End.position.z - 50))
            {
                SpawnChunk();
                if (spawnedChunks.Count > 5)
                {
                    var temp = spawnedChunks[0].gameObject;
                    spawnedChunks.Remove(spawnedChunks[0]);
                    DestroyImmediate(temp, true);
                }
            }
        }
    }

    private void SpawnChunk()
    {
        newChunk = Instantiate(ChunkPrefubs[Random.Range(0, ChunkPrefubs.Length)]);
        newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].End.position - newChunk.Begin.localPosition;
        spawnedChunks.Add(newChunk);
    }
}
