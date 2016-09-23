using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public static class GameState{

    //Should be populated from a file whenever game starts

    public static int currentLevel{set;get;}

    public static int currentScore{set;get;}


    //Loads next level
    public static void loadNextLevel()
    {
        int nextLevel = currentLevel + 1;
        if (SceneManager.sceneCountInBuildSettings > nextLevel)
        {
            SceneManager.LoadScene(nextLevel);
            currentLevel++;
        }
    }

    public static void resetLevel()
    {
        SceneManager.LoadScene(currentLevel);
    }

}
