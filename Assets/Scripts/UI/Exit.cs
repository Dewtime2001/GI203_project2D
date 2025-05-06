using UnityEngine;

public class Exit : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();

        UnityEditor.EditorApplication.isPlaying = false;
    }
}
