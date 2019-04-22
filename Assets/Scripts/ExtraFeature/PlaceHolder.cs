
public class PlaceHolder : FButton
{
    
    private void Start()
    {
        int number = int.Parse(gameObject.name.Substring(gameObject.name.Length - 1, 1));
        if (Saved.extra.extraTexts[number])
        {
            ChildText("Extra "+ number);
        }
        else
        {
            ChildText("?");
        }
         //Para cambiar el texto del boton
    }

    public override void OnClick(string scene)
    {
        int number = int.Parse(gameObject.name.Substring(gameObject.name.Length - 1, 1));
        if (Saved.extra.extraTexts[number])
        {
            Saved.triggers.extraCounter = int.Parse(gameObject.name.Substring(gameObject.name.Length - 1, 1));
            base.OnClick(scene);
        }   
    }
}
