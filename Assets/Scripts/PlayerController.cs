using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerController : MonoBehaviourPun
{
    public int id;
    public Rigidbody rb;
    public float forwardForce = 25f;
    public float turnForce;
    public Vector3 point;

    public int laps = 1;
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
        if (rb.position.y <= -1f)
        {
            //Respawn();
            Debug.Log(rb.position.x);
        }
    }

    [PunRPC]
    public void Initialize(Player player)
    {
        photonPlayer = player;
        id = player.ActorNumber;
        GameManager.instance.players[id - 1] = this;

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
            rb.isKinematic = true;
    }

    void Respawn()
    {
        if((transform.position.z >= 150 && transform.position.z <= 225) && (transform.position.x >= -150 && transform.position.x <= 50))
        {

        }
        else if ((transform.position.z >= 225 && transform.position.z <= 475) && (transform.position.x >= -150 && transform.position.x <= 225))
        {

        }
        else if ((transform.position.z >= 290 && transform.position.z <= 475) && (transform.position.x >= -150 && transform.position.x <= -75))
        {

        }
        else if ((transform.position.z >= 225 && transform.position.z <= 475) && (transform.position.x >= -300 && transform.position.x <= -150))
        {

        }
        else if ((transform.position.z >= 225 && transform.position.z <= 475) && (transform.position.x >= -300 && transform.position.x <= 225))
        {

        }
        else if ((transform.position.z >= 225 && transform.position.z <= 475) && (transform.position.x >= -300 && transform.position.x <= 225))
        {

        }
        else if ((transform.position.z >= 225 && transform.position.z <= 475) && (transform.position.x >= -300 && transform.position.x <= 225))
        {

        }
        else if ((transform.position.z >= 225 && transform.position.z <= 475) && (transform.position.x >= -300 && transform.position.x <= 225))
        {

        }
        else if ((transform.position.z >= 225 && transform.position.z <= 475) && (transform.position.x >= -300 && transform.position.x <= 225))
        {

        }
        else if ((transform.position.z >= 225 && transform.position.z <= 475) && (transform.position.x >= -300 && transform.position.x <= 225))
        {

        }
        else if ((transform.position.z >= 225 && transform.position.z <= 475) && (transform.position.x >= -300 && transform.position.x <= 225))
        {

        }
        else if ((transform.position.z >= 225 && transform.position.z <= 475) && (transform.position.x >= -300 && transform.position.x <= 225))
        {

        }
    }

    public void Finish()
    {

    }
}
