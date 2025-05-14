using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public InventoryPanel inventoryPanel;

    public ItemData targetItem;
    public float timerCounter;
    public int targetAmount = 5;

    public TMP_Text timerCounterText;
    public Image targetImageIcon;
    public TMP_Text targetAmountText;
    public GameObject winCanvas;
    public GameObject loseCanvas;
    public GameObject gameManagerCanvas;

    public bool isPlayerWin = false;

    void Start()
    {
        targetImageIcon.sprite = targetItem.itemIcon;
    }
    private void Update()
    {
        //if (isPlayerWin) return;
        if (isPlayerWin)
        {
            winCanvas.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            gameManagerCanvas.SetActive(false);
            Time.timeScale = 0;
        }
        if (timerCounter > 0f)
        {
            timerCounter -= Time.deltaTime;
            //timerCounterText.text = timerCounter.ToString();
            timerCounterText.text = Convert.ToInt32(timerCounter).ToString();
            targetAmountText.text = "X" + (targetAmount - InventoryManager.instance.GetItemAmount(targetItem)).ToString();
            if (InventoryManager.instance.GetItemAmount(targetItem) >= targetAmount) isPlayerWin = true;
        }
        else
        {
            //SceneManager.LoadScene("MainMenu");
            loseCanvas.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            gameManagerCanvas.SetActive(false);
            Time.timeScale = 0;
        }
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void OpenInventoryPanel()
    {
        inventoryPanel.gameObject.SetActive(true);
        inventoryPanel.OnOpen();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }
    public void CloseInventoryPanel()
    {
        inventoryPanel.gameObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }
}
