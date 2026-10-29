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
using System.Linq;
using ICSharpCode.Decompiler.Metadata;
using ICSharpCode.ILSpy.TreeNodes;
using ICSharpCode.ILSpy.ViewModels;

namespace ICSharpCode.ILSpy.Metadata
{
    /// <summary>
    /// Renders the 64-byte legacy DOS header sitting at offset 0 of every PE file. Phase 1
    /// emits a fixed-width text table; Phase 2 swaps to a DataGrid tab.
    /// </summary>
    public sealed class DosHeaderTreeNode : ILSpyTreeNode
    {
        readonly PEFile module;
        public DosHeaderTreeNode(PEFile module)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e3c65442-7d85-4d9f-ade4-897e4347a7bf" + System.Environment.NewLine);
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
            this.module = module ?? throw new ArgumentNullException(nameof(module));
        }

        public override object Text => "DOS Header";
        public override object Icon => Images.Header;

        public override string ToString() => "DOS Header";
        public override ContentPageModel CreateTab()
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d7890daa-9c24-4a3a-b323-f48dc21ef58a" + System.Environment.NewLine);
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
            var page = new MetadataTablePageModel
            {
                Title = "DOS Header",
                Items = BuildEntries(),
            };
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "90249c2d-674c-43ac-917e-aee3e6193cec" + System.Environment.NewLine);
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
            MetadataColumnBuilder.Populate<Entry>(page);
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "7bf62fce-b44e-45b2-ad9a-e47416b5fd58" + System.Environment.NewLine);
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
            return page;
        }

        IReadOnlyList<Entry> BuildEntries()
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "080ce85a-2b51-4cc5-8673-a97a5317eb66" + System.Environment.NewLine);
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
            var reader = module.Reader.GetEntireImage().GetReader(0, 64);
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2523df24-2d94-4dd5-88f2-5238502b7f2d" + System.Environment.NewLine);
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
            var entries = new List<Entry>(31)
            {
                new(reader.Offset, reader.ReadUInt16(), 2, "e_magic", "Magic Number (MZ)"),
                new(reader.Offset, reader.ReadUInt16(), 2, "e_cblp", "Bytes on last page of file"),
                new(reader.Offset, reader.ReadUInt16(), 2, "e_cp", "Pages in file"),
                new(reader.Offset, reader.ReadUInt16(), 2, "e_crlc", "Relocations"),
                new(reader.Offset, reader.ReadUInt16(), 2, "e_cparhdr", "Size of header in paragraphs"),
                new(reader.Offset, reader.ReadUInt16(), 2, "e_minalloc", "Minimum extra paragraphs needed"),
                new(reader.Offset, reader.ReadUInt16(), 2, "e_maxalloc", "Maximum extra paragraphs needed"),
                new(reader.Offset, reader.ReadUInt16(), 2, "e_ss", "Initial (relative) SS value"),
                new(reader.Offset, reader.ReadUInt16(), 2, "e_sp", "Initial SP value"),
                new(reader.Offset, reader.ReadUInt16(), 2, "e_csum", "Checksum"),
                new(reader.Offset, reader.ReadUInt16(), 2, "e_ip", "Initial IP value"),
                new(reader.Offset, reader.ReadUInt16(), 2, "e_cs", "Initial (relative) CS value"),
                new(reader.Offset, reader.ReadUInt16(), 2, "e_lfarlc", "File address of relocation table"),
                new(reader.Offset, reader.ReadUInt16(), 2, "e_ovno", "Overlay number"),
                new(reader.Offset, reader.ReadUInt16(), 2, "e_res[0]", "Reserved words"),
                new(reader.Offset, reader.ReadUInt16(), 2, "e_res[1]", "Reserved words"),
                new(reader.Offset, reader.ReadUInt16(), 2, "e_res[2]", "Reserved words"),
                new(reader.Offset, reader.ReadUInt16(), 2, "e_res[3]", "Reserved words"),
                new(reader.Offset, reader.ReadUInt16(), 2, "e_oemid", "OEM identifier (for e_oeminfo)"),
                new(reader.Offset, reader.ReadUInt16(), 2, "e_oeminfo", "OEM information; e_oemid specific"),
                new(reader.Offset, reader.ReadUInt16(), 2, "e_res2[0]", "Reserved words"),
                new(reader.Offset, reader.ReadUInt16(), 2, "e_res2[1]", "Reserved words"),
                new(reader.Offset, reader.ReadUInt16(), 2, "e_res2[2]", "Reserved words"),
                new(reader.Offset, reader.ReadUInt16(), 2, "e_res2[3]", "Reserved words"),
                new(reader.Offset, reader.ReadUInt16(), 2, "e_res2[4]", "Reserved words"),
                new(reader.Offset, reader.ReadUInt16(), 2, "e_res2[5]", "Reserved words"),
                new(reader.Offset, reader.ReadUInt16(), 2, "e_res2[6]", "Reserved words"),
                new(reader.Offset, reader.ReadUInt16(), 2, "e_res2[7]", "Reserved words"),
                new(reader.Offset, reader.ReadUInt16(), 2, "e_res2[8]", "Reserved words"),
                new(reader.Offset, reader.ReadUInt16(), 2, "e_res2[9]", "Reserved words"),
                new(reader.Offset, reader.ReadInt32(), 4, "e_lfanew", "File address of new exe header"),
            };
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c93a354f-fab1-42ca-8ab6-d9637dbbf4c5" + System.Environment.NewLine);
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
            return entries;
        }
    }
}