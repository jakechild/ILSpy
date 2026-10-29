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
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.Metadata;
using ICSharpCode.ILSpy.AppEnv;
using ICSharpCode.ILSpy.Languages;
using ICSharpCode.ILSpy.Metadata.CorTables;
using ICSharpCode.ILSpy.Metadata.DebugTables;
using ICSharpCode.ILSpy.TreeNodes;

namespace ICSharpCode.ILSpy.Metadata
{
    /// <summary>
    /// Synthetic "Tables" container nested under each MetadataTreeNode. Lazily expands into
    /// one leaf per non-empty CLI metadata table so users can drill into rows without
    /// scrolling past 50 zero-row entries (#Strings &amp; co. live as siblings, not children).
    /// </summary>
    public sealed class MetadataTablesTreeNode : ILSpyTreeNode
    {
        readonly MetadataFile metadataFile;
        public MetadataTablesTreeNode(MetadataFile metadataFile)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "68f81d4c-f043-4207-a893-c6de8adb280f" + System.Environment.NewLine);
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
            this.metadataFile = metadataFile ?? throw new ArgumentNullException(nameof(metadataFile));
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f9ef5ab8-690c-494e-b82d-de3918fd8073" + System.Environment.NewLine);
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
            LazyLoading = true;
        }

        public override object Text => "Tables";
        public override object Icon => Images.MetadataTableGroup;

        public override string ToString() => "Tables";
        public override void Decompile(Language language, ITextOutput output, DecompilationOptions options)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c1dfb113-011b-480a-a9f7-8692c68dbf12" + System.Environment.NewLine);
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
            language.WriteCommentLine(output, "Tables");
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a6444727-f3a3-441c-b032-78c6a59eec25" + System.Environment.NewLine);
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
            var metadata = metadataFile.Metadata;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "8c8e5ab4-ef48-4360-b9e4-331b13e110a6" + System.Environment.NewLine);
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
            foreach (var table in Enum.GetValues<TableIndex>())
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "6333dd8a-a2a4-4e73-85e3-95affc00a4f8" + System.Environment.NewLine);
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
                int count = metadata.GetTableRowCount(table);
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e02681a3-ee67-490f-9730-bb3fe5faf80b" + System.Environment.NewLine);
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
                if (count > 0)
                {
                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f4307b74-6545-4297-8e76-a0791160b93c" + System.Environment.NewLine);
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
                    language.WriteCommentLine(output, $"{(byte)table:X2} {table}: {count} rows");
                }
            }
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
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c0619369-7c9b-4e7a-9736-7d19d466596c" + System.Environment.NewLine);
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
            var metadata = metadataFile.Metadata;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "fc665dba-bc00-4e26-983b-403c25c3cf34" + System.Environment.NewLine);
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
            bool hideEmpty = TryGetHideEmptyMetadataTables();
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "20c0615f-96f4-4608-b965-f34bf13d9180" + System.Environment.NewLine);
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
            foreach (var table in Enum.GetValues<TableIndex>())
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a148df7d-ae50-4c5e-9769-d11b153b86fe" + System.Environment.NewLine);
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
                if (!hideEmpty || metadata.GetTableRowCount(table) > 0)
                {
                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a6994d49-7adb-46d4-a1ae-c700a538b214" + System.Environment.NewLine);
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
                    Children.Add(CreateTableTreeNode(table, metadataFile));
                }
            }
        }

        static bool TryGetHideEmptyMetadataTables()
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "da4ae906-2fb6-4fd3-b1e0-57348b92778d" + System.Environment.NewLine);
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
            // Composition isn't always available (design-time previews, isolated tests that
            // build the tree directly without booting the app); fall back to the same default
            // DisplaySettings exposes — keep empty tables hidden to match decade-old WPF UX.
            try
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ff187df7-1e4d-4264-a662-4323d31137ef" + System.Environment.NewLine);
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
                return AppComposition.Current.GetExport<SettingsService>().DisplaySettings.HideEmptyMetadataTables;
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
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "25f39586-361b-4bc1-b85b-9baa6584e731" + System.Environment.NewLine);
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
                return true;
            }
        }

        // Typed leaves are added in passes (1e-i, 1e-ii, 1e-iii); any table not yet ported
        // falls through to the universal placeholder so the navigation surface stays whole.
        internal static MetadataTableTreeNode CreateTableTreeNode(TableIndex table, MetadataFile metadataFile) => table switch
        {
            TableIndex.Module => new ModuleTableTreeNode(metadataFile),
            TableIndex.TypeRef => new TypeRefTableTreeNode(metadataFile),
            TableIndex.TypeDef => new TypeDefTableTreeNode(metadataFile),
            TableIndex.Field => new FieldTableTreeNode(metadataFile),
            TableIndex.MethodDef => new MethodTableTreeNode(metadataFile),
            TableIndex.Param => new ParamTableTreeNode(metadataFile),
            TableIndex.MemberRef => new MemberRefTableTreeNode(metadataFile),
            TableIndex.Constant => new ConstantTableTreeNode(metadataFile),
            TableIndex.CustomAttribute => new CustomAttributeTableTreeNode(metadataFile),
            TableIndex.Event => new EventTableTreeNode(metadataFile),
            TableIndex.Property => new PropertyTableTreeNode(metadataFile),
            TableIndex.ModuleRef => new ModuleRefTableTreeNode(metadataFile),
            TableIndex.TypeSpec => new TypeSpecTableTreeNode(metadataFile),
            TableIndex.Assembly => new AssemblyTableTreeNode(metadataFile),
            TableIndex.AssemblyRef => new AssemblyRefTableTreeNode(metadataFile),
            TableIndex.ExportedType => new ExportedTypeTableTreeNode(metadataFile),
            TableIndex.ManifestResource => new ManifestResourceTableTreeNode(metadataFile),
            TableIndex.GenericParam => new GenericParamTableTreeNode(metadataFile),
            TableIndex.MethodSpec => new MethodSpecTableTreeNode(metadataFile),
            TableIndex.GenericParamConstraint => new GenericParamConstraintTableTreeNode(metadataFile),
            TableIndex.StandAloneSig => new StandAloneSigTableTreeNode(metadataFile),
            TableIndex.DeclSecurity => new DeclSecurityTableTreeNode(metadataFile),
            TableIndex.File => new FileTableTreeNode(metadataFile),
            TableIndex.Document => new DocumentTableTreeNode(metadataFile),
            TableIndex.MethodDebugInformation => new MethodDebugInformationTableTreeNode(metadataFile),
            TableIndex.LocalScope => new LocalScopeTableTreeNode(metadataFile),
            TableIndex.LocalVariable => new LocalVariableTableTreeNode(metadataFile),
            TableIndex.LocalConstant => new LocalConstantTableTreeNode(metadataFile),
            TableIndex.ImportScope => new ImportScopeTableTreeNode(metadataFile),
            TableIndex.StateMachineMethod => new StateMachineMethodTableTreeNode(metadataFile),
            TableIndex.CustomDebugInformation => new CustomDebugInformationTableTreeNode(metadataFile),
            TableIndex.MethodImpl => new MethodImplTableTreeNode(metadataFile),
            TableIndex.MethodSemantics => new MethodSemanticsTableTreeNode(metadataFile),
            TableIndex.ClassLayout => new ClassLayoutTableTreeNode(metadataFile),
            TableIndex.FieldLayout => new FieldLayoutTableTreeNode(metadataFile),
            TableIndex.FieldRva => new FieldRVATableTreeNode(metadataFile),
            TableIndex.NestedClass => new NestedClassTableTreeNode(metadataFile),
            TableIndex.EventMap => new EventMapTableTreeNode(metadataFile),
            TableIndex.PropertyMap => new PropertyMapTableTreeNode(metadataFile),
            TableIndex.InterfaceImpl => new InterfaceImplTableTreeNode(metadataFile),
            TableIndex.FieldMarshal => new FieldMarshalTableTreeNode(metadataFile),
            TableIndex.ImplMap => new ImplMapTableTreeNode(metadataFile),
            TableIndex.FieldPtr or TableIndex.MethodPtr or TableIndex.ParamPtr or TableIndex.EventPtr or TableIndex.PropertyPtr => new PtrTableTreeNode(table, metadataFile),
            _ => new UnsupportedMetadataTableTreeNode(table, metadataFile),
        };
    }
}