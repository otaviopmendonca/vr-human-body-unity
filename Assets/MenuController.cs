using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void LoadSkeleton()
    {
        SceneManager.LoadScene("SkeletonScene");
    }

    public void LoadOrgans()
    {
        SceneManager.LoadScene("OrganScene");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}