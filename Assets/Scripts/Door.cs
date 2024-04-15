using Unity.VisualScripting;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Transform backDoor;
    private GameObject player;

    private void Update()
    {
        if (player!=null && Input.GetKeyDown(KeyCode.W))
        {
            if (backDoor != null)
                player.transform.position = backDoor.position;
            else
                Debug.Log("此门无目的地");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        player = other.gameObject;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        player = null;
    }
}
