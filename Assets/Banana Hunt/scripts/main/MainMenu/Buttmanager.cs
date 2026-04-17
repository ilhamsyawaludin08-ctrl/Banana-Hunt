using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttmanager : MonoBehaviour
{
    public void BukaMainmenu()
    {
        SceneManager.LoadScene("Mainmenu");

    }

    public void Bukasettings()
    {
        SceneManager.LoadScene("settings");

    }

    public void GoToExit()
    {
        Debug.Log ("BERHASIL KELUAR APLIKASI");
        Application.Quit ();
    }

}
