using UnityEngine;
using UnityEngine.Video;

public class VideoMeshPlayer : MonoBehaviour
{
    public VideoPlayer meshPlayer;

    void Start()
    {
        meshPlayer = GetComponent<VideoPlayer>();
    }

    public void PlayVideoMesh()
    {
        meshPlayer.Play();
    }
}
