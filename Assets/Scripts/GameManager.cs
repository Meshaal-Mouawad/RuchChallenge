using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AudioSource backgroundMusic;

    void Start()
    {
        backgroundMusic.Play();
    }
}