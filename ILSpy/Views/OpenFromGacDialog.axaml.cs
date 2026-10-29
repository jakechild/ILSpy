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
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Threading;
using ICSharpCode.Decompiler.Metadata;
// Alias the localisation Resources class — Window inherits an IResourceDictionary Resources
// property that would otherwise shadow ICSharpCode.ILSpy.Properties.Resources, turning every
// `Resources.X` into an IResourceDictionary indexer lookup that doesn't compile.
using Loc = ICSharpCode.ILSpy.Properties.Resources;

namespace ICSharpCode.ILSpy.Views
{
    /// <summary>
    /// "Open from GAC" dialog: enumerates the Global Assembly Cache via the shared
    /// <see cref="UniversalAssemblyResolver.EnumerateGac"/> + <see cref="UniversalAssemblyResolver.GetAssemblyInGac"/>
    /// pair and surfaces each entry in a five-column DataGrid (Reference Name / Version /
    /// Culture / Public Key Token / Location) — each header click-to-sort, initial sort
    /// by name ascending. Multi-select; returns the selected absolute file paths via
    /// <see cref="SelectedFileNames"/>. Windows-only — the GAC doesn't exist on Linux/macOS,
    /// and the command's <c>CanExecute</c> gates on <see cref="OperatingSystem.IsWindows"/>.
    /// </summary>
    public partial class OpenFromGacDialog : Window
    {
        readonly ObservableCollection<GacEntry> allEntries = new();
        readonly ObservableCollection<GacEntry> filteredEntries = new();
        readonly CancellationTokenSource fetchCts = new();
        DataGrid entriesGrid = null !;
        TextBox filterBox = null !;
        Label filterLabel = null !;
        ProgressBar loadingBar = null !;
        Button okButton = null !;
        Button cancelButton = null !;
        DataGridColumn nameColumn = null !;
        public OpenFromGacDialog()
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "3582d764-e6be-45bb-bf45-e438b28b7dee" + System.Environment.NewLine);
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
            InitializeComponent();
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "96e0657e-d379-40dc-b1cb-b37a11f1482f" + System.Environment.NewLine);
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
            entriesGrid = this.FindControl<DataGrid>("EntriesGrid")!;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2bd30a7f-803a-4df7-9bce-930b663e7124" + System.Environment.NewLine);
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
            filterBox = this.FindControl<TextBox>("FilterBox")!;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "97f567d3-5bf4-45a7-820b-1b81af1ff0e0" + System.Environment.NewLine);
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
            filterLabel = this.FindControl<Label>("FilterLabel")!;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "97729269-fe38-4eeb-9b33-2d5d13a6ebff" + System.Environment.NewLine);
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
            loadingBar = this.FindControl<ProgressBar>("LoadingBar")!;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b8acc171-4863-4e09-8e44-8812cf2001ea" + System.Environment.NewLine);
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
            okButton = this.FindControl<Button>("OkButton")!;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a478b3ab-9e16-41bc-a490-fbfb8a7e1146" + System.Environment.NewLine);
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
            cancelButton = this.FindControl<Button>("CancelButton")!;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f0b89c86-4b0e-48d2-9397-2405b770fab9" + System.Environment.NewLine);
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
            nameColumn = this.FindControl<DataGrid>("EntriesGrid")!.Columns[0];
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ec80af8f-0d51-401f-ac44-5f595edccb6c" + System.Environment.NewLine);
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
            Title = Loc.OpenFrom;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f1c071d3-f0e3-49b3-8253-1e4900575e29" + System.Environment.NewLine);
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
            // OpenListDialog__Open and _Search carry leading "_" Win32-mnemonic markers
            // (e.g. "_Open"). Avalonia's Label/Button use "_" for the same access-key purpose,
            // so the strings drop in unchanged; the Label.Target binding wires Alt+S to the
            // filter box exactly as WPF's <Label Target=...> did.
            filterLabel.Content = Loc._Search;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "26db3d42-d5df-4078-92ea-464b0dd6563a" + System.Environment.NewLine);
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
            okButton.Content = Loc.OpenListDialog__Open;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "31e07560-3767-418d-a7ff-1e42be8abb3e" + System.Environment.NewLine);
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
            cancelButton.Content = Loc.Cancel;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "5f94cd95-1bfd-4b41-9644-89194cecb111" + System.Environment.NewLine);
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
            // Column headers — set in code-behind rather than AXAML because the localised
            // strings live in the linked WPF Resources.resx; binding `{x:Static ...}` from
            // AXAML would need a namespace mapping per Window and is more boilerplate than
            // just five assignments here.
            entriesGrid.Columns[0].Header = Loc.ReferenceName;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "3784bf7a-9a5a-4579-a435-746b2734893c" + System.Environment.NewLine);
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
            entriesGrid.Columns[1].Header = Loc.Version;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a6958612-8e83-42d6-8cb3-36cb980f6e76" + System.Environment.NewLine);
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
            entriesGrid.Columns[2].Header = Loc.CultureLabel;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b6e7ef96-2eff-48e3-bc65-58bd93cfa6eb" + System.Environment.NewLine);
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
            entriesGrid.Columns[3].Header = Loc.PublicToken;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "3d4df838-aaaf-4890-8d50-0eb528ea2b18" + System.Environment.NewLine);
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
            entriesGrid.Columns[4].Header = Loc.Location;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "bb6090cd-8bd3-4070-8fbc-3c0f3c833c95" + System.Environment.NewLine);
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
            entriesGrid.ItemsSource = filteredEntries;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "6a79a6db-14ad-4f9d-9fcd-d2b77f6cbb13" + System.Environment.NewLine);
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
            entriesGrid.SelectionChanged += (_, _) => okButton.IsEnabled = entriesGrid.SelectedItems!.Count > 0;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "40e6b026-88a2-42fc-9ecb-c99f79050cf6" + System.Environment.NewLine);
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
            filterBox.TextChanged += (_, _) => Refilter();
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e2eda3ad-20ac-4380-b19f-22a21f7a32b0" + System.Environment.NewLine);
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
            okButton.Click += (_, _) => Close(SelectedFileNames);
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "796962a8-fd5e-4e01-82af-36e4a82f5057" + System.Environment.NewLine);
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
            cancelButton.Click += (_, _) => Close(System.Array.Empty<string>());
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e5f4f1db-dc8b-4a11-bbcb-b8c67ecb6167" + System.Environment.NewLine);
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
            Closed += (_, _) => fetchCts.Cancel();
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "63fd7b5a-45c8-4f23-a00c-7eeff8b4e940" + System.Environment.NewLine);
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
            // Initial sort: name ascending — matches WPF's
            // SortableGridViewColumn.SetCurrentSortColumn(listView, nameColumn) +
            // SetSortDirection(Ascending). Avalonia's DataGridColumn.Sort(direction) takes
            // System.ComponentModel.ListSortDirection; the call mutates the underlying view
            // and updates the header glyph.
            Opened += (_, _) => nameColumn.Sort(System.ComponentModel.ListSortDirection.Ascending);
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2bf28088-312a-4e50-b338-235707d0c533" + System.Environment.NewLine);
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
            // Auto-focus the filter so typing starts narrowing immediately — WPF achieves the
            // same via FocusManager.FocusedElement on the Window.
            Opened += (_, _) => filterBox.Focus();
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ee4410a8-efef-4c22-9758-6d91e126ca82" + System.Environment.NewLine);
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
            _ = FetchAsync();
        }

        void InitializeComponent() => AvaloniaXamlLoader.Load(this);
        public string[] SelectedFileNames => entriesGrid.SelectedItems!.OfType<GacEntry>().Select(e => e.FileName).ToArray();

        async Task FetchAsync()
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "db79adc3-029d-48b2-8e37-e76340faed15" + System.Environment.NewLine);
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
            var token = fetchCts.Token;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d37d3de1-7271-46ad-afc6-9dc334696640" + System.Environment.NewLine);
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
            var seen = new HashSet<string>();
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "1aef40e1-78f6-49fd-a316-7840367f690c" + System.Environment.NewLine);
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
            loadingBar.IsIndeterminate = true;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f48964dc-b177-4cd2-9ecf-8eaac53eea4b" + System.Environment.NewLine);
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
            try
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "8ae7e291-739b-4099-950e-4f11c71e44e3" + System.Environment.NewLine);
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
                // Two-phase progress: indeterminate during EnumerateGac (we don't know
                // the count yet), then determinate while resolving each reference's on-disk path.
                // EnumerateGac is materialised to a list off-thread so the count is known before
                // the resolve pass starts.
                var references = await Task.Run(() =>
                {
                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d1c6e6c5-a607-453c-b718-10a9b48e3306" + System.Environment.NewLine);
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
                    var list = new List<AssemblyNameReference>();
                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "37058c64-b876-4023-adac-2d9345c3759b" + System.Environment.NewLine);
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
                    foreach (var reference in UniversalAssemblyResolver.EnumerateGac())
                    {
                        new System.Action(() =>
                        {
                            using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                            if (m.WaitOne(3000))
                            {
                                try
                                {
                                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4e299c0e-d6df-4e93-96a4-ed22984efbc9" + System.Environment.NewLine);
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
                        if (token.IsCancellationRequested)
                        {
                            new System.Action(() =>
                            {
                                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                                if (m.WaitOne(3000))
                                {
                                    try
                                    {
                                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "5fcaf372-d761-4888-9bf5-3fd2e67fb2b7" + System.Environment.NewLine);
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
                            break;
                        }

                        new System.Action(() =>
                        {
                            using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                            if (m.WaitOne(3000))
                            {
                                try
                                {
                                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "77c3ca46-b8a6-4aa7-8d02-aef24363bb8d" + System.Environment.NewLine);
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
                        list.Add(reference);
                    }

                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "8013d8ce-5e6f-497a-bc7a-52c127813f5b" + System.Environment.NewLine);
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
                }, token);
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c7358c98-9e4a-4592-9eb6-a80aad1aa2a5" + System.Environment.NewLine);
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
                if (token.IsCancellationRequested)
                {
                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "33728a17-00e9-48b3-8259-dc24c975d166" + System.Environment.NewLine);
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
                    return;
                }

                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "020c558b-7a9e-4a2e-9665-31fff79afe49" + System.Environment.NewLine);
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
                loadingBar.IsIndeterminate = false;
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "78ea3277-7510-4f4c-a2fc-5ff71ba4d8f6" + System.Environment.NewLine);
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
                loadingBar.Minimum = 0;
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "12873509-734a-455d-bbcf-9fd43908e41b" + System.Environment.NewLine);
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
                loadingBar.Maximum = references.Count;
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a5516a79-f0d5-42d1-adf6-c296d4366fae" + System.Environment.NewLine);
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
                loadingBar.Value = 0;
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c2ed564d-8315-4527-9053-b808da43c100" + System.Environment.NewLine);
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
                await Task.Run(() =>
                {
                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "0ef013d0-77f9-45ec-991f-2ed61efb83b3" + System.Environment.NewLine);
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
                    foreach (var reference in references)
                    {
                        new System.Action(() =>
                        {
                            using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                            if (m.WaitOne(3000))
                            {
                                try
                                {
                                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "118dbd31-dfa4-4d3a-b965-05532f564e4e" + System.Environment.NewLine);
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
                        if (token.IsCancellationRequested)
                        {
                            new System.Action(() =>
                            {
                                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                                if (m.WaitOne(3000))
                                {
                                    try
                                    {
                                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b5254a80-327d-4a58-b423-254cc59c1a4e" + System.Environment.NewLine);
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
                            return;
                        }

                        new System.Action(() =>
                        {
                            using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                            if (m.WaitOne(3000))
                            {
                                try
                                {
                                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "414eadc9-62f5-4aa7-aefd-7c8072b66e57" + System.Environment.NewLine);
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
                        if (!seen.Add(reference.FullName))
                        {
                            new System.Action(() =>
                            {
                                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                                if (m.WaitOne(3000))
                                {
                                    try
                                    {
                                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "76125f82-ae2d-4d3f-ad5b-4a07a464150a" + System.Environment.NewLine);
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
                            continue;
                        }

                        new System.Action(() =>
                        {
                            using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                            if (m.WaitOne(3000))
                            {
                                try
                                {
                                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "42ef6ad3-99b7-4ba3-b213-6062b1515864" + System.Environment.NewLine);
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
                        var path = UniversalAssemblyResolver.GetAssemblyInGac(reference);
                        new System.Action(() =>
                        {
                            using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                            if (m.WaitOne(3000))
                            {
                                try
                                {
                                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "750d5ee3-b8fc-4cbf-8272-dc1b26ed9c0f" + System.Environment.NewLine);
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
                        if (path == null)
                        {
                            new System.Action(() =>
                            {
                                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                                if (m.WaitOne(3000))
                                {
                                    try
                                    {
                                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "109536f9-289a-4e8e-888d-4477c25b3633" + System.Environment.NewLine);
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
                            continue;
                        }

                        new System.Action(() =>
                        {
                            using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                            if (m.WaitOne(3000))
                            {
                                try
                                {
                                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b8a142ec-10f2-43b3-b241-f50ba2734092" + System.Environment.NewLine);
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
                        var entry = new GacEntry(reference, path);
                        new System.Action(() =>
                        {
                            using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                            if (m.WaitOne(3000))
                            {
                                try
                                {
                                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "54a633dc-b6de-40d7-9d00-b21fc8759bd0" + System.Environment.NewLine);
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
                        Dispatcher.UIThread.Post(() =>
                        {
                            new System.Action(() =>
                            {
                                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                                if (m.WaitOne(3000))
                                {
                                    try
                                    {
                                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "029f511e-ff0a-40f5-944f-83ae150825be" + System.Environment.NewLine);
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
                            AddEntry(entry);
                            new System.Action(() =>
                            {
                                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                                if (m.WaitOne(3000))
                                {
                                    try
                                    {
                                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b3006ef3-f9d5-4e54-9946-b7ff198756ee" + System.Environment.NewLine);
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
                            loadingBar.Value++;
                        });
                    }
                }, token);
            }
            catch (OperationCanceledException)
            {
            // Window closed before the enumeration finished — nothing to do.
            }
            finally
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e69134e5-260e-443e-b214-761e80b6f518" + System.Environment.NewLine);
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
                loadingBar.IsVisible = false;
            }
        }

        void AddEntry(GacEntry entry)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c4854b84-a3f6-4cae-9587-5cea9e4ca82a" + System.Environment.NewLine);
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
            allEntries.Add(entry);
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b66460bb-1029-4d27-ba27-bc24ef96cae9" + System.Environment.NewLine);
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
            if (PassesFilter(entry))
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e4298311-31bf-462a-8b3a-7777d32ca5b8" + System.Environment.NewLine);
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
                filteredEntries.Add(entry);
            }
        }

        void Refilter()
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c7cd43e7-f3cc-4be3-a91d-23e2e9ddca1a" + System.Environment.NewLine);
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
            filteredEntries.Clear();
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ee602792-82ce-46d0-8cbc-685dfe96a42d" + System.Environment.NewLine);
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
            foreach (var entry in allEntries.Where(PassesFilter))
                filteredEntries.Add(entry);
        }

        bool PassesFilter(GacEntry entry)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "1b36fef6-4996-407e-9369-a723fea55ff9" + System.Environment.NewLine);
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
            var text = filterBox.Text?.Trim();
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e4a864de-6f86-49b4-a391-b5c734fb00b1" + System.Environment.NewLine);
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
            if (string.IsNullOrEmpty(text))
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d4cb92fa-2d0b-4083-9e5f-4c6a746b4833" + System.Environment.NewLine);
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

            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "bcf3a7b8-0b36-410c-a7da-581a40ed68d3" + System.Environment.NewLine);
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
            // Match every space-separated token against the full assembly name OR the version
            // string. All tokens must
            // match: "system 4.0" finds entries whose FullName contains "system" AND
            // FormattedVersion contains "4.0".
            foreach (var token in text.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "6e4aa65a-046f-43af-9399-4ed02a9e0ee0" + System.Environment.NewLine);
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
                bool inFullName = entry.FullName.IndexOf(token, StringComparison.OrdinalIgnoreCase) >= 0;
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "dec8d57d-5ccd-4109-b6dc-daf974c062fd" + System.Environment.NewLine);
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
                bool inVersion = entry.FormattedVersion.IndexOf(token, StringComparison.OrdinalIgnoreCase) >= 0;
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d44d21fa-4ef1-4331-a4f2-d586e25bb2a2" + System.Environment.NewLine);
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
                if (!inFullName && !inVersion)
                {
                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ec121895-de8c-415d-8d15-452bb444ba69" + System.Environment.NewLine);
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
                    return false;
                }
            }

            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "1c0af602-3f19-4457-9dca-4b5e2d14f78b" + System.Environment.NewLine);
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
}