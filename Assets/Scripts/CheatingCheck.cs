using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CheatingCheck : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (!PhotonNetwork.IsMasterClient)
            return;

        if (other.CompareTag("Player"))
        {
            PlayerController player = GameManager.instance.GetPlayer(other.gameObject);

            player.notCheating = true;
        }
    }
}
