using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Port : Stareable
{
    [SerializeField]
    private string switchSceneName;

    [SerializeField]
    private LoadSceneMode mode;

    public override void BeginStare()
    {
        SceneManager.LoadScene(switchSceneName, mode);
    }

    public override void EndStare()
    {
    }
}
