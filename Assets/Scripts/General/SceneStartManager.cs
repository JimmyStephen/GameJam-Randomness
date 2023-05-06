using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneStartManager : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField] bool PlayMusic = true;
    [SerializeField] bool StopMusic = false;
    [SerializeField, Tooltip("-1 for no audio")] int MusicIndex = -1;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayMusic) AudioManager.Instance.PlayAudio(MusicIndex);
        if (StopMusic) AudioManager.Instance.StopAudio();
    }

    public void ChangeScene(int index)
    {
        SceneLoader.Instance.LoadScene(index);
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}
