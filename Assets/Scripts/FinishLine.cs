using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class FinishLine : MonoBehaviourPun
{
    public int place = 1;
    public bool halfway;
    public GameUI gameUI;

    public static FinishLine instance;

    void Awake()
    {
        instance = this;
    }

    void OnTriggerEnter(Collider other)
    {
        if (!PhotonNetwork.IsMasterClient)
            return;

        if (other.CompareTag("Player"))
        {
            PlayerController player = GameManager.instance.GetPlayer(other.gameObject);

            if (!halfway)
            {
                player.photonView.RPC("CompleteLap", player.photonPlayer, place);
            }
            else
            {
                player.photonView.RPC("NotCheating", player.photonPlayer);
            }
        }
    }

    [PunRPC]
    void IncreasePlace()
    {
        place++;
    }
}