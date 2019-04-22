using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PuzzlePiece : MonoBehaviour, IPointerClickHandler
{
    private Puzzle puzzle;
    private Image changeSprite;
    public GameObject nightmareManager;

    public void Start()
    {
        puzzle = GameObject.Find("Puzzle").GetComponent<Puzzle>();
    }

    //Compares if selected slot is near a empty slot and change positions
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Saved.player.puzzleComplete) return;
        var puzzlePieces = FindObjectsOfType<PuzzlePiece>();
        foreach (PuzzlePiece puzzlePiece in puzzlePieces)
        {
            
            int selectedSlotNumber = int.Parse(this.gameObject.name.ToString().Substring(this.gameObject.name.Length - 1));
            int loopSlotNumber = int.Parse(puzzlePiece.gameObject.name.ToString().Substring(puzzlePiece.gameObject.name.Length - 1));
            string loopSlotName = puzzlePiece.gameObject.GetComponent<Image>().sprite.name;

            if (loopSlotName == "empty_item8")
            {
                if (  (selectedSlotNumber == loopSlotNumber + 1 && (selectedSlotNumber != 2 || selectedSlotNumber != 5))
                    ||(selectedSlotNumber == loopSlotNumber - 1 && (selectedSlotNumber != 3 || selectedSlotNumber != 6))
                    || selectedSlotNumber == loopSlotNumber + 3 
                    || selectedSlotNumber == loopSlotNumber - 3)
                {
                    changeSprite = puzzlePiece.GetComponent<Image>();
                    ChangeSprites(GetComponent<Image>(), changeSprite);

                    /*string piece1 = gameObject.GetComponent<Image>().sprite.name;
                    string piece2 = changeSprite.sprite.name;
                    Saved.player.puzzlePieces[selectedSlotNumber] = 8;
                    Saved.player.puzzlePieces[loopSlotNumber] = int.Parse(piece1.Substring(piece1.Length-1, 1));*/
                    Save();
                }
            }
        }
        //if completed then show the key
        if (puzzle.CompletePuzzle())
        {
            //creates a copy of the object specified in "ClaimItem"
            //var claimItem = Instantiate(puzzle.ClaimItem, GameObject.Find("piece8").transform, false);
            //claimItem.transform.localScale = new Vector3(15, 15, 15);
            GameObject.Find("piece8").transform.Find("Container").gameObject.SetActive(true);
            Saved.player.puzzleComplete = true;

            Saved.triggers.nightmare = true;
            Saved.triggers.level = "easy";
            nightmareManager.SetActive(true);
            puzzle.gameObject.SetActive(false);


        }
    }

    void ChangeSprites(Image firstSprite, Image secondSprite)
    {
        Sprite temp = firstSprite.sprite;
        firstSprite.sprite = secondSprite.sprite;
        secondSprite.sprite = temp;
    }
    void Save()
    {
        var puzzlePieces = FindObjectsOfType<PuzzlePiece>();
        foreach (PuzzlePiece puzzlePiece in puzzlePieces)
        {
            int pieceNumber = int.Parse(puzzlePiece.gameObject.name.Substring(puzzlePiece.gameObject.name.Length - 1));
            string image_number = puzzlePiece.gameObject.GetComponent<Image>().sprite.name;
            Saved.player.puzzlePieces[pieceNumber] = int.Parse(image_number.Substring(image_number.Length - 1, 1));
        }
    }
}
