using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int Coins = 0;
    public int RequiredCoins;
    public int SquadRemaining;

    public Text SquadCounter;
    public AudioSource audioSource;

    public void CountCoin()
    {
        audioSource.Play();
        Coins++;
    }

    private void Update()
    {
        if (Coins >= RequiredCoins)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        SquadCounter.text = SquadRemaining.ToString();
    }
}
