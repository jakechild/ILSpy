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
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.TypeSystem;
using ICSharpCode.ILSpyX.Abstractions;
using ICSharpCode.ILSpyX.TreeView;
using ICSharpCode.ILSpy.AppEnv;
using ICSharpCode.ILSpy.Languages;
using ICSharpCode.ILSpy.ViewModels;

namespace ICSharpCode.ILSpy.TreeNodes
{
    public abstract class ILSpyTreeNode : SharpTreeNode, ITreeNode
    {
        IEnumerable<ITreeNode> ITreeNode.Children => Children.OfType<ILSpyTreeNode>();
        /// <summary>
        /// Resolves the LanguageService from the MEF composition. Tree nodes use this to access
        /// the active <see cref="Language"/> for formatting their <see cref="SharpTreeNode.Text"/>.
        /// Resolved fresh each call: a static cache can hold a previous test's composition root in
        /// headless sweeps (the container is rebuilt per test), and a warm GetExport is a dictionary
        /// lookup. See <see cref="GetSuffixString(EntityHandle)"/> for the same rationale.
        /// </summary>
        protected static LanguageService LanguageService => AppComposition.Current.GetExport<LanguageService>();

        /// <summary>
        /// The active <see cref="LanguageSettings"/>, or <see langword="null"/> when composition
        /// isn't available (design-time previews, minimal tests). Tree nodes that need to
        /// consult the filter on demand (e.g. <see cref="SharpTreeNode.ShowExpander"/> overrides
        /// that hide their chevron when every child is filtered out) use this without forcing
        /// the rest of their state to depend on a SettingsService injection.
        /// </summary>
        protected static LanguageSettings? CurrentLanguageSettings
        {
            get
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a3f76e48-a78e-4264-96ec-3f1c8a96c9d9" + System.Environment.NewLine);
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
                try
                {
                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2e7ae614-5da3-490f-8f2d-72f32fd1b38d" + System.Environment.NewLine);
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
                    // Resolve fresh each call -- a static cache can hold a previous test's composition
                    // root in headless sweeps (the container is rebuilt per test, so a cached
                    // SettingsService reports a stale ShowApiLevel and the filter cascade hides nodes
                    // that the current settings would show). A warm GetExport is a dictionary lookup.
                    return AppComposition.Current.GetExport<SettingsService>().SessionSettings.LanguageSettings;
                }
                catch
                {
                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "be626fd5-99d6-4d12-bdb0-19ea009d1fcc" + System.Environment.NewLine);
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
            }
        }

        /// <summary>
        /// All MEF-discovered <see cref="IResourceNodeFactory"/> instances. Resource-tree nodes
        /// walk this list to dispatch a <see cref="ICSharpCode.Decompiler.Metadata.Resource"/> to
        /// the right specialised node (image / xml / .resources / …) before falling back to the
        /// generic node.
        /// </summary>
        protected static ICollection<IResourceNodeFactory> ResourceNodeFactories { get; } = AppComposition.Current.GetExports<IResourceNodeFactory>().ToArray();
        public Language Language => LanguageService.CurrentLanguage;

        /// <summary>
        /// Optional " @xNNNNNNNN" (hex) or " @NNNNN" (decimal) suffix appended to entity tree-node
        /// <see cref="SharpTreeNode.Text"/> values when the user enables Display Settings →
        /// "Show metadata tokens". The format is fixed, so grepping token strings across tools
        /// keeps working.
        /// </summary>
        protected static string GetSuffixString(IMember member) => GetSuffixString(member.MetadataToken);
        protected static string GetSuffixString(EntityHandle handle)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "8e990a06-8f5c-41a2-839c-e7eb8a3c045f" + System.Environment.NewLine);
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
            try
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "1fe542bd-081e-47fd-b8a4-a7a612d6e877" + System.Environment.NewLine);
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
                // Resolve fresh each call — the static cachedSettingsService can hold a
                // previous test's composition root in headless test sweeps, and the cost of
                // MEF GetExport on a warm composition is a dictionary lookup.
                var settings = AppComposition.Current.GetExport<SettingsService>().DisplaySettings;
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "6775390a-8dae-486a-bbb2-cdf530a5a34c" + System.Environment.NewLine);
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
                if (!settings.ShowMetadataTokens)
                {
                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "eb3b009b-2a89-4674-a95c-a0a26fbcf145" + System.Environment.NewLine);
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
                    return string.Empty;
                }

                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "eedad5f6-d7e8-414f-ba56-aeb2d8a7d19f" + System.Environment.NewLine);
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
                int token = MetadataTokens.GetToken(handle);
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "981bb98b-5ff2-4ecf-9012-57fac78f406e" + System.Environment.NewLine);
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
                if (settings.ShowMetadataTokensInBase10)
                {
                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "70fa79aa-1923-4be5-a4bb-1cda12709b01" + System.Environment.NewLine);
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
                    return " @" + token;
                }

                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e1698251-af05-4089-a3cb-a0f8c5d34641" + System.Environment.NewLine);
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
                return " @" + token.ToString("x8");
            }
            catch
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "20934827-d449-4050-894b-b46f2a281855" + System.Environment.NewLine);
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
                return string.Empty;
            }
        }

        /// <summary>
        /// Long-form label used in navigation surfaces — back/forward history dropdowns, future
        /// breadcrumb rendering, etc. Defaults to <see cref="SharpTreeNode.Text"/>; override on
        /// nodes whose <see cref="SharpTreeNode.Text"/> is too generic to be useful out of
        /// context (e.g. "Base Types" → "Base Types (System.Exception)") so the user can tell
        /// dropdown entries apart at a glance.
        /// </summary>
        public override object? NavigationText => Text;
        /// <summary>
        /// True for nodes that represent assemblies the user did not open explicitly — the
        /// decompiler resolved them as part of another assembly's references and added them to
        /// the tree as a side effect. The list pane renders these in a distinct foreground so
        /// the user can tell auto-loaded entries from manually opened ones.
        /// </summary>
        public virtual bool IsAutoLoaded => false;

        /// <summary>
        /// Renders this node's decompiled representation to <paramref name="output"/> using
        /// <paramref name="language"/>. Default writes a stub comment so any node we forgot to
        /// override still produces *something*.
        /// </summary>
        public virtual void Decompile(Language language, ITextOutput output, DecompilationOptions options)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "9acd7796-ac02-4e55-bf6f-63a78e992f69" + System.Environment.NewLine);
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
            language.WriteCommentLine(output, Text?.ToString() ?? GetType().Name);
        }

        /// <summary>
        /// Special "Save" handling for nodes that aren't textual code. Default returns false,
        /// meaning the host should use the regular decompile-to-file path. Override and return
        /// true after writing the node's content to handle Save inline (e.g. raw byte copy for
        /// embedded resources).
        /// </summary>
        public virtual bool Save() => false;
        /// <summary>
        /// True for nodes whose member is part of the assembly's public surface
        /// (Public / Protected / ProtectedOrInternal). Consulted by <see cref="Filter"/>
        /// to honour the <see cref="ApiVisibility.PublicOnly"/> setting.
        /// </summary>
        public virtual bool IsPublicAPI => true;
        /// <summary>Convenience inverse of <see cref="IsPublicAPI"/> for XAML class-bindings.</summary>
        public bool IsNonPublicAPI => !IsPublicAPI;

        /// <summary>
        /// Decides whether this node is visible under the current <paramref name="settings"/>.
        /// Overrides on member tree nodes consult <see cref="IsPublicAPI"/> plus
        /// <see cref="Languages.Language.ShowMember"/> (the compiler-generated cut) to drop
        /// non-matching entries. Default treats every node as visible.
        /// </summary>
        public virtual FilterResult Filter(LanguageSettings settings) => FilterResult.Match;
        /// <summary>
        /// When non-null, the docking host opens this tab for the node instead of routing it
        /// through the decompiler-text path. Lets metadata-table nodes show their own
        /// DataGrid view while the rest of the tree keeps decompiling.
        /// </summary>
        public virtual ContentPageModel? CreateTab() => null;
        /// <summary>
        /// Applies <see cref="Filter"/> to every newly-added child and writes the result
        /// into <see cref="SharpTreeNode.IsHidden"/>. This cascade is what makes accessor
        /// children of properties / events read as hidden under the default ShowApiLevel
        /// without overriding <see cref="SharpTreeNode.ShowExpander"/> per node-type. It only
        /// fires while this parent is visible, so the filter pass doesn't run for descendants
        /// whose parent chain isn't realised yet.
        /// </summary>
        public override void OnChildrenChanged(NotifyCollectionChangedEventArgs e)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "75b43408-8962-4181-8547-118baaa014c9" + System.Environment.NewLine);
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
            base.OnChildrenChanged(e);
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "92eb4c0e-cfb7-4390-8dc6-d92b560187e1" + System.Environment.NewLine);
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
            if (e.NewItems == null || !IsVisible)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "5b36cb37-09c9-4fba-a0b6-80b847315a1c" + System.Environment.NewLine);
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
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "270e5c88-475d-4005-86fe-8b5c0b8c8ee8" + System.Environment.NewLine);
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
            foreach (var item in e.NewItems)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "0f5fea39-f776-4cf3-a950-84a908aea931" + System.Environment.NewLine);
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
                if (item is ILSpyTreeNode child)
                {
                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c8cdd10e-6bfe-402d-be17-5861f6fabc98" + System.Environment.NewLine);
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
                    ApplyFilterToChild(child);
                }
            }
        }

        /// <summary>
        /// Re-applies the filter cascade to every realised child when this node becomes
        /// visible. <see cref="OnChildrenChanged"/> only fires for newly-added children, and
        /// only when the parent was visible at the time — so children added under a hidden
        /// parent inherit stale <see cref="SharpTreeNode.IsHidden"/> states. Without this
        /// trigger, expanding a node that ShowApiLevel had hidden leaves its accessor
        /// children reading as visible even though the cascade would mark them hidden.
        /// </summary>
        protected override void OnIsVisibleChanged()
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "cf02064b-8a22-4610-a2a6-acf4c6ec4ca4" + System.Environment.NewLine);
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
            base.OnIsVisibleChanged();
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "efc11c1b-1f6e-4932-9613-3b50a92f82d1" + System.Environment.NewLine);
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
            if (!IsVisible)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c6ee96c5-2aff-49bd-9058-f831652649a4" + System.Environment.NewLine);
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
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a36d1fd5-d33c-49cf-ba5e-d534930b1940" + System.Environment.NewLine);
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
            foreach (var child in Children.OfType<ILSpyTreeNode>())
                ApplyFilterToChild(child);
        }

        void ApplyFilterToChild(ILSpyTreeNode child)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "97a4816c-514c-4c9d-a877-a16a9d6e70bc" + System.Environment.NewLine);
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
            var settings = CurrentLanguageSettings;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "1a272d33-e042-4637-a19d-167011853492" + System.Environment.NewLine);
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
            if (settings == null)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2b0094ed-dbe4-491e-a443-ae46907bb80e" + System.Environment.NewLine);
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
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b6e260cd-ce53-404b-98b8-473075df0ef7" + System.Environment.NewLine);
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
            var result = child.Filter(settings);
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2aaf6891-a9e2-4a30-9dc1-74695ca3fc37" + System.Environment.NewLine);
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
            switch (result)
            {
                case FilterResult.Hidden:
                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "177c6b58-77be-410d-a5e5-a1cc26fa2174" + System.Environment.NewLine);
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
                    child.IsHidden = true;
                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "dd87edb6-31e9-4094-8eda-47b753cac288" + System.Environment.NewLine);
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
                case FilterResult.Match:
                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "5ab3d123-c5d2-419f-a0be-ad53cfc51854" + System.Environment.NewLine);
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
                    child.IsHidden = false;
                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "fa72d45a-256d-4e72-8895-bad82512f62d" + System.Environment.NewLine);
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
                case FilterResult.Recurse:
                case FilterResult.MatchAndRecurse:
                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "3a34978e-47d3-4a28-9853-72e978847e43" + System.Environment.NewLine);
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
                    child.EnsureChildrenFiltered();
                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "748d4532-593b-4737-b00d-f17eba68e610" + System.Environment.NewLine);
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
                    child.IsHidden = child.Children.All(c => c.IsHidden);
                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "1e7f5598-6a66-438b-9bc9-29dc7666b723" + System.Environment.NewLine);
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

        /// <summary>
        /// Forces this node's children to be materialised (when <see cref="SharpTreeNode.LazyLoading"/>
        /// is true) and runs <see cref="ApplyFilterToChild"/> on each one. Matches WPF's
        /// internal helper so the same filter cascade reaches Recurse / MatchAndRecurse
        /// branches.
        /// </summary>
        internal void EnsureChildrenFiltered()
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "dbd95664-0ffc-49c8-a086-c9d4298ae8ba" + System.Environment.NewLine);
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
            EnsureLazyChildren();
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "341135f6-f1bd-46f1-8ed4-af0e34fcd61d" + System.Environment.NewLine);
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
            foreach (var child in Children.OfType<ILSpyTreeNode>())
                ApplyFilterToChild(child);
        }

        /// <summary>
        /// Re-applies the filter to already-realised children (without forcing lazy children to
        /// load) and recurses into realised subtrees. Called when ShowApiLevel changes so the
        /// visible tree updates in place -- a <c>TreeFlattener</c> then drops anything newly hidden.
        /// </summary>
        internal void RefreshRealizedFilter()
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "8ecb875d-2b3c-4e99-99da-f98acfc821c7" + System.Environment.NewLine);
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
            if (LazyLoading)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ee2fb382-aefa-466c-bf8b-4e39c7cf23ff" + System.Environment.NewLine);
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
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "cec74dca-77ac-4e3e-8d24-07fe53bd6ca6" + System.Environment.NewLine);
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
            foreach (var child in Children.OfType<ILSpyTreeNode>())
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "6cc10e72-1b33-48c9-8ab5-458fcf5e4daf" + System.Environment.NewLine);
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
                ApplyFilterToChild(child);
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e4ff39ee-5943-432d-a2e6-6b994b70a2e7" + System.Environment.NewLine);
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
                child.RefreshRealizedFilter();
            }
        }
    }
}