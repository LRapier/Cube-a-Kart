using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerController : MonoBehaviourPun
{
    public int id;
    public Rigidbody rb;
    public float forwardForce = 50f;
    public float turnForce = 50f;
    public Vector3 point;

    public int laps;
    public int place = 0;
    public int priority;
    public bool started = false;
    public bool notCheating = false;
    public Player photonPlayer;

    [Header("Materials")]
    public Material player1;
    public Material player2;
    public Material player3;
    public Material player4;
    public Material player5;
    public Material player6;

    void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            Vector3 dir = (transform.forward) * forwardForce;
            dir.y = rb.velocity.y;

            rb.velocity = dir;

            point = transform.position;
            if (Input.GetKey(KeyCode.A))
            {
                transform.RotateAround(point, -Vector3.up, turnForce * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.RotateAround(point, Vector3.up, turnForce * Time.deltaTime);
            }
            if (Input.GetKey("left"))
            {
                transform.RotateAround(point, -Vector3.up, turnForce * Time.deltaTime);
            }
            else if (Input.GetKey("right"))
            {
                transform.RotateAround(point, Vector3.up, turnForce * Time.deltaTime);
            }
        }
    }

    [PunRPC]
    public void Initialize(Player player)
    {
        photonPlayer = player;
        id = player.ActorNumber;
        GameManager.instance.players[id - 1] = this;
        GameManager.instance.spawnPointToUse = id-1;

        MeshRenderer renderer = GetComponent<MeshRenderer>();
        switch (id)
        {
            case 1:
                renderer.material = player1;
                break;
            case 2:
                renderer.material = player2;
                break;
            case 3:
                renderer.material = player3;
                break;
            case 4:
                renderer.material = player4;
                break;
            case 5:
                renderer.material = player5;
                break;
            case 6:
                renderer.material = player6;
                break;
        }

        if (!photonView.IsMine)
        {
            rb.isKinematic = true;
            GetComponentInChildren<Camera>().gameObject.SetActive(false);
        }
        else
        {
            GameUI.instance.Initialize(this);
            started = true;
            forwardForce = 0f;
            turnForce = 0f;

            StartCoroutine(StartRaceCoRoutine());

            IEnumerator StartRaceCoRoutine()
            {
                yield return new WaitForSeconds(3f);

                StartRace();
            }
        }
    }

    public void Finish()
    {
        forwardForce = 0f;
        turnForce = 0f;
        this.transform.position = new Vector3(this.transform.position.x, 1000, this.transform.position.z);
        rb.constraints = RigidbodyConstraints.FreezePositionY;
        GameUI.instance.Finish();
        Leaderboard.instance.leaderboardCanvas.SetActive(true);
        Leaderboard.instance.DisplayLeaderboard();
        Leaderboard.instance.SetLeaderboardEntry(-Mathf.RoundToInt(GameUI.instance.finishTime * 1000.0f));
    }

    public void SetPlace(int placement)
    {
        place = placement;
    }

    public void StartRace()
    {
        forwardForce = 50f;
        turnForce = 50f;
    }

    [PunRPC]
    public void CompleteLap(int placement)
    {
        if (notCheating)
        {
            laps++;
            if (laps == 3)
            {
                SetPlace(placement);
                FinishLine.instance.photonView.RPC("IncreasePlace", RpcTarget.All);
                GameUI.instance.lapNum.gameObject.SetActive(false);
                Finish();
            }
            GameUI.instance.lapNum.text = "LAP " + (laps + 1);
            notCheating = false;
        }
    }

    [PunRPC]
    public void NotCheating()
    {
        notCheating = true;
    }
}
