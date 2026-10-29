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
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using ICSharpCode.Decompiler.Metadata;

namespace ICSharpCode.ILSpy.Metadata.CorTables
{
    /// <summary>
    /// View of the MethodImpl table — explicit interface implementations and method-body
    /// overrides where the declared signature differs from the impl signature. Each row
    /// pairs a Type, a MethodDeclaration (the override target), and a MethodBody (the impl).
    /// </summary>
    public sealed class MethodImplTableTreeNode : MetadataTableTreeNode<MethodImplTableTreeNode.MethodImplEntry>
    {
        public MethodImplTableTreeNode(MetadataFile metadataFile) : base(TableIndex.MethodImpl, metadataFile)
        {
        }

        protected override IReadOnlyList<MethodImplEntry> LoadTable()
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a87afa03-e419-4446-8abe-b1336ffcf04e" + System.Environment.NewLine);
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
            var list = new List<MethodImplEntry>();
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c55b1f81-1c64-45c5-b6a6-6d558c62b03c" + System.Environment.NewLine);
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
            for (int row = 1; row <= metadataFile.Metadata.GetTableRowCount(TableIndex.MethodImpl); row++)
                list.Add(new MethodImplEntry(metadataFile, MetadataTokens.MethodImplementationHandle(row)));
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b6ca0509-c03c-4793-ad79-29109332592b" + System.Environment.NewLine);
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

        public sealed class MethodImplEntry
        {
            readonly MetadataFile metadataFile;
            readonly MethodImplementationHandle handle;
            readonly MethodImplementation methodImpl;
            public int RID => MetadataTokens.GetToken(handle) & 0xFFFFFF;

            [ColumnInfo("X8")]
            public int Token => MetadataTokens.GetToken(handle);

            [ColumnInfo("X8", Kind = ColumnKind.Token)]
            public int Type => MetadataTokens.GetToken(methodImpl.Type);

            string? typeTooltip;
            public string? TypeTooltip => GenerateTooltip(ref typeTooltip, metadataFile, methodImpl.Type);

            [ColumnInfo("X8", Kind = ColumnKind.Token)]
            public int MethodDeclaration => MetadataTokens.GetToken(methodImpl.MethodDeclaration);

            string? methodDeclarationTooltip;
            public string? MethodDeclarationTooltip => GenerateTooltip(ref methodDeclarationTooltip, metadataFile, methodImpl.MethodDeclaration);

            [ColumnInfo("X8", Kind = ColumnKind.Token)]
            public int MethodBody => MetadataTokens.GetToken(methodImpl.MethodBody);

            string? methodBodyTooltip;
            public string? MethodBodyTooltip => GenerateTooltip(ref methodBodyTooltip, metadataFile, methodImpl.MethodBody);

            public MethodImplEntry(MetadataFile metadataFile, MethodImplementationHandle handle)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d9698acd-d54f-42dd-a4eb-e67c98ed27dd" + System.Environment.NewLine);
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
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "5ae4ef7a-210f-4f43-bc80-600f0a1dde01" + System.Environment.NewLine);
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
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "fba97cbb-2a97-4b19-abfe-f15858b38fef" + System.Environment.NewLine);
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
                methodImpl = metadataFile.Metadata.GetMethodImplementation(handle);
            }
        }
    }
}