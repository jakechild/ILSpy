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
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input.Platform;
using ICSharpCode.ILSpy.Properties;
using ICSharpCode.ILSpy.TreeNodes;

namespace ICSharpCode.ILSpy.Commands
{
    /// <summary>
    /// Right-click → "Copy fully qualified name". Visible whenever the selection is exactly
    /// one tree node that wraps a TypeSystem entity (Type/Method/Field/Property/Event).
    /// Copies the entity's <see cref="ICSharpCode.Decompiler.TypeSystem.IEntity.ReflectionName"/>
    /// — the language-independent identifier used by FindNodeByPath etc. — to the clipboard.
    /// </summary>
    [ExportContextMenuEntry(Header = nameof(Resources.CopyName), Category = "Edit", Icon = "Images/Copy", Order = 600)]
    [Shared]
    public sealed class CopyFullyQualifiedNameContextMenuEntry : IContextMenuEntry
    {
        public bool IsVisible(TextViewContext context) => GetMemberNodeFromContext(context) != null;
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
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "7c98fec7-8306-4852-a33e-990b71e256fc" + System.Environment.NewLine);
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
            var text = GetTextToCopy(context);
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d12f929a-4067-4182-afca-743b9f0b349b" + System.Environment.NewLine);
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
            if (text == null)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "222df7c6-6e24-4caf-b487-81d55e503fcf" + System.Environment.NewLine);
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
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "bfd5b7f7-4ae9-44a3-b419-539a65f1cbd7" + System.Environment.NewLine);
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
            // The clipboard is owned by the TopLevel that hosts the source visual; for the
            // assembly tree that's the main window. SetTextAsync runs on the UI thread and we
            // don't await — the menu item already returned by then.
            var topLevel = context.OriginalSource is Visual src ? TopLevel.GetTopLevel(src) : context.TreeGrid is { } grid ? TopLevel.GetTopLevel(grid) : null;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "6f65fb06-3e5b-4e60-9843-91fd7217cb33" + System.Environment.NewLine);
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
            topLevel?.Clipboard?.SetTextAsync(text);
        }

        /// <summary>Public for testing: returns the text the entry would write to the clipboard
        /// for the given context, or <see langword="null"/> when the entry isn't applicable.</summary>
        public string? GetTextToCopy(TextViewContext context) => GetMemberNodeFromContext(context)?.Member?.ReflectionName;
        static IMemberTreeNode? GetMemberNodeFromContext(TextViewContext context) => context.SelectedTreeNodes is { Length: 1 } nodes ? nodes[0] as IMemberTreeNode : null;
    }
}