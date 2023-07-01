using UnityEngine;
using UnityEngine.EventSystems;
public class PanelOpener : MonoBehaviour
{

    public GameObject settings;
    public GameObject dBtSettings;
    public GameObject defaulOverlay;
    public GameObject dBtDefaultOverlay;


    public void OpenSettings()
    {
        settings.SetActive(true);
        defaulOverlay.SetActive(false);
    }

    public void CloseSettings()
    {
        settings.SetActive(false);
        defaulOverlay.SetActive(true);
    }

}
