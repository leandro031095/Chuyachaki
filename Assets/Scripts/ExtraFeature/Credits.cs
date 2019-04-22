public class Credits : FButton
{
    public override void OnClick(string scene)
    {
        Saved.triggers.extraCounter = 10;
        base.OnClick(scene);
    }
}
