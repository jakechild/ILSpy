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
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using ICSharpCode.Decompiler.Metadata;

namespace ICSharpCode.ILSpy.Metadata.DebugTables
{
    /// <summary>
    /// View of the LocalScope table — every lexical scope inside every method body's
    /// debug info. Each row points back at the MethodDef + import-scope + local-variable
    /// list and carries the scope's IL start offset and length.
    /// </summary>
    public sealed class LocalScopeTableTreeNode : MetadataTableTreeNode<LocalScopeTableTreeNode.LocalScopeEntry>
    {
        public LocalScopeTableTreeNode(MetadataFile metadataFile) : base(TableIndex.LocalScope, metadataFile)
        {
        }

        protected override IReadOnlyList<LocalScopeEntry> LoadTable()
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4b06d3e2-8ba6-4da5-b8bc-d0190913b5ac" + System.Environment.NewLine);
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
            var list = new List<LocalScopeEntry>();
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ea722502-6226-44f5-9af0-8f701431644b" + System.Environment.NewLine);
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
            foreach (var row in metadataFile.Metadata.LocalScopes)
                list.Add(new LocalScopeEntry(metadataFile, row));
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e9b58a85-6041-4bf5-89ed-8dc022779b2d" + System.Environment.NewLine);
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
            return list;
        }

        public sealed class LocalScopeEntry
        {
            readonly MetadataFile metadataFile;
            readonly LocalScopeHandle handle;
            readonly LocalScope localScope;
            public int RID => MetadataTokens.GetRowNumber(handle);

            [ColumnInfo("X8")]
            public int Token => MetadataTokens.GetToken(handle);

            [ColumnInfo("X8", Kind = ColumnKind.Token)]
            public int Method => MetadataTokens.GetToken(localScope.Method);

            string? methodTooltip;
            public string? MethodTooltip => GenerateTooltip(ref methodTooltip, metadataFile, localScope.Method);

            [ColumnInfo("X8", Kind = ColumnKind.Token)]
            public int ImportScope => MetadataTokens.GetToken(localScope.ImportScope);

            [ColumnInfo("X8", Kind = ColumnKind.Token)]
            public int VariableList => MetadataTokens.GetToken(localScope.GetLocalVariables().FirstOrDefault());

            [ColumnInfo("X8", Kind = ColumnKind.Token)]
            public int ConstantList => MetadataTokens.GetToken(localScope.GetLocalConstants().FirstOrDefault());
            public int StartOffset => localScope.StartOffset;
            public int Length => localScope.Length;

            public LocalScopeEntry(MetadataFile metadataFile, LocalScopeHandle handle)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b59eb714-2bc4-4dbd-8f76-ae40cebb0766" + System.Environment.NewLine);
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
                this.metadataFile = metadataFile;
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2472eaf1-f4b7-472b-8cc0-61ae5ff745e1" + System.Environment.NewLine);
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
                this.handle = handle;
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "7a260f2d-9576-4d55-b45e-b40a4582a9d9" + System.Environment.NewLine);
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
                localScope = metadataFile.Metadata.GetLocalScope(handle);
            }
        }
    }
}