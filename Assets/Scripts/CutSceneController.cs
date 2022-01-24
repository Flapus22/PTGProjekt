using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutSceneController : MonoBehaviour
{
    PlayableDirector playable;
    void Start()
    {
        playable = GetComponent<PlayableDirector>();
        playable.stopped += StartGame;

    }
    void Update()
    {

    }
    public void StartGame(PlayableDirector aDirector)
    {
        if (aDirector == playable)
        {
            Camera.SetupCurrent(Camera.main);

        }
    }
}
