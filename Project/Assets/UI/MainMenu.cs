using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    public void OnClickStartGame()
    {
        gameObject.SetActive(false);
        audioSource.Stop();
    }

    public void OnClickExitGame()
    {
        Application.Quit();
    }
}
