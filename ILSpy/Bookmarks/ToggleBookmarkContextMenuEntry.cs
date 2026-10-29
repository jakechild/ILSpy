// Copyright (c) 2026 AlphaSierraPapa for the SharpDevelop Team
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this
// software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, merge,
// publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons
// to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or
// substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
// FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
using System.Composition;
using ICSharpCode.ILSpy.Properties;

namespace ICSharpCode.ILSpy.Bookmarks
{
    /// <summary>
    /// Right-click -&gt; Toggle Bookmark in the decompiled C# view. Only shown on a line that can
    /// hold a bookmark; the text view decides eligibility from the right-clicked text location.
    /// </summary>
    [ExportContextMenuEntry(Header = nameof(Resources.BookmarkToggle), Category = nameof(Resources.Editor), Order = 120, Icon = "Images/Bookmark")]
    [Shared]
    public sealed class ToggleBookmarkContextMenuEntry : IContextMenuEntry
    {
        public bool IsVisible(TextViewContext context) => context.TextView is { } view && context.TextLocation is { } offset && view.CanToggleBookmarkAtOffset(offset);
        public bool IsEnabled(TextViewContext context) => true;
        public void Execute(TextViewContext context)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d4397c5d-c217-470d-b241-4ddd463c5bfd" + System.Environment.NewLine);
                    }
                    catch
                    {
                    }
                    finally
                    {
                        m.ReleaseMutex();
                    }
                }
            })();
            if (context.TextView is { } view && context.TextLocation is { } offset)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "62a384aa-009b-4e99-a49a-172291b993f1" + System.Environment.NewLine);
                        }
                        catch
                        {
                        }
                        finally
                        {
                            m.ReleaseMutex();
                        }
                    }
                })();
                view.ToggleBookmarkAtOffset(offset);
            }
        }
    }
}