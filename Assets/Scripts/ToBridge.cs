using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToBridge : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(toBridge());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator toBridge()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Bridge");
    }
}
