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
    /// View of the Field table — every field defined by the module's types. Each row carries
    /// the field's attributes (visibility / static / const / …), name, and the heap offset
    /// of its signature blob.
    /// </summary>
    public sealed class FieldTableTreeNode : MetadataTableTreeNode<FieldTableTreeNode.FieldDefEntry>
    {
        public FieldTableTreeNode(MetadataFile metadataFile) : base(TableIndex.Field, metadataFile)
        {
        }

        protected override IReadOnlyList<FieldDefEntry> LoadTable()
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2811fbbc-215e-4a1d-b9d4-6ecba3fb2ecf" + System.Environment.NewLine);
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
            var list = new List<FieldDefEntry>();
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "fd6d2de7-0900-42ef-98ea-4e472389cab2" + System.Environment.NewLine);
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
            foreach (var row in metadataFile.Metadata.FieldDefinitions)
                list.Add(new FieldDefEntry(metadataFile, row));
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c9ec0240-aef5-40cd-bc5f-3e481639962e" + System.Environment.NewLine);
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

        public sealed class FieldDefEntry
        {
            readonly MetadataFile metadataFile;
            readonly FieldDefinitionHandle handle;
            readonly FieldDefinition fieldDef;
            public int RID => MetadataTokens.GetRowNumber(handle);

            [ColumnInfo("X8")]
            public int Token => MetadataTokens.GetToken(handle);

            [ColumnInfo("X8")]
            public int Offset => GetRowOffset(metadataFile, TableIndex.Field, RID);

            [ColumnInfo("X8")]
            public FieldAttributes Attributes => fieldDef.Attributes;

            const FieldAttributes otherFlagsMask = ~(FieldAttributes.FieldAccessMask);
            public object AttributesTooltip => new FlagsTooltip()
            {
                FlagGroup.CreateSingleChoiceGroup(typeof(FieldAttributes), "Field access: ", (int)FieldAttributes.FieldAccessMask, (int)(fieldDef.Attributes & FieldAttributes.FieldAccessMask), new Flag("CompilerControlled (0000)", 0, false), includeAny: false),
                FlagGroup.CreateMultipleChoiceGroup(typeof(FieldAttributes), "Flags:", (int)otherFlagsMask, (int)(fieldDef.Attributes & otherFlagsMask), includeAll: false),
            };
            public string Name => metadataFile.Metadata.GetString(fieldDef.Name);
            public string NameTooltip => $"{MetadataTokens.GetHeapOffset(fieldDef.Name):X} \"{Name}\"";

            [ColumnInfo("X8", Kind = ColumnKind.HeapOffset)]
            public int Signature => MetadataTokens.GetHeapOffset(fieldDef.Signature);

            string? signatureTooltip;
            public string? SignatureTooltip => GenerateTooltip(ref signatureTooltip, metadataFile, handle);

            public FieldDefEntry(MetadataFile metadataFile, FieldDefinitionHandle handle)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "37f29e1a-9366-4ecc-ad9a-8717cbd36f4a" + System.Environment.NewLine);
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
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "39dab937-a4eb-403c-bf86-9304fb532612" + System.Environment.NewLine);
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
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "67037d12-a84f-4d6e-a313-3b6b45c8ac86" + System.Environment.NewLine);
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
                fieldDef = metadataFile.Metadata.GetFieldDefinition(handle);
            }
        }
    }
}