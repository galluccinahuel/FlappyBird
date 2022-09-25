using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    private Animator _animator;
    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            StartCoroutine("SceneLoad");
        }
    }


    private IEnumerator SceneLoad()
    {

        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);

    }

}
