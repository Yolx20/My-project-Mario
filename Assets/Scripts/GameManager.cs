using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int puntuacion=0;
    private float time = 0;
    // Start is called before the first frame update

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        time += Time.deltaTime;
    }

    public float GetPunt()
    {
        return puntuacion;
    }

    public float GetTime()
    {
        return time;
    }

    public void AddPunt(int value)
    {
        puntuacion += value;
    }

    public void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
        AudioManager.instance.ClearAudioList();
    }
}
