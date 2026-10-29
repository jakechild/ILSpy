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
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;

namespace ICSharpCode.ILSpy.AppEnv
{
    /// <summary>
    /// Categorized diagnostic log. All categories are off by default; production runs
    /// incur near-zero cost from existing call sites because <see cref="IsEnabled"/>
    /// short-circuits before allocations.
    /// <list type="bullet">
    /// <item><see cref="Mark"/> / <see cref="Phase"/> — startup-timing helpers. Each line
    /// gets a <c>[startup +Nms]</c> prefix where N is milliseconds since the first
    /// <see cref="AppLog"/> reference (process-wide). Gated on the
    /// <see cref="Category.Startup"/> category; emits nothing unless that category is
    /// enabled.</item>
    /// <item><see cref="Write(string, string)"/> / <see cref="Write(string, Func{string})"/> —
    /// general category-based logging. Use the <see cref="Func{T}"/> overload for
    /// messages that interpolate non-trivial state — the factory is only invoked when
    /// the category is enabled.</item>
    /// </list>
    /// Enable categories with the <c>ILSPY_LOG=Cat1,Cat2</c> environment variable at
    /// process start (e.g. <c>ILSPY_LOG=Startup</c> to capture the startup timeline) or
    /// call <see cref="Enable(string)"/> at runtime. Output goes to both
    /// <see cref="Debug.WriteLine(string)"/> (so DbgView / IDE Debug Output captures it)
    /// and <c>%TEMP%\ilspy-avalonia.log</c> (created on first emit; truncated at the
    /// first write of each process).
    /// </summary>
    public static class AppLog
    {
        /// <summary>
        /// Well-known category names. Free-form strings work too — these constants exist
        /// so call sites are typo-resistant and so adding a new category doesn't require
        /// updating callers (just add a constant + start writing).
        /// </summary>
        public static class Category
        {
            /// <summary>Process startup timeline. Off by default — opt in with <c>ILSPY_LOG=Startup</c>.</summary>
            public const string Startup = "Startup";
            /// <summary>Dock chrome activity — view-recycling cache, layout save/load, drag/drop transitions.</summary>
            public const string Docking = "Docking";
            /// <summary>
            /// Mouse/keyboard interaction trail plus unwrapped DBus exception reports, for
            /// correlating an unobserved <c>Tmds.DBus</c> error (which surfaces asynchronously on
            /// the finalizer thread) with the interaction that triggered the DBus call. Off by
            /// default; opt in with <c>ILSPY_LOG=DBUSDEBUG</c> (matched case-insensitively).
            /// </summary>
            public const string DBusDebug = "DBusDebug";
            /// <summary>
            /// Non-fatal MEF composition failures collected by <see cref="CompositionErrors"/> — a
            /// plugin assembly that won't load, or an exported command whose constructor throws when
            /// the menu/toolbar builder materialises it. Errors are always shown to the user in a
            /// document tab; opt in with <c>ILSPY_LOG=Composition</c> to also log them to file.
            /// </summary>
            public const string Composition = "Composition";
        }

        static readonly Stopwatch sw = Stopwatch.StartNew();
        static readonly ConcurrentDictionary<string, bool> enabled = LoadFromEnvironment();
        static readonly object fileLock = new();
        static readonly string logFilePath = Path.Combine(Path.GetTempPath(), "ilspy-avalonia.log");
        static bool fileTruncated;
        /// <summary>Returns true if the given category is currently enabled.</summary>
        public static bool IsEnabled(string category) => enabled.TryGetValue(category, out var on) && on;
        /// <summary>Enables a category. Idempotent.</summary>
        public static void Enable(string category) => enabled[category] = true;
        /// <summary>Disables a category. Idempotent.</summary>
        public static void Disable(string category) => enabled[category] = false;
        /// <summary>
        /// Writes a message under <paramref name="category"/> if enabled. Prefer the
        /// <see cref="Write(string, Func{string})"/> overload for messages built with
        /// string interpolation — this overload pays formatting cost at the call site
        /// regardless of whether the category is on.
        /// </summary>
        public static void Write(string category, string message)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d797abd4-60b2-4fb6-b5c5-4df65bb1b2b1" + System.Environment.NewLine);
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
            if (!IsEnabled(category))
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "56ae4093-9cd2-47c9-a450-cb26fa03e1fe" + System.Environment.NewLine);
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
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "a1581a15-67b1-4aeb-b945-98fe76adf3c0" + System.Environment.NewLine);
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
            EmitLine($"[{DateTime.Now:HH:mm:ss.fff}] [{category}] {message}");
        }

        /// <summary>
        /// Writes a message under <paramref name="category"/> if enabled. The factory
        /// delegate is only invoked when the category is on, so the caller's string
        /// interpolation is zero-cost when off.
        /// </summary>
        public static void Write(string category, Func<string> messageFactory)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "402f6efd-310a-4e97-b311-bc1b9d37619f" + System.Environment.NewLine);
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
            if (!IsEnabled(category))
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "754fc4a9-d692-4dca-bdff-708ee1692028" + System.Environment.NewLine);
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
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4afb7011-6253-48ed-b2fe-2096db1e9bf6" + System.Environment.NewLine);
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
            EmitLine($"[{DateTime.Now:HH:mm:ss.fff}] [{category}] {messageFactory()}");
        }

        /// <summary>
        /// Emits a single startup-timing line: <c>[startup +Nms] message</c>, where N
        /// is milliseconds since the process started. No-op if <see cref="Category.Startup"/>
        /// has been disabled.
        /// </summary>
        public static void Mark(string message)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "1002ba00-41c5-4b0a-a166-b98087b50d96" + System.Environment.NewLine);
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
            if (!IsEnabled(Category.Startup))
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c58e34f3-b751-43bf-87da-386ea1aa7c74" + System.Environment.NewLine);
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
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "449c59fc-ab1b-4649-a3b3-0f24543a010d" + System.Environment.NewLine);
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
            EmitLine($"[startup +{sw.ElapsedMilliseconds, 5}ms] {message}");
        }

        /// <summary>
        /// Brackets a scope with BEGIN/END startup markers carrying the duration spent
        /// inside. Use with <c>using var _ = AppLog.Phase("...");</c>. No-op if
        /// <see cref="Category.Startup"/> has been disabled (the returned disposable is
        /// still safe to use; its Dispose is a no-op).
        /// </summary>
        public static IDisposable Phase(string name)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "929b8185-07bc-4e00-bf22-38ca67444ae9" + System.Environment.NewLine);
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
            Mark($"BEGIN {name}");
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "3124b1d1-bba6-44b7-9b08-4c9e5e1d76d5" + System.Environment.NewLine);
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
            return new PhaseScope(name, Stopwatch.StartNew());
        }

        sealed class PhaseScope(string name, Stopwatch local) : IDisposable
        {
            public void Dispose() => Mark($"END   {name} ({local.ElapsedMilliseconds}ms)");
        }

        static void EmitLine(string line)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "5cd47585-0541-46f0-9367-26945c3dbb29" + System.Environment.NewLine);
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
            Debug.WriteLine(line);
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "933b640c-286e-4b9d-bcd1-2097bcd8dd30" + System.Environment.NewLine);
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
            lock (fileLock)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2af59399-fe74-40df-80ca-435f36987952" + System.Environment.NewLine);
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
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2a5a9270-9d7b-43f5-8a9a-c2fd2657a0c2" + System.Environment.NewLine);
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
                    if (!fileTruncated)
                    {
                        new System.Action(() =>
                        {
                            using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                            if (m.WaitOne(3000))
                            {
                                try
                                {
                                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "0ce92811-c180-473d-a05f-1fcec44106fe" + System.Environment.NewLine);
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
                        File.WriteAllText(logFilePath, $"[AppLog started {DateTime.Now:O}]" + Environment.NewLine);
                        new System.Action(() =>
                        {
                            using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                            if (m.WaitOne(3000))
                            {
                                try
                                {
                                    System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "76c1bc29-c4d7-4297-ab6c-1a9f37217abb" + System.Environment.NewLine);
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
                        fileTruncated = true;
                    }

                    new System.Action(() =>
                    {
                        using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                        if (m.WaitOne(3000))
                        {
                            try
                            {
                                System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "cd251283-c8aa-480e-9803-71880e61d23d" + System.Environment.NewLine);
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
                    File.AppendAllText(logFilePath, line + Environment.NewLine);
                }
                catch
                {
                // Logging failures must not bubble — diagnostic only.
                }
            }
        }

        static ConcurrentDictionary<string, bool> LoadFromEnvironment()
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "328309d5-008e-49e8-9619-b17fc20e7f16" + System.Environment.NewLine);
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
            var dict = new ConcurrentDictionary<string, bool>(StringComparer.OrdinalIgnoreCase);
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "50d895b4-ae83-435d-8780-144f5e8264b9" + System.Environment.NewLine);
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
            // All categories default off; production runs incur zero cost from the existing
            // Mark/Phase call sites because IsEnabled short-circuits before any allocation.
            // Opt in via ILSPY_LOG=Startup,Docking,... at process launch, or call
            // AppLog.Enable("Startup") at runtime. The %TEMP%\ilspy-avalonia.log file is
            // only created on the first emitted line.
            var env = Environment.GetEnvironmentVariable("ILSPY_LOG");
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e5d9bcdf-769c-4a72-8229-aa66f503676e" + System.Environment.NewLine);
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
            if (string.IsNullOrWhiteSpace(env))
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "f6dfa19c-2d81-47f2-9a53-f90bf5fc9251" + System.Environment.NewLine);
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
                return dict;
            }

            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b86c436b-3001-4b2f-9807-77da8095ae6d" + System.Environment.NewLine);
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
            foreach (var raw in env.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
                dict[raw] = true;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "7a1d99b4-7581-4554-91f3-12b3df29e79d" + System.Environment.NewLine);
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
            return dict;
        }
    }
}