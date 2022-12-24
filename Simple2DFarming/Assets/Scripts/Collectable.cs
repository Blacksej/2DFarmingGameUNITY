using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Item))]
public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        // Player walks into collectable
        PlayerController player = other.GetComponent<PlayerController>();

        if(player){
            Item item = GetComponent<Item>();

            if(item != null)
            {
                // Add collectable to player
                player.inventory.Add("Backpack", item);
                
                // Delete collectable from the scene
                Destroy(this.gameObject);
            }
        }
    }
}
