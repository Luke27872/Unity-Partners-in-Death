using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject Player;
    public GameController gameController;

    private void Start()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        if (gameController.SquadRemaining > 0)
        {
            Instantiate(Player, transform.position, Quaternion.identity);
            gameController.SquadRemaining--;
        }
    }
}
