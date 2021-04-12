using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TileManager : MonoBehaviour
{
    public Owner CurrentPlayer;
    public Tile[] Tiles = new Tile[9];
    public TextMeshProUGUI swordScore;
    public TextMeshProUGUI shieldScore;
    public ButtonController buttonController;

    public enum Owner
    {
        None,
        Sword,
        Shield
    }

    private bool won;

    // Start is called before the first frame update
    void Start()
    {
        won = false;
        CurrentPlayer = Owner.Sword;
        buttonController.HideButtons();
    }

    public void ChangePlayer()
    {
        if (CheckForWinner())
            return;

        if (CurrentPlayer == Owner.Sword)
            CurrentPlayer = Owner.Shield;
        else
            CurrentPlayer = Owner.Sword;
    }

    public bool CheckForWinner()
    {
        if (Tiles[0].owner == CurrentPlayer && Tiles[1].owner == CurrentPlayer && Tiles[2].owner == CurrentPlayer)
            won = true;
        else if (Tiles[0].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;
        else if (Tiles[0].owner == CurrentPlayer && Tiles[3].owner == CurrentPlayer && Tiles[6].owner == CurrentPlayer)
            won = true;
        else if (Tiles[2].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[6].owner == CurrentPlayer)
            won = true;
        else if (Tiles[2].owner == CurrentPlayer && Tiles[5].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;
        else if (Tiles[6].owner == CurrentPlayer && Tiles[7].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;
        else if (Tiles[1].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[7].owner == CurrentPlayer)
            won = true;
        else if (Tiles[3].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[5].owner == CurrentPlayer)
            won = true;

        if (won)
        {
            Debug.Log("Winner: " + CurrentPlayer);
            UpdateScore();
            buttonController.ShowButtons();
            return true;
        }

        return false;
    }

    private void UpdateScore()
    {
        if (CurrentPlayer == Owner.Sword)
        {
            swordScore.GetComponent<SwordScoreScript>().score += 1;
            swordScore.GetComponent<SwordScoreScript>().UpdateScore();
        }
        else if (CurrentPlayer == Owner.Shield)
        {
            shieldScore.GetComponent<ShieldScoreScript>().score += 1;
            shieldScore.GetComponent<ShieldScoreScript>().UpdateScore();
        }
    }

    public void ResetOrQuit(bool cont)
    {
        if (cont)
        {
            Reset();
        }
        else
        {
            Application.Quit();
            Debug.Log("Quitting");
        }
    }

    private void Reset()
    {
        for (int i = 0; i < Tiles.Length; ++i)
        {
            Tiles[i].owner = Owner.None;
            Tiles[i].ResetTileColor();
        }
        Start();
    }
}
