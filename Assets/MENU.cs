using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectorButton : MonoBehaviour
{
    public Button LevelSelectButton;
    public int Index;

    private void Awake()
    {
        LevelSelectButton.onClick.AddListener(LoadLevel);
    }

    private void OnDestroy()
    {
        LevelSelectButton.onClick.RemoveAllListeners();
    }

    private void LoadLevel()
    {
        SceneManager.LoadScene(Index);
    }
}