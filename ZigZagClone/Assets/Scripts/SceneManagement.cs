using UnityEngine.SceneManagement;


public static class SceneManagement
{
    public static void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
