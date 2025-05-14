using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBttn : MonoBehaviour
{
    public void OnPressStartBttn()
    {
        SceneManager.LoadScene("GamePlayScene");
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        //GameManager.instance.gameObject.SetActive(false);
    }
    public void OnPressQuitBttn()
    {
        Application.Quit();
    }
}
