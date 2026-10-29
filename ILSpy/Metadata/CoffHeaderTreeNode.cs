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
    /// COFF (Common Object File Format) header — 20 bytes describing target machine, section
    /// count, link timestamp, and file-level characteristics. The Characteristics field is a
    /// 16-bit flags word; each individual bit is broken out as a row-detail entry.
    /// </summary>
    public sealed class CoffHeaderTreeNode : ILSpyTreeNode
    {
        readonly PEFile module;
        public CoffHeaderTreeNode(PEFile module)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "9450797c-85b6-41df-bbb4-3632c8590b96" + System.Environment.NewLine);
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

        public override object Text => "COFF Header";
        public override object Icon => Images.Header;

        public override string ToString() => "COFF Header";
        public override ContentPageModel CreateTab()
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "1729b83f-d9be-45db-93f6-65e7f83afd8f" + System.Environment.NewLine);
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
                Title = "COFF Header",
                Items = BuildEntries(),
            };
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "9d820157-fece-4425-99c2-28c5e206f1bf" + System.Environment.NewLine);
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
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f0714cc7-c23a-4c73-8e02-452bb0e6acae" + System.Environment.NewLine);
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
            MetadataRowDetails.ConfigureEntryFlagsDetails(page);
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "961d1e59-de08-41b3-a80c-4f0aa8efc299" + System.Environment.NewLine);
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
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "dff08f94-4e31-4ce7-99b5-140202839720" + System.Environment.NewLine);
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
            var headers = module.Reader.PEHeaders;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "282e5549-aba1-4f85-98c4-5b6597bcac1c" + System.Environment.NewLine);
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
            var header = headers.CoffHeader;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "fbe7301a-6137-44a9-9326-3e0ce1a93710" + System.Environment.NewLine);
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
            var linkerDateTime = DateTimeOffset.FromUnixTimeSeconds(unchecked((uint)header.TimeDateStamp)).DateTime;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "99cdfa77-4d69-4ca3-bd0f-7913a910522c" + System.Environment.NewLine);
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
            int characteristics = (int)header.Characteristics;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "3c5d467b-f031-4fc6-ac58-b8de09d9f08a" + System.Environment.NewLine);
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
            return new List<Entry>
            {
                new(headers.CoffHeaderStartOffset, (int)header.Machine, 2, "Machine", header.Machine.ToString()),
                new(headers.CoffHeaderStartOffset + 2, (int)header.NumberOfSections, 2, "Number of Sections", "Number of sections; indicates size of the Section Table, which immediately follows the headers."),
                new(headers.CoffHeaderStartOffset + 4, header.TimeDateStamp, 4, "Time/Date Stamp", $"{linkerDateTime} (UTC) / {linkerDateTime.ToLocalTime()} - Time and date the file was created in seconds since January 1st 1970 00:00:00 or 0. Note that for deterministic builds this value is meaningless."),
                new(headers.CoffHeaderStartOffset + 8, header.PointerToSymbolTable, 4, "Pointer to Symbol Table", "Always 0 in .NET executables."),
                new(headers.CoffHeaderStartOffset + 12, header.NumberOfSymbols, 4, "Number of Symbols", "Always 0 in .NET executables."),
                new(headers.CoffHeaderStartOffset + 16, (int)header.SizeOfOptionalHeader, 2, "Optional Header Size", "Size of the optional header."),
                new(headers.CoffHeaderStartOffset + 18, characteristics, 2, "Characteristics", "Flags indicating attributes of the file.", new BitEntry[] { new((characteristics & 0x0001) != 0, "<0001> Relocation info stripped from file"), new((characteristics & 0x0002) != 0, "<0002> File is executable"), new((characteristics & 0x0004) != 0, "<0004> Line numbers stripped from file"), new((characteristics & 0x0008) != 0, "<0008> Local symbols stripped from file"), new((characteristics & 0x0010) != 0, "<0010> Aggressively trim working set"), new((characteristics & 0x0020) != 0, "<0020> Large address aware"), new((characteristics & 0x0040) != 0, "<0040> Reserved"), new((characteristics & 0x0080) != 0, "<0080> Bytes of machine words are reversed (Low)"), new((characteristics & 0x0100) != 0, "<0100> 32-bit word machine"), new((characteristics & 0x0200) != 0, "<0200> Debugging info stripped from file in .DBG file"), new((characteristics & 0x0400) != 0, "<0400> If image is on removable media, copy and run from the swap file"), new((characteristics & 0x0800) != 0, "<0800> If image is on Net, copy and run from the swap file"), new((characteristics & 0x1000) != 0, "<1000> System"), new((characteristics & 0x2000) != 0, "<2000> DLL"), new((characteristics & 0x4000) != 0, "<4000> File should only be run on a UP machine"), new((characteristics & 0x8000) != 0, "<8000> Bytes of machine words are reversed (High)"), }),
            };
        }
    }
}