using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    [SerializeField] GameOverFunction onGameOver;

    [SerializeField] private List<PlayerMovement> allPlayerCubes = new List<PlayerMovement>();

    private void Start()
    {
        allPlayerCubes.AddRange(FindObjectsOfType<PlayerMovement>());
    }

    public void RemovePlayerFromList(PlayerRemoval removal)
    {
        allPlayerCubes.Remove(removal.player);
        Destroy(removal.player.gameObject);

        if (removal.isWinner) CheckIfLevelComplete();

        // Player Lost on a Hazard
        else StartCoroutine(RestartLevel());
    }

    private void CheckIfLevelComplete()
    {
        // Challenge 5:  
        if (allPlayerCubes.Count == 0) 
        {
            onGameOver.Raise(true);
        }
    }

    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
