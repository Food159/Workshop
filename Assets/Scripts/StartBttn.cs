using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBttn : MonoBehaviour
{
    public void OnPressStartBttn()
    {
        SceneManager.LoadScene("GamePlayScene");
        //GameManager.instance.gameObject.SetActive(false);
    }
}
