using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    [SerializeField] private Tilemap interactableMap;
    
    [SerializeField] private Tilemap plantingMap;
    [SerializeField] private Tilemap groundMap;

    // Interactive Tiles
    [SerializeField] private Tile hiddenInteractableTile;
    [SerializeField] private Tile interactedTile;
    [SerializeField] private Tile highlightTile;
    [SerializeField] private Tile defaultGroundTile;

    // Potato Tiles
    [SerializeField] private Tile firstStagePotatoTile;
    [SerializeField] private Tile secondStagePotatoTile;
    [SerializeField] private Tile thirdStagePotatoTile;
    [SerializeField] private Tile lastStagePotatoTile;

    private Vector3Int prevPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Loop through our tilemap, and cellbounds is the boundaries of the tilemap in cell size.
        // allPositionsWithin returns all the position within the bounds of the tilemap
        foreach (var position in interactableMap.cellBounds.allPositionsWithin)
        {
            
            TileBase tile = interactableMap.GetTile(position);

            if(tile != null && tile.name == "Interactable_Visible"){
                // Set the tiles at each position to be the hiddenInteractableTile
                interactableMap.SetTile(position, hiddenInteractableTile);
            }

        }
    }

    // Check if tile is interactable
    public bool IsInteractable(Vector3Int position)
    {
        // Get the tile in a specific position
        TileBase tile = interactableMap.GetTile(position);

        if(tile != null)
        {
            if(tile.name == "Interactable"){
                return true;
            }
        }

        return false;
    }

    public bool IsPlowed(Vector3Int position)
    {
        TileBase tile = interactableMap.GetTile(position);

        if(tile != null)
        {
            if(tile.name == "Summer_Plowed")
            {
                return true;
            }
        }

        return false;
    }

    public void SetInteracted(Vector3Int position)
    {
        interactableMap.SetTile(position, interactedTile);
    }

    public void PlantPotato(Vector3Int position)
    {
        plantingMap.SetTile(position, firstStagePotatoTile);
    }
    public void GrowPotatoToLastStage(Vector3Int position)
    {
        plantingMap.SetTile(position, lastStagePotatoTile);   
    }

    public void GrowPotatoToThirdStage(Vector3Int position)
    {
        plantingMap.SetTile(position, thirdStagePotatoTile);   
    }

    public void GrowPotatoToSecondStage(Vector3Int position)
    {
        plantingMap.SetTile(position, secondStagePotatoTile);   
    }

    public void HighlightInteractiveTile(Vector3Int position)
    {
        // When positioned on a tile, set tile to a new highlihted tile

        // When player has moved away from tile, remove tile from old position
        if(position.x != prevPosition.x || position.y != prevPosition.y)
        {
            TileBase oldTile = interactableMap.GetTile(prevPosition);

            // Check if the tile on the previous position is null or Interactable
            if(oldTile != null && oldTile.name == "Interactable")
            {
                groundMap.SetTile(prevPosition, defaultGroundTile);
            }
        }

        // Highlight the tile the player is positioned on

        // Get the tile in a specific position
        TileBase tile = interactableMap.GetTile(position);

        if(tile != null && tile.name == "Interactable")
        {
            groundMap.SetTile(position, highlightTile);
        }

        prevPosition = position;
    }


}
