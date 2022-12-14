using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableType type;
    public Sprite icon;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        // Player walks into collectable
        PlayerController player = other.GetComponent<PlayerController>();

        if(player){
            // Add collectable to player
            player.inventory.Add(this);

            // Delete collectable from the scene
            Destroy(this.gameObject);
        }
    }
}

public enum CollectableType
{
    NONE, TOMATO_SEED
}
