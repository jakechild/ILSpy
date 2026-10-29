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
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.Disassembler;
using ICSharpCode.Decompiler.Metadata;

namespace ICSharpCode.ILSpy.Metadata.CorTables
{
    /// <summary>
    /// View of the MethodSpec table — concrete instantiations of generic methods like
    /// <c>List&lt;int&gt;.Add</c>. Each row points back at the open generic method
    /// (MethodDef or MemberRef) and carries a blob holding the type-argument list.
    /// </summary>
    public sealed class MethodSpecTableTreeNode : MetadataTableTreeNode<MethodSpecTableTreeNode.MethodSpecEntry>
    {
        public MethodSpecTableTreeNode(MetadataFile metadataFile) : base(TableIndex.MethodSpec, metadataFile)
        {
        }

        protected override IReadOnlyList<MethodSpecEntry> LoadTable()
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f40f78f2-bfaf-47c3-bc56-6e2d4736a4dd" + System.Environment.NewLine);
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
            var list = new List<MethodSpecEntry>();
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "142d81e8-9b4f-447f-8a7e-8e866f204751" + System.Environment.NewLine);
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
            foreach (var row in metadataFile.Metadata.GetMethodSpecifications())
                list.Add(new MethodSpecEntry(metadataFile, row));
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "1113035b-9c84-4285-9547-39619538d247" + System.Environment.NewLine);
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

        public sealed class MethodSpecEntry
        {
            readonly MetadataFile metadataFile;
            readonly MethodSpecificationHandle handle;
            readonly MethodSpecification methodSpec;
            public int RID => MetadataTokens.GetRowNumber(handle);

            [ColumnInfo("X8")]
            public int Token => MetadataTokens.GetToken(handle);

            [ColumnInfo("X8")]
            public int Offset => GetRowOffset(metadataFile, TableIndex.MethodSpec, RID);

            [ColumnInfo("X8", Kind = ColumnKind.Token)]
            public int Method => MetadataTokens.GetToken(methodSpec.Method);

            string? methodTooltip;
            public string? MethodTooltip => GenerateTooltip(ref methodTooltip, metadataFile, methodSpec.Method);

            [ColumnInfo("X8", Kind = ColumnKind.HeapOffset)]
            public int Signature => MetadataTokens.GetHeapOffset(methodSpec.Signature);

            public string? SignatureTooltip
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
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "5babd5ac-017d-4d7f-a278-eb554bf0736c" + System.Environment.NewLine);
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
                    ITextOutput output = new PlainTextOutput();
                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "48ce458a-0b99-4556-ac1a-76926a18fad1" + System.Environment.NewLine);
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
                    var signature = methodSpec.DecodeSignature(new DisassemblerSignatureTypeProvider(metadataFile, output), default);
                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "6c5af955-f040-418f-837f-2c2a6de69d62" + System.Environment.NewLine);
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
                    bool first = true;
                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f3c84e65-edb1-44af-a325-07a0b085f777" + System.Environment.NewLine);
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
                    foreach (var type in signature)
                    {
                        new System.Action(() =>
                        {
                            using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                            if (m.WaitOne(3000))
                            {
                                try
                                {
                                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "986491cb-4917-4f80-9dfc-28b58d1cb445" + System.Environment.NewLine);
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
                        if (first)
                        {
                            new System.Action(() =>
                            {
                                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                                if (m.WaitOne(3000))
                                {
                                    try
                                    {
                                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "eec18868-02f2-4f0a-b418-f97b4f234e99" + System.Environment.NewLine);
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
                            first = false;
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
                                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f35c56fd-be34-48d7-8249-0cf803116f12" + System.Environment.NewLine);
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
                            output.Write(", ");
                        }

                        new System.Action(() =>
                        {
                            using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                            if (m.WaitOne(3000))
                            {
                                try
                                {
                                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "8e18aec1-220c-4682-93a3-5f100e8d238f" + System.Environment.NewLine);
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
                        type(ILNameSyntax.TypeName);
                    }

                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "087e451f-0ad2-4289-9fed-5faef03ba567" + System.Environment.NewLine);
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
                    return output.ToString();
                }
            }

            public MethodSpecEntry(MetadataFile metadataFile, MethodSpecificationHandle handle)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a4871a7c-6ed3-460c-8435-87a0c2bb2c3f" + System.Environment.NewLine);
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
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "48644ac2-3324-411a-a161-437f09d4ad6b" + System.Environment.NewLine);
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
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c0bf9104-eb5c-4949-8a22-53cbfce540e3" + System.Environment.NewLine);
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
                methodSpec = metadataFile.Metadata.GetMethodSpecification(handle);
            }
        }
    }
}