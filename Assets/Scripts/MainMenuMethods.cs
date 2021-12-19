using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuMethods : MonoBehaviour
{
    [Header("Volume Setting")]
    [SerializeField] private Slider volumeSlider = null;

    [Header("Gameplay Setting")]
    [SerializeField] private Slider mouseSensitivity = null;
    [SerializeField] private int defaultSen = 4;
    public int mainMouseSen = 4;

    [Header("Toggle Setting")]
    [SerializeField] private Toggle invertYToggle = null;

    public void NewGameButton()
    {
        int sceneID = 1;
        SceneManager.LoadScene(sceneID);
    }

    public void LoadGameButton()
    {
        int sceneID = 1;
        SceneManager.LoadScene(sceneID); //tymczasowo robi to samo co NewGameButton
    }

    public void ExitButton()
    {
        Application.Quit();
    }


    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
    }

    public void SetMouseSen(float sensitivity)
    {
        mainMouseSen = Mathf.RoundToInt(sensitivity);
    }

    public void GameplayApply()
    {
        if (invertYToggle.isOn)
        {
            PlayerPrefs.SetInt("masterInvertY", 1);
        }
        else
        {
            PlayerPrefs.SetInt("masterInvertY", 0);
        }

        PlayerPrefs.SetFloat("masterSen", mainMouseSen);
    }
}
