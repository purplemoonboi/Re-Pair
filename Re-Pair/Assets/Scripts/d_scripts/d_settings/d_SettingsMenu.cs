using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class d_SettingsMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer m_mixer;
    [SerializeField] private Dropdown m_resolutionDropdown;

    private Resolution[] m_resolutions;

    private void Start()
    {
        m_resolutions = Screen.resolutions;

        m_resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int l_currentRes = 0;

        for(int i = 0; i < m_resolutions.Length; i++)
        {
            string option = m_resolutions[i].width + " x " + m_resolutions[i].height;
            options.Add(option);

            if(m_resolutions[i].width == Screen.currentResolution.width && m_resolutions[i].height == Screen.currentResolution.height)
            {
                l_currentRes = i;
            }
        }

        m_resolutionDropdown.AddOptions(options);
        m_resolutionDropdown.value = l_currentRes;
        m_resolutionDropdown.RefreshShownValue();
    }

    public void setVolume(float volume)
    {
        m_mixer.SetFloat("Volume", volume);
    }

    public void setQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void setFullscreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void setResolution(int resIndex)
    {
        Resolution resolution = m_resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}