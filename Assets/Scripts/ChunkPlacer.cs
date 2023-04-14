using System.Collections.Generic;
using UnityEngine;

public class ChunkPlacer : MonoBehaviour
{
    #region

    [SerializeField] private Transform PlayerTransform;
    [SerializeField] private Chunk[] ChunkPrefubs;
    [SerializeField] private Chunk FirstChunk;
    public static bool _finish = false;

    public static bool _trueFinish = false;

    private Chunk newChunk;

    private List<Chunk> spawnedChunks = new List<Chunk>();

    private int finishRoadIndex;

    private bool _finalRoad = false;

    #endregion

    #region UnityMethods

    private void Start()
    {
        spawnedChunks.Add(FirstChunk);
        finishRoadIndex = ChunkPrefubs.Length - 1;
    }

    private void Update()
    {
        if (/*!Player._timeStop && */!_finalRoad)
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

    #endregion

    #region OtherMethods

    private void SpawnChunk()
    {
        if (_finalRoad) return;
        if (!_finish)
        {
            newChunk = Instantiate(ChunkPrefubs[0]);
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

    #endregion
}
