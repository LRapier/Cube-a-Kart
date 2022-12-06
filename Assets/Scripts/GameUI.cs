using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class GameUI : MonoBehaviour
{
    public Slider healthBar;
    public TextMeshProUGUI playerInfoText;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI winText;
    public Image winBackground;

    private PlayerController player;

    public static GameUI instance;

    void Awake()
    {
        instance = this;
    }

    public void Initialize(PlayerController localPlayer)
    {
        player = localPlayer;

        UpdatePlayerInfoText();
        UpdateAmmoText();
    }

    public void UpdateHealthBar()
    {

    }

    public void UpdatePlayerInfoText()
    {
        playerInfoText.text = "<b>Remaining:</b>" + GameManager.instance.alivePlayers + "\n<b> Kills:</b> ";
    }

    public void UpdateAmmoText()
    {

    }

    public void SetWinText(string winnerName, int winnerKills)
    {
        winBackground.gameObject.SetActive(true);
        winText.text = winnerName + " Wins!\nThey had " + (winnerKills + 1) + " Kills!";
    }
}