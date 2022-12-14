using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class GameUI : MonoBehaviourPun
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI finishText;
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI lapNum;

    private PlayerController player;

    public static GameUI instance;

    private int min;
    private string placementSuffix;
    private int sec;
    public float startTime;
    public float countdownTime = 3f;
    public float finishTime;

    void Awake()
    {
        instance = this;
    }

    public void Initialize(PlayerController localPlayer)
    {
        player = localPlayer;
    }

    public void Finish()
    {
        switch (player.place)
        {
            case 1:
                placementSuffix = "st";
                break;
            case 2:
                placementSuffix = "nd";
                break;
            case 3:
                placementSuffix = "rd";
                break;
            default:
                placementSuffix = "th";
                break;
        }
        finishTime = Mathf.FloorToInt(Time.time - startTime);
        finishText.text = ("FINISH!\nYOU GOT " + player.place + placementSuffix + " PLACE!\n\nYOUR TIME WAS " + Mathf.FloorToInt((finishTime) / 60) + ":" + Mathf.FloorToInt((Time.time - startTime) % 60));
        timerText.gameObject.SetActive(false);
    }

    public void Update()
    {
        if (GameManager.instance.started)
        {
            min = Mathf.FloorToInt((Time.time - startTime) / 60);
            sec = Mathf.FloorToInt((Time.time - startTime) % 60);

            timerText.text = min.ToString("00") + ":" + sec.ToString("00");
        }
    }

    public void Begin()
    {
        startTime = Time.time;
    }

    public void GameOver()
    {
        finishText.gameObject.SetActive(false);
    }

    [PunRPC]
    public void StartCountdown()
    {
        StartCoroutine(CountdownCoRoutine());

        IEnumerator CountdownCoRoutine()
        {
            countdownText.text = "3";

            yield return new WaitForSeconds(1f);

            countdownText.text = "2";

            yield return new WaitForSeconds(1f);

            countdownText.text = "1";

            yield return new WaitForSeconds(1f);

            countdownText.text = "GO!";
            GameManager.instance.started = true;
            Begin();

            yield return new WaitForSeconds(1f);

            countdownText.gameObject.SetActive(false);
        }
    }
}