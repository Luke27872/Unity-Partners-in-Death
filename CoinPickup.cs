using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    public GameController gameController_script;
    public GameObject GameController_OBJ;

    private void Start()
    {
        GameController_OBJ = GameObject.FindWithTag("GameController");
        gameController_script = GameController_OBJ.GetComponent<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameController_script.CountCoin();
            Destroy(gameObject);
        }
    }
}