using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    public GameObject menu;
    private bool _paused;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(_paused);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetPaused(!_paused);
        }
    }

    private void SetPaused(bool state)
    {
        _paused = state;
        if (_paused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        menu.SetActive(_paused);
    }

    public void Resume()
    {
        SetPaused(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Resume();
    }
}
