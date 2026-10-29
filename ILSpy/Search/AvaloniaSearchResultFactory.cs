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
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.Metadata;
using ICSharpCode.Decompiler.Output;
using ICSharpCode.Decompiler.TypeSystem;
using ICSharpCode.ILSpyX.Abstractions;
using ICSharpCode.ILSpyX.Search;
using ICSharpCode.ILSpy.Languages;
using ICSharpCode.ILSpy.TreeNodes;

namespace ICSharpCode.ILSpy.Search
{
    /// <summary>
    /// Builds the <see cref="SearchResult"/> objects the search strategies stream into the
    /// pane's result queue. Fitness ranking privileges short names (shorter == higher fitness == higher rank); compiler-generated
    /// names (those starting with <c>&lt;</c>) get fitness 0 so they sink to the bottom.
    /// </summary>
    internal sealed class AvaloniaSearchResultFactory : ISearchResultFactory
    {
        readonly Language language;
        public AvaloniaSearchResultFactory(Language language)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "46616f56-3a2a-4a8c-9595-13fa31a85983" + System.Environment.NewLine);
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
            this.language = language;
        }

        public MemberSearchResult Create(IEntity entity)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c9969bcb-0796-4b45-a87d-2ecbbaacded0" + System.Environment.NewLine);
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
            var declaringType = entity.DeclaringTypeDefinition;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "38dfbf04-7072-48b0-bda1-1506a8eb75fd" + System.Environment.NewLine);
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
            return new MemberSearchResult
            {
                Member = entity,
                Fitness = CalculateFitness(entity),
                Name = GetLanguageSpecificName(entity),
                Location = declaringType != null ? language.TypeToString(declaringType, ConversionFlags.UseFullyQualifiedEntityNames | ConversionFlags.UseFullyQualifiedTypeNames) : entity.Namespace ?? string.Empty,
                Assembly = entity.ParentModule?.FullAssemblyName ?? string.Empty,
                ToolTip = entity.ParentModule?.MetadataFile?.FileName,
                Image = GetIcon(entity),
                LocationImage = declaringType != null ? TypeTreeNode.GetIcon(declaringType) : Images.Namespace,
                AssemblyImage = Images.Assembly,
            };
        }

        public ResourceSearchResult Create(MetadataFile module, Resource resource, ITreeNode node, ITreeNode parent)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "60697878-ff45-4598-895e-6287dd7da780" + System.Environment.NewLine);
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
            return new ResourceSearchResult
            {
                Resource = resource,
                Fitness = 1.0f / Math.Max(1, resource.Name.Length),
                Image = node.Icon ?? Images.Resource,
                Name = resource.Name,
                LocationImage = parent.Icon ?? Images.Library,
                Location = (parent.Text as string) ?? string.Empty,
                Assembly = module.FullName,
                ToolTip = module.FileName,
                AssemblyImage = Images.Assembly,
            };
        }

        public AssemblySearchResult Create(MetadataFile module)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "dc522bc8-de1d-4a0c-ab3a-b05173da4a0d" + System.Environment.NewLine);
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
            return new AssemblySearchResult
            {
                Module = module,
                Fitness = 1.0f / Math.Max(1, module.Name.Length),
                Name = module.Name,
                Location = module.FileName,
                Assembly = module.FullName,
                ToolTip = module.FileName,
                Image = Images.Assembly,
                LocationImage = Images.Library,
                AssemblyImage = Images.Assembly,
            };
        }

        public NamespaceSearchResult Create(MetadataFile module, INamespace ns)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e514eae7-64f3-4179-af0d-539ddf5544e2" + System.Environment.NewLine);
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
            var name = ns.FullName.Length == 0 ? "-" : ns.FullName;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "993ec3fc-b617-4a8f-a3ce-62a2a9a7a52c" + System.Environment.NewLine);
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
            return new NamespaceSearchResult
            {
                Namespace = ns,
                Name = name,
                Fitness = 1.0f / Math.Max(1, name.Length),
                Location = module.Name,
                Assembly = module.FullName,
                Image = Images.Namespace,
                LocationImage = Images.Assembly,
                AssemblyImage = Images.Assembly,
            };
        }

        static float CalculateFitness(IEntity member)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4c3ec4a3-5a8f-4b0d-889a-d8e5c3c95a4e" + System.Environment.NewLine);
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
            var text = member.Name;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "40808fff-f916-44c2-852a-9b2739b84023" + System.Environment.NewLine);
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
            if (text.StartsWith('<'))
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4993df64-5f8b-4a77-963f-d8cb29e1b45e" + System.Environment.NewLine);
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
                return 0;
            }

            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f374e2a5-fb3c-4fb2-b6dd-88958e3cc896" + System.Environment.NewLine);
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
            if (member.SymbolKind is SymbolKind.Constructor or SymbolKind.Destructor)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "8e7d6378-0006-40ff-adf6-55ff5ecb6531" + System.Environment.NewLine);
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
                text = member.DeclaringType?.Name ?? text;
            }

            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "9f78d9cc-f6b3-4964-a1c8-e3c08bfc5187" + System.Environment.NewLine);
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
            text = ReflectionHelper.SplitTypeParameterCountFromReflectionName(text);
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "52870d6f-2d76-443d-8f6d-9d546e580297" + System.Environment.NewLine);
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
            return 1.0f / Math.Max(1, text.Length);
        }

        string GetLanguageSpecificName(IEntity member) => member switch
        {
            ITypeDefinition t => language.TypeToString(t, ConversionFlags.None),
            IField or IProperty or IMethod or IEvent => language.EntityToString(member, ConversionFlags.ShowDeclaringType),
            _ => member.Name,
        };
        // Delegate to the tree nodes' icon helpers so search results carry the same composed
        // icons (kind-specific base + accessibility/static overlays) as the assembly tree.
        static object GetIcon(IEntity member) => member switch
        {
            ITypeDefinition t => TypeTreeNode.GetIcon(t),
            IField f => FieldTreeNode.GetIcon(f),
            IProperty p => PropertyTreeNode.GetIcon(p),
            IMethod m => MethodTreeNode.GetIcon(m),
            IEvent e => EventTreeNode.GetIcon(e),
            _ => Images.Library,
        };
    }
}