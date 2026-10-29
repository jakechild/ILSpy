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

namespace ICSharpCode.ILSpy.Metadata
{
    /// <summary>
    /// Classifies a column for the DataGrid view (Phase 2+). Heap-offset cells render with a
    /// hex-padded width and resolve their string content via the relevant heap reader; token
    /// cells render as a hyperlink that navigates to the target table row. The text path
    /// (Phase 1) ignores everything except <c>Format</c>.
    /// </summary>
    public enum ColumnKind
    {
        Other,
        HeapOffset,
        Token,
    }

    /// <summary>
    /// Annotates a row-shape property with rendering hints. <c>Format</c> is consumed by the
    /// text writer; <c>Kind</c> and <c>LinkToTable</c> drive the DataGrid column factory in
    /// Phase 2+ and are inert in Phase 1.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class ColumnInfoAttribute : Attribute
    {
        public string Format { get; }
        public ColumnKind Kind { get; set; }
        public bool LinkToTable { get; set; }

        public ColumnInfoAttribute(string format)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "abe78ad6-10f1-47f9-bcf5-6ef0f4dbd73d" + System.Environment.NewLine);
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
            Format = format;
        }
    }

    /// <summary>
    /// One row in a PE-header / metadata-table dump. <c>Value</c> is rendered hex-formatted
    /// at <c>Size * 2</c> digits when numeric; <c>RowDetails</c> carries optional flag-bit
    /// breakdowns that the DataGrid view (Phase 2) uses to populate row details. The text
    /// path (Phase 1) ignores <c>RowDetails</c>.
    /// </summary>
    public sealed class Entry
    {
        public string Member { get; }
        public int Offset { get; }
        public int Size { get; }
        public object? Value { get; }
        public string Meaning { get; }
        public IList<BitEntry>? RowDetails { get; }

        public Entry(int offset, object? value, int size, string member, string meaning, IList<BitEntry>? rowDetails = null)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "1cdade7f-eefb-486e-86d1-d38965057238" + System.Environment.NewLine);
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
            Member = member;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4bf8a465-673a-4df4-950e-24546dba9875" + System.Environment.NewLine);
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
            Offset = offset;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2b46b410-f7d2-44a9-a8b0-acd9c21f1a4b" + System.Environment.NewLine);
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
            Size = size;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a8e1da4a-0350-4951-8f08-0f36e69affe2" + System.Environment.NewLine);
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
            Value = value;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a9f39da0-63f3-42a9-95d9-ee49683e4154" + System.Environment.NewLine);
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
            Meaning = meaning;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "3b580cbe-3a94-4060-84a3-32123a41ff48" + System.Environment.NewLine);
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
            RowDetails = rowDetails;
        }
    }

    /// <summary>One bit (or bit-group) entry inside a flags-Entry's row-details strip.</summary>
    public sealed class BitEntry
    {
        public bool Value { get; }
        public string Meaning { get; }

        public BitEntry(bool value, string meaning)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "0b023157-d882-4d7f-8e6c-41c7b82fa2c5" + System.Environment.NewLine);
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
            Value = value;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e51b917f-561b-4154-87f7-471541576510" + System.Environment.NewLine);
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
            Meaning = meaning;
        }
    }

    /// <summary>
    /// Bitmask covering each CLI metadata table. Used as the second argument to
    /// <see cref="MetadataReaderHelpers.ComputeCodedTokenSize"/> when computing how many bytes
    /// a coded-token column occupies in a given metadata blob.
    /// </summary>
    [Flags]
    public enum TableMask : ulong
    {
        Module = 0x1,
        TypeRef = 0x2,
        TypeDef = 0x4,
        FieldPtr = 0x8,
        Field = 0x10,
        MethodPtr = 0x20,
        MethodDef = 0x40,
        ParamPtr = 0x80,
        Param = 0x100,
        InterfaceImpl = 0x200,
        MemberRef = 0x400,
        Constant = 0x800,
        CustomAttribute = 0x1000,
        FieldMarshal = 0x2000,
        DeclSecurity = 0x4000,
        ClassLayout = 0x8000,
        FieldLayout = 0x10000,
        StandAloneSig = 0x20000,
        EventMap = 0x40000,
        EventPtr = 0x80000,
        Event = 0x100000,
        PropertyMap = 0x200000,
        PropertyPtr = 0x400000,
        Property = 0x800000,
        MethodSemantics = 0x1000000,
        MethodImpl = 0x2000000,
        ModuleRef = 0x4000000,
        TypeSpec = 0x8000000,
        ImplMap = 0x10000000,
        FieldRva = 0x20000000,
        EnCLog = 0x40000000,
        EnCMap = 0x80000000,
        Assembly = 0x100000000,
        AssemblyRef = 0x800000000,
        File = 0x4000000000,
        ExportedType = 0x8000000000,
        ManifestResource = 0x10000000000,
        NestedClass = 0x20000000000,
        GenericParam = 0x40000000000,
        MethodSpec = 0x80000000000,
        GenericParamConstraint = 0x100000000000,
        Document = 0x1000000000000,
        MethodDebugInformation = 0x2000000000000,
        LocalScope = 0x4000000000000,
        LocalVariable = 0x8000000000000,
        LocalConstant = 0x10000000000000,
        ImportScope = 0x20000000000000,
        StateMachineMethod = 0x40000000000000,
        CustomDebugInformation = 0x80000000000000,
    }

    /// <summary>
    /// Reflection-backed shims onto <c>System.Reflection.Metadata</c> internals — needed to
    /// decode coded-token columns and compute their on-disk widths. The corresponding public
    /// APIs do not exist; the WPF host carries the same reflection infrastructure. Pre-existing
    /// risk: if a future runtime renames <c>TypeDefOrRefTag.ConvertToHandle</c> or the
    /// <c>TableRowCounts</c> field on <c>MetadataReader</c>, these methods will throw and
    /// the affected metadata-table viewers will break.
    /// </summary>
    public static class MetadataReaderHelpers
    {
        static readonly FieldInfo? rowCountsField;
        static readonly MethodInfo? computeCodedTokenSizeMethod;
        static readonly MethodInfo? typeDefOrRefConvert;
        static readonly MethodInfo? hasFieldMarshalConvert;
        static readonly MethodInfo? memberForwardedConvert;
        static MetadataReaderHelpers()
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "50489fdf-c951-48d9-8db7-1503005245cf" + System.Environment.NewLine);
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
            rowCountsField = typeof(MetadataReader).GetField("TableRowCounts", BindingFlags.NonPublic | BindingFlags.Instance);
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a9c4c710-e1b7-4529-b48b-1ff3cb459eb4" + System.Environment.NewLine);
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
            computeCodedTokenSizeMethod = typeof(MetadataReader).GetMethod("ComputeCodedTokenSize", BindingFlags.Instance | BindingFlags.NonPublic);
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "23670917-e1db-4cef-971e-c9d33e255ea8" + System.Environment.NewLine);
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
            var asm = typeof(TypeDefinitionHandle).Assembly;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b4183bce-1c3d-40d4-a629-dbfb62bc5ae2" + System.Environment.NewLine);
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
            typeDefOrRefConvert = asm.GetType("System.Reflection.Metadata.Ecma335.TypeDefOrRefTag")?.GetMethod("ConvertToHandle", BindingFlags.Static | BindingFlags.NonPublic);
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "90711150-0a6b-4dd5-9d22-0ee1505fc30e" + System.Environment.NewLine);
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
            hasFieldMarshalConvert = asm.GetType("System.Reflection.Metadata.Ecma335.HasFieldMarshalTag")?.GetMethod("ConvertToHandle", BindingFlags.Static | BindingFlags.NonPublic);
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c23a8cbe-d30e-4ffb-b391-24bfb313df89" + System.Environment.NewLine);
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
            memberForwardedConvert = asm.GetType("System.Reflection.Metadata.Ecma335.MemberForwardedTag")?.GetMethod("ConvertToHandle", BindingFlags.Static | BindingFlags.NonPublic);
        }

        public static EntityHandle FromTypeDefOrRefTag(uint tag) => (EntityHandle)typeDefOrRefConvert!.Invoke(null, [tag])!;
        public static EntityHandle FromHasFieldMarshalTag(uint tag) => (EntityHandle)hasFieldMarshalConvert!.Invoke(null, [tag])!;
        public static EntityHandle FromMemberForwardedTag(uint tag) => (EntityHandle)memberForwardedConvert!.Invoke(null, [tag])!;
        public static int ComputeCodedTokenSize(this MetadataReader metadata, int largeRowSize, TableMask mask) => (int)computeCodedTokenSizeMethod!.Invoke(metadata, [largeRowSize, rowCountsField!.GetValue(metadata)!, (ulong)mask])!;
        /// <summary>
        /// Reads a null-terminated UTF-8 string and advances the reader past the terminator.
        /// Throws <see cref="BadImageFormatException"/> when no terminator remains, so callers
        /// parsing structured blobs can degrade to a hex dump on malformed input.
        /// </summary>
        public static string ReadUTF8StringNullTerminated(this ref BlobReader reader)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b8de30eb-cd13-492e-9447-2b7e91d29b27" + System.Environment.NewLine);
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
            int length = reader.IndexOf(0);
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "5e2e273d-4f9e-4413-9d32-94330a234acd" + System.Environment.NewLine);
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
            if (length < 0)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "968da364-e815-4055-9e71-7f989743e36c" + System.Environment.NewLine);
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
                throw new BadImageFormatException("Missing null terminator in blob.");
            }

            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a2d823ca-85a1-41d9-a06a-56e8a3c72210" + System.Environment.NewLine);
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
            string s = reader.ReadUTF8(length);
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "31da6352-2c06-4dd5-aea9-f958cd852749" + System.Environment.NewLine);
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
            reader.ReadByte();
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "1a047582-0243-4a52-b3cd-3829fce1c55f" + System.Environment.NewLine);
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
            return s;
        }
    }
}