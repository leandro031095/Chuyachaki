using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[System.Serializable]
public class PickedItems
{
    public string DisplaySprite;
    public string DisplayImage;
    public string CombinationItem;
    
    public enum property { usable, displayable, used };
    public property itemProperty { get; set; }

    public int intProperty;

    public void SaveItem(string displaySprite, string displayImage, string combinationItem, int idProperty)
    {
        DisplaySprite = displaySprite;
        DisplayImage = displayImage;
        CombinationItem = combinationItem;
        itemProperty = (property)idProperty;
        intProperty = idProperty;

        Saved.player.PickedItems.Add(this);
        Saved.Save<PlayerData>(Saved.player);
    }
    /*public void UsedItem()
    {
        itemProperty = (property)2;
        intProperty = 2;
    }*/
}
