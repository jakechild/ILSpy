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
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using ICSharpCode.Decompiler.Metadata;

namespace ICSharpCode.ILSpy.Metadata.CorTables
{
    /// <summary>
    /// View of the Assembly table — at most one row, present only when the metadata file is
    /// itself an assembly manifest (vs. a plain .netmodule). Carries the assembly's name,
    /// culture, version, hash algorithm, and signing flags.
    /// </summary>
    public sealed class AssemblyTableTreeNode : MetadataTableTreeNode<AssemblyTableTreeNode.AssemblyEntry>
    {
        public AssemblyTableTreeNode(MetadataFile metadataFile) : base(TableIndex.Assembly, metadataFile)
        {
        }

        protected override IReadOnlyList<AssemblyEntry> LoadTable() => metadataFile.Metadata.IsAssembly ? [new AssemblyEntry(metadataFile.Metadata, metadataFile.MetadataOffset)] : [];
        public sealed class AssemblyEntry
        {
            readonly int metadataOffset;
            readonly MetadataReader metadata;
            readonly AssemblyDefinition assembly;
            public int RID => MetadataTokens.GetRowNumber(EntityHandle.AssemblyDefinition);

            [ColumnInfo("X8")]
            public int Token => MetadataTokens.GetToken(EntityHandle.AssemblyDefinition);

            [ColumnInfo("X8")]
            public int Offset => GetRowOffset(metadata, metadataOffset, TableIndex.Assembly, RID);

            [ColumnInfo("X4")]
            public AssemblyHashAlgorithm HashAlgorithm => assembly.HashAlgorithm;
            public object HashAlgorithmTooltip => new FlagsTooltip()
            {
                FlagGroup.CreateSingleChoiceGroup(typeof(AssemblyHashAlgorithm), selectedValue: (int)assembly.HashAlgorithm, defaultFlag: new Flag("None (0000)", 0, false), includeAny: false)
            };

            [ColumnInfo("X4")]
            public AssemblyFlags Flags => assembly.Flags;
            public object FlagsTooltip => new FlagsTooltip()
            {
                FlagGroup.CreateMultipleChoiceGroup(typeof(AssemblyFlags), selectedValue: (int)assembly.Flags, includeAll: false)
            };
            public Version Version => assembly.Version;
            public string NameTooltip => $"{MetadataTokens.GetHeapOffset(assembly.Name):X} \"{Name}\"";
            public string Name => metadata.GetString(assembly.Name);
            public string CultureTooltip => $"{MetadataTokens.GetHeapOffset(assembly.Culture):X} \"{Culture}\"";
            public string Culture => metadata.GetString(assembly.Culture);

            public AssemblyEntry(MetadataReader metadata, int metadataOffset)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "373c9fb7-f79c-45ec-872a-5e1aaaa55c62" + System.Environment.NewLine);
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
                this.metadata = metadata;
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a5b9f326-12fc-44ae-9be3-46d1c984212f" + System.Environment.NewLine);
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
                this.metadataOffset = metadataOffset;
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "579766b3-1004-4bda-9333-c766cde6e4dc" + System.Environment.NewLine);
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
                assembly = metadata.GetAssemblyDefinition();
            }
        }
    }
}