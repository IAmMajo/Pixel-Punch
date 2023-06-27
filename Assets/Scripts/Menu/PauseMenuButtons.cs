using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class PauseMenuButtons : MonoBehaviour
{
    [SerializeField]
    EventSystem eventSystem;

    [SerializeField]
    public GameObject firstSelectedElement;

    private void OnEnable()
    {
        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(firstSelectedElement);
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        transform.parent.gameObject.SetActive(false);
    }
    public void Settings() { }
    public void MainMenu()
    {
        SceneManager.LoadScene("Assets/Menus/StartMenu.unity");
    }
}
