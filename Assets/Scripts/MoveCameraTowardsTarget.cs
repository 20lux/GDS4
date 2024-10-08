using UnityEngine;

public class MoveCameraTowardsTarget : MonoBehaviour
{
    public Transform target;
    public Transform player;
    public float speed = 5;
    public AudioSource gameControllerAudio;
    public AudioClip spaceSound;
    public bool isMoving = false;

    public void Moving()
    {
        isMoving = true;
        gameControllerAudio.clip = spaceSound;
        gameControllerAudio.loop = false;
        gameControllerAudio.Play();
    }

    void Update()
    {
        if (isMoving)
        {
            var step = speed * Time.deltaTime;
            player.transform.position = Vector3.MoveTowards(player.transform.position, target.position, step);
        }
    }
}
