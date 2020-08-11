using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadNextLevelOnCollision : MonoBehaviour
{

    #region Variables

    [SerializeField]
    string NextLevel = null;
    [SerializeField]
    float TimeBeforeNextLevel = 0.7f;
    [SerializeField]
    string TagCollidedObject = "Goal";

    #endregion

    #region Main


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(gameObject + "       Hit      " + collision.gameObject);

        if (collision.collider.CompareTag(TagCollidedObject))
        {
            LoadNextLevel();
        }

    }

    public void LoadNextLevel()
    {

        Invoke("LoadNextLevelFunction", TimeBeforeNextLevel);

    }

    public void LoadNextLevelFunction()
    {
        SceneManager.LoadScene(NextLevel);
    }

    #endregion


}
