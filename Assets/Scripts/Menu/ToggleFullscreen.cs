using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleFullscreen : MonoBehaviour
{
  public void SetFullscreen(bool isFullscreen) {
    Screen.fullScreen = isFullscreen; 
  }
}
