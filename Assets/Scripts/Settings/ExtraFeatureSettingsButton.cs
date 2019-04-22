
public class ExtraFeatureSettingsButton : FButton
{
    private void Start()
    {
        ToggleButton(!Saved.triggers.newgame, gameObject);
    }

    public override void OnClick(string scene)
    {
        Saved.triggers.extraFeatureBack = true;
        base.OnClick(scene);
    }
}
