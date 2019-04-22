using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    public GameObject ClaimItem;
    private GameObject displayImage;
    public GameObject nightmareManager;
    Sprite newSprite;

    void Start()
    {
        displayImage = GameObject.Find("displayImage");
        showCompletePuzzle();
        
    }

    void Update()
    {
        HideDisplay();
    }

    void HideDisplay()
    {
        //Touch
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (!EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                this.gameObject.SetActive(false);
            }
        }
        //Click
        else if (Input.GetMouseButtonDown(0))
        {
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                this.gameObject.SetActive(false);
            }
        }

        if (displayImage.GetComponent<DisplayImage>().CurrentState == DisplayImage.State.normal)
        {
            //this.gameObject.SetActive(false);
        }
    }

    //check if puzzle is completed
    public bool CompletePuzzle()
    {
        if (Saved.player.puzzleComplete== true) return true;
        var puzzlePieces = FindObjectsOfType<PuzzlePiece>();
        Saved.player.puzzleComplete = true;
        foreach (PuzzlePiece puzzlePiece in puzzlePieces)
        {
            int pieceNumber = int.Parse(puzzlePiece.gameObject.name.ToString().Substring(puzzlePiece.gameObject.name.Length - 1));
            int imageNumber = int.Parse(puzzlePiece.gameObject.GetComponent<Image>().sprite.name.ToString().
                Substring(puzzlePiece.gameObject.GetComponent<Image>().sprite.name.Length - 1));

            if(!(pieceNumber == imageNumber))
            {
                //IsCompleted = false;
                Saved.player.puzzleComplete = false;
            }
        }
        return Saved.player.puzzleComplete;
    }
    public void showCompletePuzzle()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/wall4/sachamama");
        var puzzlePieces = FindObjectsOfType<PuzzlePiece>();
        if (Saved.player.puzzleComplete)
        {
            foreach (PuzzlePiece puzzlePiece in puzzlePieces)
            {
                int pieceNumber = int.Parse(puzzlePiece.gameObject.name.ToString().Substring(puzzlePiece.gameObject.name.Length - 1));
                if (pieceNumber != 8)
                {
                    puzzlePiece.gameObject.GetComponent<Image>().sprite = sprites[pieceNumber];
                }
                else
                {
                    puzzlePiece.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Inventory Items/empty_item8");
                }
            }
            gameObject.transform.Find("piece8").transform.Find("Container").gameObject.SetActive(true);
        }
        else
        {
            //showSavedPuzzle
            //var puzzlePieces = FindObjectsOfType<PuzzlePiece>();
            //int i = 0;
            foreach (PuzzlePiece puzzlePiece in puzzlePieces)
            {
                //if (i != 8)
                //{
                    //Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/wall4/sachamama");
                    int pieceNumber = int.Parse(puzzlePiece.gameObject.name.Substring(puzzlePiece.gameObject.name.Length - 1));
                if (Saved.player.puzzlePieces[pieceNumber] != 8)
                {
                    puzzlePiece.gameObject.GetComponent<Image>().sprite = sprites[Saved.player.puzzlePieces[pieceNumber]];
                }
                else
                {
                    puzzlePiece.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Inventory Items/empty_item8");
                }
                //}
                //i++;
            }
        }
    }
    public void showSavedPuzzle()
    {
        if (!Saved.player.puzzleComplete)
        {
            var puzzlePieces = FindObjectsOfType<PuzzlePiece>();
            int i = 0;
            foreach (PuzzlePiece puzzlePiece in puzzlePieces)
            {
                if (i != 8)
                {
                    Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/wall4/sachamama");
                    int pieceNumber = int.Parse(puzzlePiece.gameObject.name.Substring(puzzlePiece.gameObject.name.Length - 1));
                    puzzlePiece.gameObject.GetComponent<Image>().sprite = sprites[Saved.player.puzzlePieces[pieceNumber]];
                }
                else
                {
                    puzzlePiece.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("Inventory Items/empty_item8");
                }
                i++;
            }
        }

        /*
        Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/wall4/sachamama");
        int savedPiece = Saved.player.puzzlePieces[int.Parse(gameObject.name.Substring(gameObject.name.Length - 1, 1))];
        gameObject.GetComponent<Image>().sprite = sprites[savedPiece];*/
    }
}
