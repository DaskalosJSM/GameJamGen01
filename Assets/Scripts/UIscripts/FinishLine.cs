using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] GameObject menuVictoria;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Time.timeScale = 0f;
            menuVictoria.SetActive(true);
        }
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("PrincipalMenu");
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
