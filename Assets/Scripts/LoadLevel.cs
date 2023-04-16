using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public void LoadIntro()
    {
        SceneManager.LoadScene(1);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(2);
    }
    public void LoadGameWithBonus()
    {
        StartCoroutine("Intro");
    }
    
    IEnumerator Intro()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(2);
    }
}
