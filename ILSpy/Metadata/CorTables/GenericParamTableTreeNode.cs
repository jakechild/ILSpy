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
    /// View of the GenericParam table — every type or method generic-parameter slot. Owner
    /// is a TypeOrMethodDef coded token; Number is the parameter's 0-based index inside
    /// its owner's type-parameter list.
    /// </summary>
    public sealed class GenericParamTableTreeNode : MetadataTableTreeNode<GenericParamTableTreeNode.GenericParamEntry>
    {
        public GenericParamTableTreeNode(MetadataFile metadataFile) : base(TableIndex.GenericParam, metadataFile)
        {
        }

        protected override IReadOnlyList<GenericParamEntry> LoadTable()
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "3c041b04-d8b1-48d3-a677-d3d9d0769f61" + System.Environment.NewLine);
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
            var list = new List<GenericParamEntry>();
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "0005545e-66c3-4b25-b306-632812243a81" + System.Environment.NewLine);
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
            for (int row = 1; row <= metadataFile.Metadata.GetTableRowCount(TableIndex.GenericParam); row++)
                list.Add(new GenericParamEntry(metadataFile, MetadataTokens.GenericParameterHandle(row)));
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "681bc0e6-f9fc-46fa-9163-4e0b85d1d64b" + System.Environment.NewLine);
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

        public sealed class GenericParamEntry
        {
            readonly MetadataFile metadataFile;
            readonly GenericParameterHandle handle;
            readonly GenericParameter genericParam;
            public int RID => MetadataTokens.GetRowNumber(handle);

            [ColumnInfo("X8")]
            public int Token => MetadataTokens.GetToken(handle);

            [ColumnInfo("X8")]
            public int Offset => GetRowOffset(metadataFile, TableIndex.GenericParam, RID);
            public int Number => genericParam.Index;

            [ColumnInfo("X8")]
            public GenericParameterAttributes Attributes => genericParam.Attributes;
            public object AttributesTooltip => new FlagsTooltip
            {
                FlagGroup.CreateSingleChoiceGroup(typeof(GenericParameterAttributes), "Variance: ", (int)GenericParameterAttributes.VarianceMask, (int)(genericParam.Attributes & GenericParameterAttributes.VarianceMask), new Flag("None (0000)", 0, false), includeAny: false),
                FlagGroup.CreateMultipleChoiceGroup(typeof(GenericParameterAttributes), "Special Constraint: ", (int)GenericParameterAttributes.SpecialConstraintMask, (int)(genericParam.Attributes & GenericParameterAttributes.SpecialConstraintMask), includeAll: false),
            };

            [ColumnInfo("X8", Kind = ColumnKind.Token)]
            public int Owner => MetadataTokens.GetToken(genericParam.Parent);

            string? ownerTooltip;
            public string? OwnerTooltip => GenerateTooltip(ref ownerTooltip, metadataFile, genericParam.Parent);
            public string Name => metadataFile.Metadata.GetString(genericParam.Name);
            public string NameTooltip => $"{MetadataTokens.GetHeapOffset(genericParam.Name):X} \"{Name}\"";

            public GenericParamEntry(MetadataFile metadataFile, GenericParameterHandle handle)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4a3bce98-e06b-466b-a2a7-068e2bdf1c1c" + System.Environment.NewLine);
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
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ac067553-fccf-478a-bb12-f5250b4baee0" + System.Environment.NewLine);
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
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "512d01d3-548c-4c2e-9e29-edde99e0901a" + System.Environment.NewLine);
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
                genericParam = metadataFile.Metadata.GetGenericParameter(handle);
            }
        }
    }
}