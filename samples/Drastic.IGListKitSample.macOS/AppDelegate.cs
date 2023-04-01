namespace Drastic.IGListKitSample.macOS;

[Register ("AppDelegate")]
public class AppDelegate : NSApplicationDelegate {

    private MainWindowController? mainWindowController;

    public override void DidFinishLaunching (NSNotification notification)
	{
        this.mainWindowController = new MainWindowController();
        this.mainWindowController.Window.MakeKeyAndOrderFront(this);
    }

	public override void WillTerminate (NSNotification notification)
	{
		// Insert code here to tear down your application
	}
}

public class UserViewController : NSViewController
{
    public UserViewController()
    {
        this.View = new NSView(new CGRect(0, 0, 1000, 500));

        this.LoadSampleUsers();
    }

    public List<User> Users { get; set; } = new List<User>();

    private void LoadSampleUsers()
    {
        var path = Path.Combine(NSBundle.MainBundle.BundlePath, "Contents", "Resources", "Data");
        NSUrl file = new NSUrl(Path.Combine(path, "users.json"));

        try
        {
            UsersProvider provider = new UsersProvider(file);
            Users = provider.Users;
        }
        catch (Exception ex)
        {
            new NSAlert
            {
                AlertStyle = NSAlertStyle.Critical,
                MessageText = ex.Message
            }.RunModal();
        }
    }

    public override void AwakeFromNib()
    {
        base.AwakeFromNib();
    }
}

public class MainWindow : NSWindow
{
    private NSViewController? controller;

    public MainWindow(CGRect contentRect, NSWindowStyle aStyle, NSBackingStore bufferingType, bool deferCreation) : base(contentRect, aStyle, bufferingType, deferCreation)
    {
        this.controller = new UserViewController();
        this.ContentViewController = this.controller;
    }
}

public class MainWindowController : NSWindowController
{
    public MainWindowController() : base()
    {
        // Construct the window from code here
        CGRect contentRect = new CGRect(0, 0, 1000, 500);
        base.Window = new MainWindow(contentRect, (NSWindowStyle.Titled | NSWindowStyle.Closable | NSWindowStyle.Miniaturizable | NSWindowStyle.Resizable), NSBackingStore.Buffered, false);


        // Simulate Awaking from Nib
        Window.AwakeFromNib();
    }

    public new MainWindow Window
    {
        get { return (MainWindow)base.Window; }
    }
}
