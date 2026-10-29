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
using ICSharpCode.Decompiler.Metadata;
using ICSharpCode.ILSpy.ViewModels;

namespace ICSharpCode.ILSpy.Metadata
{
    /// <summary>
    /// View of #Strings — the heap that holds every UTF-8 type/member/namespace name
    /// referenced by the metadata tables. Lazy materialisation: handles are walked on
    /// demand via <see cref="MetadataReader.GetNextHandle(StringHandle)"/> the first time a
    /// caller asks for the count or a preview row.
    /// </summary>
    public sealed class StringHeapTreeNode : MetadataHeapTreeNode<StringHeapTreeNode.StringHeapEntry>
    {
        public StringHeapTreeNode(MetadataFile metadataFile) : base(HandleKind.String, metadataFile)
        {
        }

        protected override string HeapName => "String Heap";

        protected override void LoadEntries(MetadataReader metadata, List<StringHeapEntry> list)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d6fb9541-9402-4a62-b0e2-1ed57cb5b19a" + System.Environment.NewLine);
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
            WalkHeap(list, MetadataTokens.StringHandle(0), h => new StringHeapEntry(metadata, h), metadata.GetNextHandle, h => h.IsNil);
        }

        public sealed class StringHeapEntry
        {
            readonly MetadataReader metadata;
            readonly StringHandle handle;
            [ColumnInfo("X8")]
            public int Offset => metadata.GetHeapOffset(handle);
            public int Length => metadata.GetString(handle).Length;
            public string Value => metadata.GetString(handle);

            public StringHeapEntry(MetadataReader metadata, StringHandle handle)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ea61b4be-6aa9-471d-a7c7-46d842a8f3b3" + System.Environment.NewLine);
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
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4a61f60a-7236-4383-9478-4f96e6a41635" + System.Environment.NewLine);
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
            }
        }
    }
}