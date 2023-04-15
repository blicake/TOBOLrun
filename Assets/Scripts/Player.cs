using System;
using System.Collections;
using System.IO;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject Shield;
    [SerializeField] GameObject WinMenu;

    public static bool _pause;
    public static int _coins;
    public static int _score;
    public static int _highscore;
    public static bool _shield;
    public static bool _finish;
    public static bool _death;

    private float _gameTime;
    private float _time;
    private float startingPos;

    [Serializable]
    public class SettingsContainer
    {
        public int currentCoins;
        public int highscore;
        public bool soundSwitch;
    }

    private void Start()
    {
        startingPos = transform.position.z;
        _score = 0;
        _death = false;
        _pause = false;
        _time = 30f;
        _gameTime = 0f;
        _shield = false;
        string jsonContainer = File.ReadAllText("Assets/jsonContainer.json");
        SettingsContainer myCoins = JsonUtility.FromJson<SettingsContainer>(jsonContainer);
        _coins = myCoins.currentCoins;
        _highscore = myCoins.highscore;
        Sounds.state = myCoins.soundSwitch;
    }

    private void Update()
    {
        _score = (int)(transform.position.z - startingPos);
        if(!_pause) _gameTime += Time.deltaTime;
        if (_gameTime > _time) _finish = true;
        if (_shield) StartCoroutine("ShieldEnable");
        if (_death) Death();
    }
    private void Death()
    {
        if (_score > _highscore) _highscore = _score;
        _pause = true;
        WinMenu.SetActive(true);
        SettingsContainer myCoins = new();
        myCoins.currentCoins += _coins;
        myCoins.highscore = _highscore;
        myCoins.soundSwitch = Sounds.state;
        string jsonContainer = JsonUtility.ToJson(myCoins);
        File.WriteAllText("Assets/jsonContainer.json", jsonContainer);
    }
    IEnumerator ShieldEnable()
    {
        _shield = false;
        Shield.SetActive(true);
        yield return new WaitForSeconds(2f);
        float time = 0f;
        while(time < 1f)
        {
            Shield.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            Shield.SetActive(true);
            time += 0.2f;
        }
        yield return new WaitForSeconds(0.2f);
        Shield.SetActive(false);
    }
}
