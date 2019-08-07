using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class QuitorReplay : MonoBehaviour
{
    public GameObject RequireLabe;
    public Character Character;
    private void Update()
    {
        if (Character.State == PlayerState.Dead)
        {
            RequireLabe.SetActive(true);
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Replay()
    {
        SceneManager.LoadScene(1);
    }
}
