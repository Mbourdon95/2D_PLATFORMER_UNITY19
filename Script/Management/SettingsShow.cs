using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class SettingsShow : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown dropResolution;
    //List<Resolution> resolutions;
    Resolution[] resolutions;

    // Start is called before the first frame update
    void Start()
    {
        //resolutions.Add(Screen.resolutions);
        resolutions = Screen.resolutions.Select(resolution => new Resolution { width=resolution.width, height=resolution.height}).Distinct().ToArray();
        dropResolution.ClearOptions();

        List<string> options = new List<string>();
        int currentScreen = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentScreen = i;
            }
        }

        dropResolution.AddOptions(options);
        dropResolution.value = currentScreen;
        dropResolution.RefreshShownValue();

        Screen.fullScreen = true;


    }

    public void SetVolumeGlobal(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void SetVolumeMusic(float volume)
    {
        audioMixer.SetFloat("Music", volume);
    }

    public void SetVolumeSoundEffect(float volume)
    {
        audioMixer.SetFloat("Sound", volume);
    }

    public void SetFullScreen(bool isClick)
    {
        Screen.fullScreen = isClick;
    }

    public void SetResolution(int resolutionI)
    {
        Resolution resolution = resolutions[resolutionI];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
