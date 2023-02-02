using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerOrder : MonoBehaviour
{
    public string[] playerOrder;
    public Sprite[] players;

    public Image Slot1;
    public Image Slot2;
    public Image Slot3;

    public void AddPlayer(int player)
    {
        if (playerOrder[0] == "Empty")
        {
            Slot1.sprite = players[player];
            playerOrder[0] = "Full";
        }
        else if (playerOrder[1] == "Empty")
        {
            Slot2.sprite = players[player];
            playerOrder[1] = "Full";
        }
        else if (playerOrder[2] == "Empty")
        {
            Slot3.sprite = players[player];
            playerOrder[2] = "Full";
        }
    }
}
