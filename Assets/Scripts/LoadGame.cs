using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LoadGame : MonoBehaviour
{
    [SerializeField] VideoPlayer video;
    void Start()
    {
        StartCoroutine("Load");
    }

    IEnumerator Load()
    {
        yield return new WaitForSeconds(0.1f);
        yield return new WaitWhile(() => video.isPlaying);
        SceneManager.LoadScene(2);
    }
}
