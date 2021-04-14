using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class VideoManager : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public TMP_Dropdown graphicsDropdown;

    Resolution[] resolutions;
    void Start()
    {
        resolutions = Screen.resolutions;
        List<TMP_Dropdown.OptionData> resolutionOptions = new List<TMP_Dropdown.OptionData>();
        resolutionDropdown.ClearOptions();
        int currentResolutionIndex = 0;
        int i = 0;
        foreach (var res in resolutions)
        {
            TMP_Dropdown.OptionData data = new TMP_Dropdown.OptionData();
            data.text = res.width + " x " + res.height;
            resolutionOptions.Add(data);

            if(res.width == Screen.currentResolution.width && res.height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
            i++;
        }

        resolutionDropdown.AddOptions(resolutionOptions);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        string[] qualities = QualitySettings.names;
        List<TMP_Dropdown.OptionData> graphicOptions = new List<TMP_Dropdown.OptionData>();
        graphicsDropdown.ClearOptions();
        foreach (string quality in qualities)
        {
            TMP_Dropdown.OptionData data = new TMP_Dropdown.OptionData();
            data.text = quality;
            graphicOptions.Add(data);
        }

        graphicsDropdown.AddOptions(graphicOptions);
        SetQuality(graphicOptions.Count - 1);
        graphicsDropdown.value = graphicOptions.Count - 1;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
