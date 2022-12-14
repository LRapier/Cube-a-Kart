using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Respawn : MonoBehaviour
{
    public float respawnNumber;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (respawnNumber)
            {
                case 1:
                    other.gameObject.transform.position = new Vector3(0f, 2.5f, 150f);
                    other.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                    break;
                case 2:
                    other.gameObject.transform.position = new Vector3(0f, 2.5f, 300f);
                    other.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                    break;
                case 3:
                    other.gameObject.transform.position = new Vector3(-40f, 2.5f, 310f);
                    other.gameObject.transform.eulerAngles = new Vector3(0, -90, 0);
                    break;
                case 4:
                    other.gameObject.transform.position = new Vector3(-150f, 2.5f, 310f);
                    other.gameObject.transform.eulerAngles = new Vector3(0, -90, 0);
                    break;
                case 5:
                    other.gameObject.transform.position = new Vector3(-300f, 2.5f, 310f);
                    other.gameObject.transform.eulerAngles = new Vector3(0, -90, 0);
                    break;
                case 6:
                    other.gameObject.transform.position = new Vector3(-320f, 2.5f, 270f);
                    other.gameObject.transform.eulerAngles = new Vector3(0, -180, 0);
                    break;
                case 7:
                    other.gameObject.transform.position = new Vector3(-320f, 2.5f, 150f);
                    other.gameObject.transform.eulerAngles = new Vector3(0, -180, 0);
                    break;
                case 8:
                    other.gameObject.transform.position = new Vector3(-320f, 2.5f, 0f);
                    other.gameObject.transform.eulerAngles = new Vector3(0, -180, 0);
                    break;
                case 9:
                    other.gameObject.transform.position = new Vector3(-280f, 2.5f, -10f);
                    other.gameObject.transform.eulerAngles = new Vector3(0, -270, 0);
                    break;
                case 10:
                    other.gameObject.transform.position = new Vector3(-150f, 2.5f, -10f);
                    other.gameObject.transform.eulerAngles = new Vector3(0, -270, 0);
                    break;
                case 11:
                    other.gameObject.transform.position = new Vector3(-10f, 2.5f, -10f);
                    other.gameObject.transform.eulerAngles = new Vector3(0, -270, 0);
                    break;
                case 12:
                    other.gameObject.transform.position = new Vector3(0f, 2.5f, 40f);
                    other.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                    break;
            }
        }
    }
}
