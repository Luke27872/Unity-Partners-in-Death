using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private bool muted = false;
    public Button muteButton;
    public Sprite mutedSprite;
    public Sprite unmutedSprite;

    public void PLayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Mute()
    {
        if (muted == false)
        {
            AudioListener.volume = 0;
            muted = true;
            muteButton.GetComponent<Image>().sprite = mutedSprite;
        }
        else
        {
            AudioListener.volume = 1;
            muted = false;
            muteButton.GetComponent<Image>().sprite = unmutedSprite;
        }
    }
}
