using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttmanager : MonoBehaviour
{
    // Buka Main Menu
    public void BukaMainmenu()
    {
        SceneManager.LoadScene("Mainmenu");
    }

    // Buka Settings
    public void Bukasettings()
    {
        SceneManager.LoadScene("settings");
    }

    // Buka Gameplay
    public void BukaGameplay()
    {
        SceneManager.LoadScene("Gameplay");
    }

    // Exit Game
    public void GoToExit()
    {
        Debug.Log("BERHASIL KELUAR APLIKASI");

        // Menutup game
        Application.Quit();

        // Khusus untuk testing di Unity Editor
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}