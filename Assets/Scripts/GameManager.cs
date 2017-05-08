using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public enum GameStatus
{
    Finish,
    GamePlay
}

public class GameManager : MonoBehaviour {


    private static GameManager _instance;

    public GameStatus gameStatus;

    public GameObject mainCamera;

    public Text winText;

    public static GameManager Instance{
        get{
            if (_instance == null){
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    public List<Player> playersInGame = new List<Player>();
    [SerializeField]
    private int playersInGameLife;
    public GameObject FinalPanel, GamePlayPanel;

    private void Awake()
    {
        Time.timeScale = 1;
        gameStatus = GameStatus.GamePlay;
        GamePlayPanel.SetActive(true);
        FinalPanel.SetActive(false);
        playersInGameLife = playersInGame.Count;

    }

    private void Update()
    {
        if (gameStatus == GameStatus.Finish)
        {
            GameEndStatus();
        }

    }

    private void GameEndStatus()
    {
        Time.timeScale = 0;
        if (Input.anyKeyDown){
            SceneManager.LoadScene("Menu");
        }
    }

    private void VerifyEndGame(){
        foreach(Player p in playersInGame)
        {
            if (p.isDie){
                Debug.Log(p.name + " morreu");
                playersInGame.Remove(p);
            }
        }

        if(playersInGame.Count <= 1){
            EndGame(playersInGame[0]);
        }
    }

    public void Die(int index)
    {
        playersInGameLife--;
        VerifyEndGame();
    }

    private void EndGame(Player win)
    {

        gameStatus = GameStatus.Finish;
        FinalPanel.SetActive(true);
        string winString = "Player " + win.indx + " Win";
        Debug.Log("O vencedor foi >>> " + win.name);
        winText.text = winString;

        
    }

}
