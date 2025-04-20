using UnityEngine;

public class ExitButton : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Exit wurde geklickt");
        Application.Quit();
    }
}
