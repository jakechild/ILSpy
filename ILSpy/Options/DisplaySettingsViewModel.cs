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
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using global::Avalonia.Media;
using ICSharpCode.ILSpy.Properties;

namespace ICSharpCode.ILSpy.Options
{
    /// <summary>Viewmodel for the Display panel. Exposes the snapshot's
    /// <see cref="DisplaySettings"/> through <see cref="Settings"/> for direct two-way
    /// binding in the panel view, plus the list of system font families for the picker.</summary>
    [ExportOptionPage(Order = 20)]
    public sealed partial class DisplaySettingsViewModel : ObservableObject, IOptionPage
    {
        public string Title => Resources.Display;

        [ObservableProperty]
        DisplaySettings settings = null !;
        // Session settings carry the active Theme. The theme ComboBox binds two-way to
        // SessionSettings.Theme; ThemeManager already applies the change live on that property.
        [ObservableProperty]
        SessionSettings sessionSettings = null !;
        public System.Collections.Generic.IReadOnlyCollection<string> AllThemes => Themes.ThemeManager.AllThemes;
        // Avalonia equivalent of WPF's Fonts.SystemFontFamilies. FontManager.Current populates
        // from the platform font enumerator (DirectWrite on Windows, FontConfig on Linux,
        // CoreText on macOS), so the list is realistic on every supported target.
        public IReadOnlyList<string> AvailableFonts { get; } = FontManager.Current.SystemFonts.Select(t => t.Name).OrderBy(n => n, System.StringComparer.OrdinalIgnoreCase).ToArray();
        /// <summary>Point sizes offered in the size dropdown.</summary>
        public IReadOnlyList<int> FontSizes { get; } = Enumerable.Range(6, 24 - 6 + 1).ToArray();

        /// <summary>
        /// The font size as the user sees and edits it: points, converted at 1 pt = 4/3 logical
        /// pixels. That ratio is exact wherever Avalonia's logical unit is 1/96 inch (Windows
        /// DIPs, X11 via Xft.dpi). On macOS the logical unit is a Cocoa point, so the number
        /// shown here is not the size native Mac font dialogs would report for the same
        /// rendering - accepted, because
        /// <see cref="DisplaySettings.SelectedFontSize"/> staying in logical pixels with one
        /// fixed conversion is what lets settings files round-trip with ILSpy 9.x on every host.
        /// Unparsable and non-finite input is ignored, numeric input is clamped to 6-72 pt.
        /// </summary>
        public string SelectedFontSizePoints
        {
            get => Settings == null ? string.Empty : Math.Round(Settings.SelectedFontSize * 3 / 4).ToString(CultureInfo.CurrentCulture);
            set
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ba12b250-0e91-4073-bfa3-d3027c5f2cbb" + System.Environment.NewLine);
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
                // Ignoring unparsable input is load-bearing beyond typing UX: ComboBox re-publishes
                // its still-empty Text when ItemsSource initializes before the Text binding has
                // delivered a value, and that write must not clobber the stored size. Do not
                // "improve" this into a fall-back-to-default.
                if (Settings == null || !double.TryParse(value, NumberStyles.Float, CultureInfo.CurrentCulture, out double points))
                {
                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "1b66ce65-7b19-4fbb-b24b-868013cf9e0b" + System.Environment.NewLine);
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
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "64cc4dd9-0383-4ad3-8710-ff88236a6837" + System.Environment.NewLine);
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
                // TryParse accepts the culture's NaN symbol, and NaN falls straight through
                // Math.Clamp; persisted, it would fail the editor's SelectedFontSize > 0 guard
                // forever, so the editor would never apply a font size again.
                if (!double.IsFinite(points))
                {
                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "51599365-5a99-4205-82a2-34fe7c1b3b0f" + System.Environment.NewLine);
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
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "164a0f7a-f0b4-41b5-866b-be539ffe767d" + System.Environment.NewLine);
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
                points = Math.Clamp(points, 6, 72);
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "5c9918cd-666c-4786-9cdb-790ef6f6aaba" + System.Environment.NewLine);
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
                // Suppress the PropertyChanged echo for this property: the binding would
                // immediately rewrite the size box with the rounded value mid-keystroke.
                updatingFontSizeFromText = true;
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f0a756a0-0465-4a8b-b6a2-d4eb520bbe94" + System.Environment.NewLine);
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
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "8d989385-f2f7-44f0-96df-ee94b548b3bb" + System.Environment.NewLine);
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
                    Settings.SelectedFontSize = points * 4 / 3;
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
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "33043836-0646-4be4-8f15-8fe43af6589f" + System.Environment.NewLine);
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
                    updatingFontSizeFromText = false;
                }
            }
        }

        bool updatingFontSizeFromText;
        /// <summary>Re-publishes the size text from the stored value. Wired to the size box's
        /// LostFocus: the echo suppression above means a typed "3" stored as the clamped 6 pt
        /// would otherwise keep showing 3 - committing on focus loss resyncs the box, the same
        /// way the NumericUpDown this ComboBox replaced committed its input.</summary>
        public void CommitFontSizeText() => OnPropertyChanged(nameof(SelectedFontSizePoints));
        /// <summary>
        /// Derived FontFamily for the preview TextBlock. Avalonia's runtime binding pipeline
        /// doesn't auto-coerce a <c>string</c> source to <see cref="FontFamily"/> (the implicit
        /// conversion fires at XAML parse time, not on binding evaluation), so the preview
        /// goes through this property — recomputed on every <see cref="DisplaySettings.SelectedFont"/>
        /// change via the PropertyChanged subscription in <see cref="Load"/>.
        /// </summary>
        public FontFamily CurrentFontFamily => Settings != null && !string.IsNullOrEmpty(Settings.SelectedFont) ? new FontFamily(Settings.SelectedFont) : FontFamily.Default;

        public void Load(SettingsService service)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "946c910e-4ac0-47d2-b59c-8a66e424ebbc" + System.Environment.NewLine);
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
            if (Settings != null)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e2d39728-25c9-4c01-b389-45c2ea6e1b6a" + System.Environment.NewLine);
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
                Settings.PropertyChanged -= OnSettingsPropertyChanged;
            }

            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "105da6ee-f49d-4941-bdb7-da0764b62eb1" + System.Environment.NewLine);
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
            Settings = service.DisplaySettings;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a892d28d-2689-4bb6-881a-deef9f621fb8" + System.Environment.NewLine);
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
            Settings.PropertyChanged += OnSettingsPropertyChanged;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "162d3842-4d52-45bb-883c-fff7d51b88ff" + System.Environment.NewLine);
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
            SessionSettings = service.SessionSettings;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ec11dec9-7095-4d33-a91c-161482ec5312" + System.Environment.NewLine);
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
            OnPropertyChanged(nameof(CurrentFontFamily));
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "106c4261-f442-4ba8-a752-87fdfc35896e" + System.Environment.NewLine);
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
            OnPropertyChanged(nameof(SelectedFontSizePoints));
        }

        void OnSettingsPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "18bb586b-25de-4d4f-a450-e82ee46cc290" + System.Environment.NewLine);
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
            if (e.PropertyName == nameof(DisplaySettings.SelectedFont))
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "40d8112d-0742-4d07-ba03-e8dba45d7bb7" + System.Environment.NewLine);
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
                OnPropertyChanged(nameof(CurrentFontFamily));
            }

            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "de073149-27d9-4bcf-93d6-1cc0e8315414" + System.Environment.NewLine);
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
            if (e.PropertyName == nameof(DisplaySettings.SelectedFontSize) && !updatingFontSizeFromText)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "55cd342b-4c37-4284-b5ac-4f1b5d060fcc" + System.Environment.NewLine);
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
                OnPropertyChanged(nameof(SelectedFontSizePoints));
            }
        }

        public void LoadDefaults()
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "28982c4f-7e30-46e8-b4b7-2412c93a83f7" + System.Environment.NewLine);
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
            // Reset by replaying LoadFromXml against an empty element — every attribute is
            // absent so each property falls back to its built-in default.
            Settings.LoadFromXml(new XElement("DisplaySettings"));
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b40eb79a-3aa6-435a-942f-bc203e67e574" + System.Environment.NewLine);
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
            SessionSettings.Theme = Themes.ThemeManager.Current.DefaultTheme;
        }
    }
}