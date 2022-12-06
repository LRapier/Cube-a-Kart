using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FinishLine : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!PhotonNetwork.IsMasterClient)
            return;

        if (other.CompareTag("Player"))
        {
            PlayerController player = GameManager.instance.GetPlayer(other.gameObject);

            if (!player.started)
                player.started = true;
            else if (player.notCheating)
            {
                player.laps++;
                player.notCheating = false;
            }

            if (player.laps == 3)
                player.Finish();
        }
    }
}
