using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        transform.position = new Vector3(22, 26, 7);
    }
    void FixedUpdate()
    {
        //The main camara get the position of my Player
        transform.position = player.transform.position + new Vector3(1, 25, -5);
    }
}
