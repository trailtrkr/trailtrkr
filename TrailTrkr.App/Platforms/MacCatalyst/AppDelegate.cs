using Foundation;

namespace TrailTrkr.App
{
    [Register("AppDelegate")]
    public class AppDelegate : MauiUIApplicationDelegate
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }

    [Register("MauiUISceneDelegate")]
    public class SceneDelegate : MauiUISceneDelegate
    {
    }
}
