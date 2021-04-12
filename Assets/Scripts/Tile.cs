using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileManager tileManager;
    public TileManager.Owner owner;
    public SpriteRenderer spriteRenderer;
    public Sprite blankTile;
    public Sprite swordSprite;
    public Sprite shieldSprite;

    private void OnMouseUp()
    {
        // Check for current player that is claiming ownership of this space
        owner = tileManager.CurrentPlayer;

        // Set the sprite color to represent the owner (Sword = Blue, Shield = Red)
        if (owner == TileManager.Owner.Sword)
        {
            this.GetComponent<SpriteRenderer>().color = Color.blue;
            spriteRenderer.sprite = swordSprite;
        }
        else if (owner == TileManager.Owner.Shield)
        {
            this.GetComponent<SpriteRenderer>().color = Color.red;
            spriteRenderer.sprite = shieldSprite;
        }

        // Update to the next player in rotation
        tileManager.ChangePlayer();
    }

    public void ResetTileColor()
    {
        this.GetComponent<SpriteRenderer>().color = Color.white;
        spriteRenderer.sprite = blankTile;
    }
}
