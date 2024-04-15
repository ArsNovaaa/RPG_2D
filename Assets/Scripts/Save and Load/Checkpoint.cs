using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Animator anim;
    public string id;
    public bool activationStatus;

    private Player player;
    private bool recover;

    /*private void OnValidate()
    {
        Debug.Log(id.ToString());
        GenerateId();
    }*/
    private void Start()
    {
        anim = GetComponent<Animator>();

        player = PlayerManager.instance.player;
    }

    [ContextMenu("Generate checkpoint id")]
    private void GenerateId()
    {
        /*if (id.ToString() == null)
        {
            id = System.Guid.NewGuid().ToString();
            Debug.Log(id.ToString());
        }*/
        id = System.Guid.NewGuid().ToString();
    }

    private void Update()
    {
        if (recover && !player.GetComponent<PlayerStats>().isDead)
            player.stats.IncreaseHealthBy(1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            /*if (activationStatus == false)
                player.stats.IncreaseHealthBy(player.stats.GetMaxHealthValue());*/

            ActivateCheckpoint();

            recover = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        recover = false;
    }



    public void ActivateCheckpoint()
    { 
        if (activationStatus == false)
            AudioManager.instance.PlaySFX(5, transform);
        

        activationStatus = true;
        anim.SetBool("active", true);
    }
}
