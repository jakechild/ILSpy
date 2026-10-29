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
using System.Linq;
using Avalonia.Media;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.Output;
using ICSharpCode.Decompiler.TypeSystem;
using ICSharpCode.ILSpyX;
using ICSharpCode.ILSpy.Languages;
using ICSharpCode.ILSpy.TreeNodes;

namespace ICSharpCode.ILSpy.Compare
{
    /// <summary>
    /// Tree-node façade over a merged <see cref="Entry"/>. The text combines both sides'
    /// formatted entity strings (with a <c>" -> "</c> separator when they differ); the
    /// background brush is a light tint that mirrors the diff kind (green for additions,
    /// pink for removals, blue for updates). Identical entries render with a transparent
    /// background and stay hidden unless the toolbar's "Show Identical" toggle is on.
    /// </summary>
    public sealed class ComparisonEntryTreeNode : ILSpyTreeNode
    {
        readonly Entry entry;
        readonly CompareTabPageModel pane;
        internal Entry Entry => entry;

        public ComparisonEntryTreeNode(Entry entry, CompareTabPageModel pane)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "477e9e43-579e-4ea2-ab26-650799564439" + System.Environment.NewLine);
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
            this.entry = entry;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2c3d1f0a-d675-4b03-adc0-d1adf5e00006" + System.Environment.NewLine);
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
            this.pane = pane;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "6e974cd6-8600-48a6-8efa-58f9303f01d3" + System.Environment.NewLine);
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
            LazyLoading = entry.Children != null;
        }

        protected override void LoadChildren()
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c6f9d6a7-4c2b-4118-95a8-d3e8bd54ae3e" + System.Environment.NewLine);
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
            if (entry.Children == null)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "9a5ad6bd-66f7-4ee0-bd92-c81d67776979" + System.Environment.NewLine);
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
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f22e4aa1-4608-482d-895c-b73f0de268f5" + System.Environment.NewLine);
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
            // Order: changes first (Add/Remove/Update lexically before None via the negated
            // enum cast), then by SymbolKind so types group together, then alphabetically
            // by signature. Matches the WPF view's display order.
            foreach (var item in entry.Children.OrderBy(e => (-(int)e.RecursiveKind, e.Entity.SymbolKind, e.Signature)))
                Children.Add(new ComparisonEntryTreeNode(item, pane));
        }

        public override object Text
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
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "0b7fbfc9-affe-46a8-a66c-96b66aa8fe99" + System.Environment.NewLine);
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
                var leftText = FormatEntity(entry.Entity);
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "bb12b3d0-6101-4fc6-ba50-6cb48ae702dd" + System.Environment.NewLine);
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
                var rightText = FormatEntity(entry.OtherEntity);
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "1673004e-3098-4340-832e-e40474cd17ac" + System.Environment.NewLine);
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
                return leftText + (rightText != null && leftText != rightText ? " -> " + rightText : "");
            }
        }

        string? FormatEntity(ISymbol? symbol) => symbol switch
        {
            ITypeDefinition t => Language.TypeToString(t, ConversionFlags.None),
            IEntity e => Language.EntityToString(e, ConversionFlags.All & ~(ConversionFlags.ShowDeclaringType | ConversionFlags.UseFullyQualifiedEntityNames | ConversionFlags.UseFullyQualifiedTypeNames)),
            INamespace n => n.FullName,
            IModule m => m.FullAssemblyName,
            _ => null,
        };
        public override object Icon => entry.Entity switch
        {
            ITypeDefinition t => TypeTreeNode.GetIcon(t),
            IMethod m => MethodTreeNode.GetIcon(m),
            IField f => FieldTreeNode.GetIcon(f),
            IProperty p => PropertyTreeNode.GetIcon(p),
            IEvent e => EventTreeNode.GetIcon(e),
            INamespace => ICSharpCode.ILSpy.Images.Namespace,
            IModule => ICSharpCode.ILSpy.Images.Assembly,
            _ => ICSharpCode.ILSpy.Images.Class,
        };

        public override void Decompile(Language language, ICSharpCode.Decompiler.ITextOutput output, DecompilationOptions options)
        {
        // Compare nodes aren't decompilable on their own — they're a diff overlay.
        // Clicking a row jumps to the underlying entity in the assembly tree, which
        // then drives the normal decompile flow on whichever tab the user picks.
        }

        public override FilterResult Filter(LanguageSettings settings)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "aa0a9386-3ec9-43e9-8933-57639537b1c0" + System.Environment.NewLine);
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
            // Hide identical rows unless the toolbar toggle says otherwise. Recursive
            // because a parent node whose ALL descendants are unchanged should also hide.
            return pane.ShowIdentical || entry.RecursiveKind != DiffKind.None ? FilterResult.Match : FilterResult.Hidden;
        }

        /// <summary>
        /// Pastel-tint background per diff kind: green = added on the right, pink = removed
        /// from the right (i.e. only on the left), blue = signatures match but contents
        /// differ. Identical rows fall through to the parent background.
        /// </summary>
        public IBrush BackgroundBrush => entry.RecursiveKind switch
        {
            DiffKind.Add => new SolidColorBrush(Color.FromArgb(0xFF, 0x90, 0xEE, 0x90)),
            DiffKind.Remove => new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0xB6, 0xC1)),
            DiffKind.Update => new SolidColorBrush(Color.FromArgb(0xFF, 0xAD, 0xD8, 0xE6)),
            _ => Brushes.Transparent,
        };
    }
}