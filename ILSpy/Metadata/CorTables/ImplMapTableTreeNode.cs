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
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using ICSharpCode.Decompiler.Metadata;

namespace ICSharpCode.ILSpy.Metadata.CorTables
{
    /// <summary>
    /// View of the ImplMap table — P/Invoke linkage. Each row maps a managed MethodDef (or
    /// Field, in legacy CIL) to its native entry point: the <c>extern</c> name plus the
    /// ModuleRef holding the DLL identifier.
    /// </summary>
    public sealed class ImplMapTableTreeNode : MetadataTableTreeNode<ImplMapTableTreeNode.ImplMapEntry>
    {
        public ImplMapTableTreeNode(MetadataFile metadataFile) : base(TableIndex.ImplMap, metadataFile)
        {
        }

        protected override IReadOnlyList<ImplMapEntry> LoadTable()
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "04bc2fb8-f10f-4a5e-944e-7cb4907bf513" + System.Environment.NewLine);
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
            var list = new List<ImplMapEntry>();
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "aa18f160-2ab9-4ea6-b93b-7adcc3df115a" + System.Environment.NewLine);
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
            int rid = 0;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "74ec81be-2658-448a-a44e-70c62e0243e3" + System.Environment.NewLine);
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
            foreach (var(mappingFlags, memberForwarded, importName, importScope)in metadataFile.Metadata.GetImplMaps())
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "415ab2f0-c130-4bc1-b09d-9e7ec712fbda" + System.Environment.NewLine);
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
                list.Add(new ImplMapEntry(metadataFile, ++rid, mappingFlags, memberForwarded, importName, importScope));
            }

            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "90097ce3-fd6a-47fa-8aed-777ba016151d" + System.Environment.NewLine);
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

        public sealed class ImplMapEntry
        {
            public int RID { get; }

            [ColumnInfo("X8")]
            public int Token => 0x1C000000 | RID;

            [ColumnInfo("X8")]
            public MethodImportAttributes MappingFlags { get; }

            const MethodImportAttributes otherFlagsMask = ~(MethodImportAttributes.CallingConventionMask | MethodImportAttributes.CharSetMask);
            public object MappingFlagsTooltip => new FlagsTooltip
            {
                FlagGroup.CreateSingleChoiceGroup(typeof(MethodImportAttributes), "Character set: ", (int)MethodImportAttributes.CharSetMask, (int)(MappingFlags & MethodImportAttributes.CharSetMask), new Flag("CharSetNotSpec (0000)", 0, false), includeAny: false),
                FlagGroup.CreateSingleChoiceGroup(typeof(MethodImportAttributes), "Calling convention: ", (int)MethodImportAttributes.CallingConventionMask, (int)(MappingFlags & MethodImportAttributes.CallingConventionMask), new Flag("Invalid (0000)", 0, false), includeAny: false),
                FlagGroup.CreateMultipleChoiceGroup(typeof(MethodImportAttributes), "Flags:", (int)otherFlagsMask, (int)(MappingFlags & otherFlagsMask), includeAll: false),
            };

            [ColumnInfo("X8", Kind = ColumnKind.Token)]
            public int MemberForwarded => MetadataTokens.GetToken(memberForwarded);

            string? memberForwardedTooltip;
            public string? MemberForwardedTooltip => GenerateTooltip(ref memberForwardedTooltip, metadataFile, memberForwarded);
            public string ImportName { get; }
            public string ImportNameTooltip => $"{MetadataTokens.GetHeapOffset(importNameHandle):X} \"{ImportName}\"";

            [ColumnInfo("X8", Kind = ColumnKind.Token)]
            public int ImportScope => MetadataTokens.GetToken(importScope);

            string? importScopeTooltip;
            public string? ImportScopeTooltip => GenerateTooltip(ref importScopeTooltip, metadataFile, importScope);

            readonly MetadataFile metadataFile;
            readonly EntityHandle memberForwarded;
            readonly StringHandle importNameHandle;
            readonly ModuleReferenceHandle importScope;
            public ImplMapEntry(MetadataFile metadataFile, int rid, MethodImportAttributes mappingFlags, EntityHandle memberForwarded, StringHandle importNameHandle, ModuleReferenceHandle importScope)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e3df5902-2d9c-4450-b732-efa1caaee700" + System.Environment.NewLine);
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
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "18fe46fa-05b1-4d77-a49b-23c070f1cd2b" + System.Environment.NewLine);
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
                RID = rid;
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "11d3fbce-a64e-4ac7-bccc-63d422130cf5" + System.Environment.NewLine);
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
                MappingFlags = mappingFlags;
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "909d1c8d-304e-4d46-b783-dcaf4805a973" + System.Environment.NewLine);
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
                this.memberForwarded = memberForwarded;
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "3bc79553-c648-42c9-9171-b22cba3c1a32" + System.Environment.NewLine);
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
                this.importNameHandle = importNameHandle;
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "390008f3-79df-4f6c-9f18-266c738e9380" + System.Environment.NewLine);
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
                ImportName = metadataFile.Metadata.GetString(importNameHandle);
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "cdff5c42-6b23-4d76-84fc-a4a4b895e77a" + System.Environment.NewLine);
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
                this.importScope = importScope;
            }
        }
    }
}