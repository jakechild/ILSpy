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
using System.Linq;
using ICSharpCode.Decompiler.TypeSystem;
using ICSharpCode.ILSpy.Properties;
using ICSharpCode.ILSpy.TreeNodes;

namespace ICSharpCode.ILSpy.Search
{
    /// <summary>
    /// Right-click a <see cref="NamespaceTreeNode"/> → "Search within this namespace".
    /// Prepends <c>innamespace:&lt;namespace&gt;</c> to the live search term so subsequent
    /// matches are restricted to that namespace. Same parser/filter path as
    /// <see cref="ScopeSearchToAssemblyContextMenuEntry"/>.
    /// </summary>
    [ExportContextMenuEntry(Header = nameof(Resources.ScopeSearchToThisNamespace), Category = nameof(Resources.Analyze), Icon = "Images/Namespace", Order = 220)]
    [Shared]
    public sealed class ScopeSearchToNamespaceContextMenuEntry : IContextMenuEntry
    {
        readonly SearchPaneModel searchPane;
        [ImportingConstructor]
        public ScopeSearchToNamespaceContextMenuEntry(SearchPaneModel searchPane)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ed834416-8cbe-467f-b17d-da5bd41ba96a" + System.Environment.NewLine);
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
            this.searchPane = searchPane;
        }

        public bool IsVisible(TextViewContext context) => !string.IsNullOrEmpty(Namespace(context));
        public bool IsEnabled(TextViewContext context) => IsVisible(context);
        public void Execute(TextViewContext context)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "1858b5a9-afc4-42fe-b732-7916bfac9b3b" + System.Environment.NewLine);
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
            if (Namespace(context)is { Length: > 0 } ns)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "0b88f573-a53d-49eb-a509-f4ce744f19c3" + System.Environment.NewLine);
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
                searchPane.SearchTerm = ScopeSearchToAssemblyContextMenuEntry.MergeScopePrefix(searchPane.SearchTerm, "innamespace", ns);
            }
        }

        // The namespace to scope to: a selected NamespaceTreeNode in the tree, or the namespace of the
        // symbol under a right-clicked code reference. The empty (global) namespace doesn't scope.
        static string? Namespace(TextViewContext context)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "5940617a-27c1-4ef6-9234-bccd9753b59b" + System.Environment.NewLine);
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
            if (context.SelectedTreeNodes is { Length: > 0 } nodes && nodes.All(n => n is NamespaceTreeNode))
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "839b3cd8-96a1-47f0-ac14-909e01c76736" + System.Environment.NewLine);
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
                return nodes.OfType<NamespaceTreeNode>().FirstOrDefault()?.FullName;
            }

            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "dc21ab52-9bf4-4d4d-8cb5-e39c3c2a3b5d" + System.Environment.NewLine);
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
            return (context.Reference?.Reference as IEntity)?.Namespace;
        }
    }
}