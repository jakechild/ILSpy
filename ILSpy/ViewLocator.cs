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
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Dock.Model.Core;
using ICSharpCode.ILSpy.Analyzers;
using ICSharpCode.ILSpy.AssemblyTree;
using ICSharpCode.ILSpy.Bookmarks;
using ICSharpCode.ILSpy.Compare;
using ICSharpCode.ILSpy.Options;
using ICSharpCode.ILSpy.Search;
using ICSharpCode.ILSpy.TextView;
using ICSharpCode.ILSpy.ViewModels;
using ICSharpCode.ILSpy.Views;

namespace ICSharpCode.ILSpy
{
    /// <summary>
    /// Single application-wide IDataTemplate that resolves a view-model to its view. Two
    /// resolution paths:
    ///   1. Explicit <see cref="s_views"/> map (Dock-hosted view-models). Dispatched via
    ///      a parameter-less ctor delegate — equivalent to MvvmSample's compile-time
    ///      <c>[StaticViewLocator]</c>-generated dictionary.
    ///   2. Convention fallback for any <see cref="ViewModelBase"/>-derived viewmodel:
    ///      <c>SomeViewModel</c> → <c>SomeView</c> resolved via <see cref="Type.GetType(string)"/>.
    ///
    /// <para>
    /// One locator instance handles every <see cref="IDockable"/> (and any
    /// <see cref="ViewModelBase"/>) rather than N typed
    /// <c>&lt;DataTemplate DataType="..."/&gt;</c> blocks in App.axaml: the owned-view
    /// resolver (<c>DockableViewRecycling</c>) builds each dockable's view through this map
    /// once, and a single shared template keeps view resolution uniform across the dock
    /// chrome. Mirrors <c>samples/DockMvvmSample</c>'s StaticViewLocator shape.
    /// </para>
    /// </summary>
    [RequiresUnreferencedCode("Convention fallback uses reflection (Type.GetType) which may be trimmed.", Url = "https://docs.avaloniaui.net/docs/concepts/view-locator")]
    public class ViewLocator : IDataTemplate
    {
        static readonly Dictionary<Type, Func<Control>> s_views = new()
        {
            {
                typeof(AssemblyTreeModel),
                () => new AssemblyListPane()
            },
            {
                typeof(SearchPaneModel),
                () => new SearchPane()
            },
            {
                typeof(BookmarksPaneModel),
                () => new BookmarksPane()
            },
            {
                typeof(AnalyzerTreeViewModel),
                () => new AnalyzerTreeView()
            },
            {
                typeof(ContentTabPage),
                () => new ContentTabPageView()
            },
            {
                typeof(DecompilerTabPageModel),
                () => new DecompilerTextView()
            },
            {
                typeof(MetadataTablePageModel),
                () => new MetadataTablePage()
            },
            {
                typeof(CompareTabPageModel),
                () => new CompareView()
            },
            // OptionsPageModel is an ObservableObject, not a TabPageModel/ViewModelBase, and its
            // name doesn't fit the *ViewModel->*View convention, so it needs an explicit entry to
            // be resolvable as ContentTabPage.Content inside ContentTabPageView's ContentControl.
            {
                typeof(OptionsPageModel),
                () => new OptionsPageView()
            },
#if DEBUG
			{ typeof(DebugStepsPaneModel),     () => new DebugSteps() },
#endif
        };
        public Control? Build(object? param)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "13ec553b-2d91-4a32-9e21-136dac6973ac" + System.Environment.NewLine);
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
            if (param is null)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "64c9204b-6edc-4eb4-9fc0-ac9288dd71b2" + System.Environment.NewLine);
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
                return null;
            }

            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "74b40e75-c81a-4801-a3e7-84f427557385" + System.Environment.NewLine);
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
            if (s_views.TryGetValue(param.GetType(), out var ctor))
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "9df9236d-0a8c-49f7-aa37-cd294e35993c" + System.Environment.NewLine);
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
                return ctor();
            }

            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "890cd9bb-ea2b-4f92-beb2-db56ac1901b4" + System.Environment.NewLine);
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
            // Convention fallback: SomeViewModel -> SomeView. Type.GetType only searches the
            // calling assembly + corelib, so a plugin viewmodel (loaded into the AppDomain
            // at runtime by AppComposition.LoadPlugins) wouldn't be found via that path
            // alone. Walk every loaded assembly to find the matching View type.
            var name = param.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "eb750bb7-2de2-4428-b368-208c40473f89" + System.Environment.NewLine);
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
            var type = Type.GetType(name);
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2d3719ab-5c66-4ce1-8624-a34f217160f3" + System.Environment.NewLine);
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
            if (type == null)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d2678de5-af7d-410e-9994-a4437c1e8cc7" + System.Environment.NewLine);
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
                foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
                {
                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "163229a3-1826-4d05-8b1c-c3a622a2cb67" + System.Environment.NewLine);
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
                    type = asm.GetType(name);
                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "814aa506-c888-43dd-8825-fbc49a582175" + System.Environment.NewLine);
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
                    if (type != null)
                    {
                        new System.Action(() =>
                        {
                            using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                            if (m.WaitOne(3000))
                            {
                                try
                                {
                                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "00ed9bd3-bd98-4e1d-a192-5861baa591c1" + System.Environment.NewLine);
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
                        break;
                    }
                }
            }

            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "5f3f92b1-c9e5-4445-bc79-a7378f1c0006" + System.Environment.NewLine);
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
            if (type != null)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "fdb56ee0-3d6f-44bb-a9a4-24863fc29ec0" + System.Environment.NewLine);
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
                return (Control)Activator.CreateInstance(type)!;
            }

            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b377069d-35a7-4af1-962b-911c8b888cdf" + System.Environment.NewLine);
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
            return new TextBlock
            {
                Text = "Not Found: " + name
            };
        }

        public bool Match(object? data)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d70aa2f9-8174-412b-a046-6b1c23fc1cb8" + System.Environment.NewLine);
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
            if (data is null)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e385221a-9a4b-4472-99ee-fef1625eef8c" + System.Environment.NewLine);
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
                return false;
            }

            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "1bd8c0e5-353a-49f8-a6ae-0f7ede65fd13" + System.Environment.NewLine);
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
            return data is IDockable || data is ViewModelBase || data is IOptionPage || s_views.ContainsKey(data.GetType());
        }
    }
}