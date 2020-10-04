using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScene : MonoBehaviour
{
    public static EndScene singleton { get; private set; }
    private void Awake()
    {
        singleton = this;
    }
    private void Start()
    {
        DeathAvailable = true;
    }

    public bool DeathAvailable;
    public GameObject pelena;
    public GameObject dogovor;
    public AudioSource source;
    public AudioClip paper;

    public List<GameObject> otherCanvases = new List<GameObject>();

    public void StartEndScene()
    {
        StartCoroutine("SceneEnd");
    }

    IEnumerator SceneEnd()
    {
        if (DeathAvailable)
        {
            _Timer.singleton.isActive = false;

            foreach(var i in otherCanvases)
            {
                i.SetActive(false);
            }

            DeathAvailable = false;
            pelena.SetActive(true);
            yield return new WaitForSeconds(5);
            source.clip = paper;
            source.Play();
            dogovor.SetActive(true);
            yield return new WaitForSeconds(3);
            dogovor.SetActive(false);
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        }

    }
}
