using System.Collections.Generic;
using UnityEngine;

public class ChunkPlacer : MonoBehaviour
{
    [SerializeField] private Transform PlayerTransform;
    [SerializeField] private Chunk[] ChunkPrefubs;
    [SerializeField] private Chunk FirstChunk;

    private Chunk newChunk;

    private List<Chunk> spawnedChunks = new List<Chunk>();

    private int finishRoadIndex;

    private bool _finalRoad = false;

    private void Start()
    {
        spawnedChunks.Add(FirstChunk);
        finishRoadIndex = ChunkPrefubs.Length - 1;
    }

    private void Update()
    {
        if (!Player._pause && !_finalRoad)
        { 
            if (PlayerTransform.position.z > (spawnedChunks[spawnedChunks.Count - 1].End.position.z - 20))
            {
                SpawnChunk();
                if (spawnedChunks.Count > 3)
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
        if (_finalRoad) return;
        if (!Player._finish)
        {
            newChunk = Instantiate(ChunkPrefubs[Random.Range(0, ChunkPrefubs.Length - 1)]);
            newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].End.position - newChunk.Begin.localPosition;
            spawnedChunks.Add(newChunk);
        }
        else
        {
            newChunk = Instantiate(ChunkPrefubs[finishRoadIndex]);
            newChunk.transform.position = spawnedChunks[spawnedChunks.Count - 1].End.position - newChunk.Begin.localPosition;
            spawnedChunks.Add(newChunk);
            _finalRoad = true;
        }
        
    }
}
