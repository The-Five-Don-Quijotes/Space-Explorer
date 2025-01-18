using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Ingame Scence");
    }

    public void ShowInstruction()
    {
        SceneManager.LoadScene("Instruction Scene");
    }
}
