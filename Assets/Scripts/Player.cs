using System;
using System.Collections;
using System.IO;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject Shield;
    [SerializeField] GameObject WinMenu;
    [SerializeField] GameObject WinMenuText;
    [SerializeField] GameObject LoseMenuText;

    public static bool _pause;
    public static int _coins;
    public static bool _shield;
    public static bool _finish;
    public static bool _death;

    private float _gameTime;
    private float _time;

    [Serializable]
    public class SettingsContainer
    {
        public int currentCoins;
        public bool soundSwitch;
    }

    private void Start()
    {
        _death = false;
        _pause = false;
        _time = 30f;
        _gameTime = 0f;
        _shield = false;
        string jsonContainer = File.ReadAllText("Assets/jsonContainer.json");
        SettingsContainer myCoins = JsonUtility.FromJson<SettingsContainer>(jsonContainer);
        _coins = myCoins.currentCoins;
        Sounds.state = myCoins.soundSwitch;
    }

    private void Update()
    {
        if(!_pause) _gameTime += Time.deltaTime;
        if (_gameTime > _time) _finish = true;
        if (_shield) StartCoroutine("ShieldEnable");
        if (_death) Death();
    }
    private void Death()
    {
        _pause = true;
        WinMenu.SetActive(true);
        LoseMenuText.SetActive(true);
        SettingsContainer myCoins = new();
        myCoins.currentCoins += _coins;
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
