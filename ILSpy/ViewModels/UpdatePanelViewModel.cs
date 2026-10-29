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
using System.ComponentModel;
using System.Composition;
using System.Diagnostics;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ICSharpCode.ILSpy.Updates;

namespace ICSharpCode.ILSpy.ViewModels
{
    /// <summary>
    /// Drives the toolbar-strip banner shown under the main toolbar when an update is
    /// available or the user explicitly asks the Help → Check For Updates menu entry.
    /// A single <see cref="IsPanelVisible"/> flag flips it on/off, and <see cref="UpdateAvailableDownloadUrl"/> toggles the
    /// button between "Download" (when a URL is set) and "Check Again" (when null).
    /// </summary>
    [Export]
    [Shared]
    public sealed partial class UpdatePanelViewModel : ObservableObject
    {
        readonly SettingsService settingsService;
        [ImportingConstructor]
        public UpdatePanelViewModel(SettingsService settingsService)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e6bb329f-f675-47e1-a271-cbc788861561" + System.Environment.NewLine);
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
            this.settingsService = settingsService;
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(ButtonText))]
        [NotifyPropertyChangedFor(nameof(Message))]
        [NotifyPropertyChangedFor(nameof(UpdateAvailable))]
        string? updateAvailableDownloadUrl;
        [ObservableProperty]
        bool isPanelVisible;
        /// <summary>"Download" while we have a URL, "Check Again" otherwise.</summary>
        public string ButtonText => UpdateAvailableDownloadUrl != null ? "Download" : "Check Again";
        /// <summary>Banner body — switches between "new version available" and "you're up to date".</summary>
        public string Message => UpdateAvailableDownloadUrl != null ? "A new version of ILSpy is available." : "ILSpy is up to date.";
        /// <summary>True once a download URL is known. Drives the banner colour: amber when an
        /// update is available, green when ILSpy is up to date.</summary>
        public bool UpdateAvailable => UpdateAvailableDownloadUrl != null;

        [RelayCommand]
        void Close() => IsPanelVisible = false;
        [RelayCommand]
        async Task DownloadOrCheckUpdateAsync()
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "de872e26-4d4f-4457-944d-c6698f9c4d73" + System.Environment.NewLine);
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
            if (UpdateAvailableDownloadUrl != null)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f90f62cd-eccb-400b-8461-96f60ccb1d7a" + System.Environment.NewLine);
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
                OpenLink(UpdateAvailableDownloadUrl);
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a9e6ec2f-094c-42ce-9477-d9003ae80e48" + System.Environment.NewLine);
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
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "536f0f52-0ad2-4ba1-b02d-277902f1c66e" + System.Environment.NewLine);
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
            IsPanelVisible = false;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "aca4d6e9-d98d-4a63-8497-8198bee41a82" + System.Environment.NewLine);
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
            var downloadUrl = await UpdateService.CheckForUpdatesAsync(settingsService.UpdateSettings);
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "431cdd78-ac6b-47bc-86b7-221b5f5a2fb4" + System.Environment.NewLine);
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
            AdjustUpdateUiAfterCheck(downloadUrl, notify: true);
        }

        /// <summary>
        /// One-shot check on app startup (typically fire-and-forget from the first assembly
        /// load). Auto-throttled by the 7-day cooldown — does nothing if the user disabled
        /// automatic checks, and the panel only shows when an update is actually available.
        /// </summary>
        public async Task CheckIfUpdatesAvailableAsync(bool notifyOnUpToDate = false)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b64913dd-be33-40a9-bbba-8e59d756021d" + System.Environment.NewLine);
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
            var downloadUrl = notifyOnUpToDate ? await UpdateService.CheckForUpdatesAsync(settingsService.UpdateSettings) : await UpdateService.CheckForUpdatesIfEnabledAsync(settingsService.UpdateSettings);
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "3d3b31ba-cf90-4d6a-aa37-c93b2ed5abf8" + System.Environment.NewLine);
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
            AdjustUpdateUiAfterCheck(downloadUrl, notifyOnUpToDate);
        }

        void AdjustUpdateUiAfterCheck(string? downloadUrl, bool notify)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ee15fdd9-b026-4c64-afcb-87651bc42cc3" + System.Environment.NewLine);
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
            UpdateAvailableDownloadUrl = downloadUrl;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ef90aad3-96e3-43e1-8880-f825b9e1734f" + System.Environment.NewLine);
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
            // Surface the panel when we have an update, or when the user explicitly clicked
            // Check For Updates and wants confirmation of an "up to date" result.
            IsPanelVisible = downloadUrl != null || notify;
        }

        static void OpenLink(string url)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "5af08b6b-83cd-4fc5-9393-d29df4b5909c" + System.Environment.NewLine);
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
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ab897aa0-52e2-4559-aa91-50ec077f2d62" + System.Environment.NewLine);
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
                Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
            }
            catch
            {
            // Best-effort: silently ignore browser-launch failures (offline, no default
            // handler, etc.). The URL is also printed in the panel so the user can copy it.
            }
        }
    }
}