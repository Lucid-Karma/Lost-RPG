using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(DelaySceneTransation());
        }
    }
    IEnumerator DelaySceneTransation()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
    }
}
