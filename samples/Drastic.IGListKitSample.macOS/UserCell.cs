using AppKit;
using CoreGraphics;

namespace Drastic.IGListKitSample.macOS
{
    public class UserCell : NSView
    {
        private readonly NSTextField textField = new NSTextField();
        private readonly NSButton button = new NSButton();
        private readonly NSView viewContentView = new NSView();

        public UserCell()
        {
            SetupUI();
            SetupLayout();
        }

        public override CGRect Frame
        {
            get => base.Frame;
            set
            {
                base.Frame = value;
                SetupLayout();
            }
        }

        private void SetupUI()
        {
            AddSubview(viewContentView);

            AutoresizingMask = NSViewResizingMask.MaxXMargin | NSViewResizingMask.MinYMargin;
            Frame = new CGRect(x: 0, y: 0, width: 480, height: 47);

            viewContentView.AddSubview(textField);
            viewContentView.AddSubview(button);

            viewContentView.TranslatesAutoresizingMaskIntoConstraints = false;

            button.SetContentHuggingPriorityForOrientation((float)NSLayoutPriority.DefaultHigh, NSLayoutConstraintOrientation.Vertical);
            button.TranslatesAutoresizingMaskIntoConstraints = false;
            button.Alignment = NSTextAlignment.Center;
            button.BezelStyle = NSBezelStyle.Rounded;
            button.Font = NSFont.SystemFontOfSize(13);
            button.ImageScaling = NSImageScale.ProportionallyDown;
            button.Title = "Delete";
            (button.Cell as NSButtonCell).Bordered = true;
            button.Target = null;
            button.Action = new ObjCRuntime.Selector("deleteButtonClicked:");

            textField.SetContentHuggingPriorityForOrientation((float)NSLayoutPriority.DefaultHigh, NSLayoutConstraintOrientation.Vertical);
            textField.SetContentHuggingPriorityForOrientation(251, NSLayoutConstraintOrientation.Horizontal);
            textField.TranslatesAutoresizingMaskIntoConstraints = false;
            textField.BackgroundColor = NSColor.Control;
            textField.Font = NSFont.SystemFontOfSize(13);
            textField.LineBreakMode = NSLineBreakMode.Clipping;
            textField.StringValue = "User Name";
            textField.TextColor = NSColor.Label;
            (textField.Cell as NSTextFieldCell)!.Scrollable = true;
            (textField.Cell as NSTextFieldCell)!.SetSendsActionOnEndEditing(true);
        }

        private void SetupLayout()
        {
            viewContentView.LeadingAnchor.ConstraintEqualTo(LeadingAnchor, 5).Active = true;
            viewContentView.TopAnchor.ConstraintEqualTo(TopAnchor, 5).Active = true;
            BottomAnchor.ConstraintEqualTo(viewContentView.BottomAnchor, 5).Active = true;
            TrailingAnchor.ConstraintEqualTo(viewContentView.TrailingAnchor, 5).Active = true;

            viewContentView.BottomAnchor.ConstraintEqualTo(button.BottomAnchor, 8).Active = true;
            textField.LeadingAnchor.ConstraintEqualTo(viewContentView.LeadingAnchor, 10).Active = true;
            viewContentView.TrailingAnchor.ConstraintEqualTo(button.TrailingAnchor, 15).Active = true;
            button.CenterYAnchor.ConstraintEqualTo(viewContentView.CenterYAnchor).Active = true;
            textField.FirstBaselineAnchor.ConstraintEqualTo(button.FirstBaselineAnchor).Active = true;
            viewContentView.TrailingAnchor.ConstraintEqualTo(textField.TrailingAnchor, 10).Active = true;
            button.TopAnchor.ConstraintEqualTo(viewContentView.TopAnchor, 8).Active = true;
        }
    }
}

