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
using System.Reflection;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using ICSharpCode.Decompiler;
using ICSharpCode.Decompiler.Disassembler;
using ICSharpCode.Decompiler.Metadata;

namespace ICSharpCode.ILSpy.Metadata.CorTables
{
    /// <summary>
    /// View of the TypeDef table — every type the module defines. The first row is the
    /// pseudo-type &lt;Module&gt;, owning module-scoped fields and methods. Each row carries
    /// attributes (visibility, layout, semantics), the optional base type, and pointers
    /// into the FieldList / MethodList for the type's members.
    /// </summary>
    public sealed class TypeDefTableTreeNode : MetadataTableTreeNode<TypeDefTableTreeNode.TypeDefEntry>
    {
        public TypeDefTableTreeNode(MetadataFile metadataFile) : base(TableIndex.TypeDef, metadataFile)
        {
        }

        protected override IReadOnlyList<TypeDefEntry> LoadTable()
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4fe1997b-ca8c-4acd-9dc1-d310b06a6b48" + System.Environment.NewLine);
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
            var list = new List<TypeDefEntry>();
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "8c1fa743-3cdf-4f4a-a34b-cc2f997f0bfc" + System.Environment.NewLine);
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
            // FieldList/MethodList come from the raw rows (GetTypeDefListColumns): the computed
            // member ranges (TypeDefinition.GetFields/GetMethods) are empty for a memberless type,
            // but the stored column value is the running list position (the next type's first
            // member row, or one past the member table's end), never 0.
            foreach (var(handle, fieldList, methodList)in metadataFile.Metadata.GetTypeDefListColumns())
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "57302867-d346-43ed-808b-d03c54543cec" + System.Environment.NewLine);
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
                list.Add(new TypeDefEntry(metadataFile, handle, fieldList, methodList));
            }

            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "1f378546-b0b0-4bf5-bd09-0b4abdb8f40a" + System.Environment.NewLine);
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

        public sealed class TypeDefEntry
        {
            readonly MetadataFile metadataFile;
            readonly TypeDefinitionHandle handle;
            readonly TypeDefinition typeDef;
            public int RID => MetadataTokens.GetRowNumber(handle);

            [ColumnInfo("X8")]
            public int Token => MetadataTokens.GetToken(handle);

            [ColumnInfo("X8")]
            public int Offset => GetRowOffset(metadataFile, TableIndex.TypeDef, RID);

            [ColumnInfo("X8")]
            public TypeAttributes Attributes => typeDef.Attributes;
            public object AttributesTooltip => FlagsTooltip.ForTypeAttributes(typeDef.Attributes);
            public string Name => metadataFile.Metadata.GetString(typeDef.Name);
            public string NameTooltip => $"{MetadataTokens.GetHeapOffset(typeDef.Name):X} \"{Name}\"";
            public string Namespace => metadataFile.Metadata.GetString(typeDef.Namespace);
            public string NamespaceTooltip => $"{MetadataTokens.GetHeapOffset(typeDef.Namespace):X} \"{Namespace}\"";

            [ColumnInfo("X8", Kind = ColumnKind.Token)]
            public int BaseType => MetadataTokens.GetToken(typeDef.BaseType);

            public string? BaseTypeTooltip
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
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "92dc3ff9-f325-473f-b209-eacd0819ead6" + System.Environment.NewLine);
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
                    var output = new PlainTextOutput();
                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "9bf82da5-29e7-4b79-9acb-b828a0d9c99e" + System.Environment.NewLine);
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
                    var provider = new DisassemblerSignatureTypeProvider(metadataFile, output);
                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "53e2e7db-8116-423c-b7b0-b9de665d4921" + System.Environment.NewLine);
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
                    if (typeDef.BaseType.IsNil)
                    {
                        new System.Action(() =>
                        {
                            using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                            if (m.WaitOne(3000))
                            {
                                try
                                {
                                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f3274f1a-7e80-41e2-9a5a-098d14e3f331" + System.Environment.NewLine);
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
                        return null;
                    }

                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "8054a378-3abb-46b4-8d46-3363d130867a" + System.Environment.NewLine);
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
                    switch (typeDef.BaseType.Kind)
                    {
                        case HandleKind.TypeDefinition:
                            new System.Action(() =>
                            {
                                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                                if (m.WaitOne(3000))
                                {
                                    try
                                    {
                                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "baed3c99-4105-49cc-8cc0-05b94c603dc9" + System.Environment.NewLine);
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
                            provider.GetTypeFromDefinition(metadataFile.Metadata, (TypeDefinitionHandle)typeDef.BaseType, 0)(ILNameSyntax.Signature);
                            new System.Action(() =>
                            {
                                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                                if (m.WaitOne(3000))
                                {
                                    try
                                    {
                                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2e8b792a-b555-4459-812e-e05357c8af22" + System.Environment.NewLine);
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
                        case HandleKind.TypeReference:
                            new System.Action(() =>
                            {
                                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                                if (m.WaitOne(3000))
                                {
                                    try
                                    {
                                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "675dc365-63bf-4a4a-94ed-203e617fc8be" + System.Environment.NewLine);
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
                            provider.GetTypeFromReference(metadataFile.Metadata, (TypeReferenceHandle)typeDef.BaseType, 0)(ILNameSyntax.Signature);
                            new System.Action(() =>
                            {
                                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                                if (m.WaitOne(3000))
                                {
                                    try
                                    {
                                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c21b910f-74dd-4d96-b75d-a20af6db7a5f" + System.Environment.NewLine);
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
                        case HandleKind.TypeSpecification:
                            new System.Action(() =>
                            {
                                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                                if (m.WaitOne(3000))
                                {
                                    try
                                    {
                                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "561f1e1d-be5d-471c-807e-fe425c601da9" + System.Environment.NewLine);
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
                            provider.GetTypeFromSpecification(metadataFile.Metadata, new MetadataGenericContext(default(TypeDefinitionHandle), metadataFile.Metadata), (TypeSpecificationHandle)typeDef.BaseType, 0)(ILNameSyntax.Signature);
                            new System.Action(() =>
                            {
                                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                                if (m.WaitOne(3000))
                                {
                                    try
                                    {
                                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "df506713-2edf-4b4f-a65f-2fd1129791f4" + System.Environment.NewLine);
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
                        default:
                            new System.Action(() =>
                            {
                                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                                if (m.WaitOne(3000))
                                {
                                    try
                                    {
                                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b65108d2-0f59-4e57-9e87-61f6ef38c106" + System.Environment.NewLine);
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
                            return null;
                    }
                }
            }

            [ColumnInfo("X8", Kind = ColumnKind.Token)]
            public int FieldList => 0x04000000 | fieldList;

            string? fieldListTooltip;
            public string? FieldListTooltip
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
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "34f355c0-9f7a-4639-abe5-96ffe2e655aa" + System.Environment.NewLine);
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
                    var @field = typeDef.GetFields().FirstOrDefault();
                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "3306ba0d-e954-4b15-bf52-19c2904cc9c6" + System.Environment.NewLine);
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
                    if (@field.IsNil)
                    {
                        new System.Action(() =>
                        {
                            using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                            if (m.WaitOne(3000))
                            {
                                try
                                {
                                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "43fa3aa4-5831-48ce-812f-e75948a03c8c" + System.Environment.NewLine);
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
                        return "(type has no fields; the stored value is the start of its empty field list: the next type's first field row, or one past the end of the Field table)";
                    }

                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ea38abc9-ad6f-46c7-af41-00a6e544ab32" + System.Environment.NewLine);
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
                    return GenerateTooltip(ref fieldListTooltip, metadataFile, @field);
                }
            }

            [ColumnInfo("X8", Kind = ColumnKind.Token)]
            public int MethodList => 0x06000000 | methodList;

            string? methodListTooltip;
            public string? MethodListTooltip
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
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c93a9c04-6fa3-46b0-bf40-943b34c1c5cf" + System.Environment.NewLine);
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
                    var method = typeDef.GetMethods().FirstOrDefault();
                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "7d998dbc-4ffd-4d27-bedb-f643be033977" + System.Environment.NewLine);
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
                    if (method.IsNil)
                    {
                        new System.Action(() =>
                        {
                            using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                            if (m.WaitOne(3000))
                            {
                                try
                                {
                                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "37809dde-9467-4ed6-b9c3-3e570147d627" + System.Environment.NewLine);
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
                        return "(type has no methods; the stored value is the start of its empty method list: the next type's first method row, or one past the end of the MethodDef table)";
                    }

                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c5e97088-da90-4502-8f7d-4e0e53a87746" + System.Environment.NewLine);
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
                    return GenerateTooltip(ref methodListTooltip, metadataFile, method);
                }
            }

            readonly int fieldList;
            readonly int methodList;
            public TypeDefEntry(MetadataFile metadataFile, TypeDefinitionHandle handle, int fieldList, int methodList)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "12cac9bb-fa15-468b-a26f-1f21f73e98c8" + System.Environment.NewLine);
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
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "1b55f0fc-bd9f-4852-98ab-7d987e5ceaa2" + System.Environment.NewLine);
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
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "797fce6a-b1ee-4865-8e98-1f2c91334a88" + System.Environment.NewLine);
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
                this.fieldList = fieldList;
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ab168fac-1fc6-40df-81a4-ac13a16f3e16" + System.Environment.NewLine);
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
                this.methodList = methodList;
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "0183bc5d-07c3-426b-86dd-fcb8fec42c16" + System.Environment.NewLine);
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
                typeDef = metadataFile.Metadata.GetTypeDefinition(handle);
            }
        }
    }
}