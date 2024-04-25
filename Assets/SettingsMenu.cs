using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer; // Correction : "AudioMixer" devrait commencer par une majuscule

    public Dropdown resolutionDropdown;

    Resolution[] resolutions; // Correction : le tableau de résolutions devrait être nommé "resolutions"

    public void Start()
    {
        resolutions = Screen.resolutions; // Correction : "Screen.resolutions" au lieu de "Screen.resolution"
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++) // Correction : "resolutions.Length" au lieu de "resolution.Length"
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option); // Correction : ajouter l'option à la liste à chaque itération
        }

        resolutionDropdown.AddOptions(options); // Correction : "resolutionDropdown.AddOptions" au lieu de "ResolutionDropdown.AddOption"
    }

    public void SetVolume(float volume) // Correction : suppression du point-virgule après la signature de la méthode
    {
        audioMixer.SetFloat("volume", volume); // Correction : "audioMixer" avec une minuscule, et le nom du paramètre "volume" sans guillemets
    }

    public void SetFullScreen(bool isFullScreen) // Correction : suppression du point-virgule après la signature de la méthode
    {
        Screen.fullScreen = isFullScreen;
    }
}