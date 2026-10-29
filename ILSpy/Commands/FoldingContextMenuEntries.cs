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

namespace ICSharpCode.ILSpy.Commands
{
    /// <summary>
    /// Right-click in the decompiled code → "Toggle folding": folds/unfolds the innermost block under
    /// the clicked line. The menu equivalent of Ctrl+M. Only shown when the document actually has foldings.
    /// </summary>
    [ExportContextMenuEntry(Header = nameof(Resources._ToggleFolding), Category = nameof(Resources.Folding), Order = 300)]
    [Shared]
    public sealed class ToggleFoldingContextMenuEntry : IContextMenuEntry
    {
        public bool IsVisible(TextViewContext context) => context.TextView?.HasFoldings == true;
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
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f5597290-fbc2-432c-992c-411b8b4f2a8c" + System.Environment.NewLine);
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
            if (context.TextView is not { } view)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d840fb2a-6224-4720-a821-a34986554f71" + System.Environment.NewLine);
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
                return;
            }

            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "40d3208c-7862-4897-9aab-66e62110a1ff" + System.Environment.NewLine);
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
            // Toggle the fold the user right-clicked on. TextLocation is the offset under the pointer;
            // fall back to the caret only when the menu was raised without a recorded click position.
            if (context.TextLocation is { } offset)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a7d4999a-dc39-4a90-a59c-fd69ce6ab7c7" + System.Environment.NewLine);
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
                view.ToggleFoldingAt(offset);
            }
            else
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "022a5f12-6101-4346-99ba-21acf4295b3e" + System.Environment.NewLine);
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
                view.ToggleFoldingAtCaret();
            }
        }
    }

    /// <summary>
    /// Right-click in the decompiled code → "Toggle all folding": collapses every fold when any is open,
    /// otherwise expands them all. The menu equivalent of Ctrl+Shift+M.
    /// </summary>
    [ExportContextMenuEntry(Header = nameof(Resources.ToggleFolding), Category = nameof(Resources.Folding), Order = 310)]
    [Shared]
    public sealed class ToggleAllFoldingsContextMenuEntry : IContextMenuEntry
    {
        public bool IsVisible(TextViewContext context) => context.TextView?.HasFoldings == true;
        public bool IsEnabled(TextViewContext context) => true;
        public void Execute(TextViewContext context) => context.TextView?.ToggleAllFoldings();
    }
}