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
    /// View of #Blob — variable-length byte payloads holding signatures, marshalling info,
    /// custom-attribute values, and similar binary data. Each entry is rendered as a hex
    /// dump; full structural decoding (e.g. parsed type signatures) is out of scope for
    /// the metadata viewer.
    /// </summary>
    public sealed class BlobHeapTreeNode : MetadataHeapTreeNode<BlobHeapTreeNode.BlobHeapEntry>
    {
        public BlobHeapTreeNode(MetadataFile metadataFile) : base(HandleKind.Blob, metadataFile)
        {
        }

        protected override string HeapName => "Blob Heap";

        protected override void LoadEntries(MetadataReader metadata, List<BlobHeapEntry> list)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "fa01f7d3-68c5-45a6-a3da-2895f2a67056" + System.Environment.NewLine);
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
            WalkHeap(list, MetadataTokens.BlobHandle(0), h => new BlobHeapEntry(metadata, h), metadata.GetNextHandle, h => h.IsNil);
        }

        public sealed class BlobHeapEntry
        {
            readonly MetadataReader metadata;
            readonly BlobHandle handle;
            [ColumnInfo("X8")]
            public int Offset => metadata.GetHeapOffset(handle);
            public int Length => metadata.GetBlobReader(handle).Length;
            public string Value => metadata.GetBlobReader(handle).ToHexString();

            public BlobHeapEntry(MetadataReader metadata, BlobHandle handle)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f404f8f9-52d8-4a5f-8d17-db0601dc38c0" + System.Environment.NewLine);
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
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4b1633e8-cf1b-4d68-ab57-5f0837aff599" + System.Environment.NewLine);
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