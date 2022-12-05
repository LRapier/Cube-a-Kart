using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerMovement movement;

    void OnTriggerEnter()
    {
        movement.enabled = false;
        gameManager.CompleteLevel();
        Invoke("LoadNextLevel", 2);
    }
    void LoadNextLevel ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
