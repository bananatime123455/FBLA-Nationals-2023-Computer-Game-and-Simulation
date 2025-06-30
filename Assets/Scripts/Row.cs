using UnityEngine;

public class Row : MonoBehaviour
{
    //initallize an array of tile called tiles
    public Tile[] tiles { get; private set; }

    //word on the row
    public string word 
    {
        get 
        {
            string word = "";

            for (int i = 0; i < tiles.Length; i++) 
            {
                word += tiles[i].letter;
            }
            return word;
        }
    }


    private void Awake()
    {
        //Fills array called tiles with Tiles
        tiles = GetComponentsInChildren<Tile>();
    }
}
