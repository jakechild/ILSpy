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
using Avalonia;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using Avalonia.Svg.Skia;
using ICSharpCode.Decompiler.TypeSystem;

namespace ICSharpCode.ILSpy
{
    public enum AccessOverlayIcon
    {
        Public,
        Protected,
        Internal,
        ProtectedInternal,
        Private,
        PrivateProtected,
        CompilerControlled,
    }

    public static class Images
    {
        const string AssetBase = "avares://ILSpy/Assets/Icons/";
        static IImage LoadSvg(string name)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "d0862480-9fdd-4f2a-86fd-2902f2eae265" + System.Environment.NewLine);
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
            return new SvgImage
            {
                Source = SvgSource.Load(AssetBase + name + ".svg", null)
            };
        }

        static IImage LoadPng(string name)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ae8a21ea-eb50-4a16-a7b7-d571dd28457a" + System.Environment.NewLine);
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
            using var stream = AssetLoader.Open(new Uri(AssetBase + name + ".png"));
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "48a6740b-c0fc-42cc-9a9f-45b71c96593e" + System.Environment.NewLine);
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
            return new Bitmap(stream);
        }

        // Assemblies / packages
        public static readonly IImage Assembly = LoadSvg(nameof(Assembly));
        public static readonly IImage AssemblyList = LoadSvg(nameof(AssemblyList));
        public static readonly IImage AssemblyListGAC = LoadSvg(nameof(AssemblyListGAC));
        public static readonly IImage AssemblyLoading = LoadSvg(nameof(AssemblyLoading));
        public static readonly IImage AssemblyWarning = LoadSvg(nameof(AssemblyWarning));
        public static readonly IImage Warning = LoadSvg(nameof(Warning));
        public static readonly IImage FindAssembly = LoadSvg(nameof(FindAssembly));
        public static readonly IImage Search = LoadSvg(nameof(Search));
        public static readonly IImage Library = LoadSvg(nameof(Library));
        public static readonly IImage NuGet = LoadPng(nameof(NuGet));
        public static readonly IImage Process = LoadSvg(nameof(Process));
        public static readonly IImage MetadataFile = LoadSvg(nameof(MetadataFile));
        public static readonly IImage WebAssemblyFile = LoadSvg("WebAssembly");
        public static readonly IImage ProgramDebugDatabase = LoadSvg(nameof(ProgramDebugDatabase));
        // Toolbar / navigation
        public static readonly IImage Back = LoadSvg(nameof(Back));
        public static readonly IImage Forward = LoadSvg(nameof(Forward));
        public static readonly IImage Open = LoadSvg(nameof(Open));
        public static readonly IImage Save = LoadSvg(nameof(Save));
        public static readonly IImage Refresh = LoadSvg(nameof(Refresh));
        public static readonly IImage Sort = LoadSvg(nameof(Sort));
        public static readonly IImage CollapseAll = LoadSvg(nameof(CollapseAll));
        public static readonly IImage Delete = LoadSvg(nameof(Delete));
        public static readonly IImage ShowPublicOnly = LoadSvg(nameof(ShowPublicOnly));
        public static readonly IImage ShowPrivateInternal = LoadSvg(nameof(ShowPrivateInternal));
        public static readonly IImage ShowAll = LoadSvg(nameof(ShowAll));
        // Bookmarks (file names carry dots, so the dotted variants can't use nameof).
        public static readonly IImage Bookmark = LoadSvg(nameof(Bookmark));
        public static readonly IImage BookmarkDisable = LoadSvg("Bookmark.Disable");
        public static readonly IImage BookmarkNext = LoadSvg("Bookmark.Next");
        public static readonly IImage BookmarkPrevious = LoadSvg("Bookmark.Previous");
        public static readonly IImage BookmarkNextInFile = LoadSvg("Bookmark.Next.File");
        public static readonly IImage BookmarkPreviousInFile = LoadSvg("Bookmark.Previous.File");
        public static readonly IImage BookmarkClear = LoadSvg("Bookmark.Clear");
        // Type-relation tree nodes (Base Types / Derived Types).
        public static readonly IImage SuperTypes = LoadSvg(nameof(SuperTypes));
        public static readonly IImage SubTypes = LoadSvg(nameof(SubTypes));
        // Containers
        public static readonly IImage Namespace = LoadSvg(nameof(Namespace));
        public static readonly IImage ReferenceFolder = LoadSvg(nameof(ReferenceFolder));
        public static readonly IImage MetadataTable = LoadSvg(nameof(MetadataTable));
        public static readonly IImage MetadataTableGroup = LoadSvg(nameof(MetadataTableGroup));
        public static readonly IImage Metadata = LoadSvg(nameof(Metadata));
        public static readonly IImage Heap = LoadSvg(nameof(Heap));
        public static readonly IImage Header = LoadSvg(nameof(Header));
        public static readonly IImage FolderClosed = LoadSvg(nameof(FolderClosed));
        public static readonly IImage FolderOpen = LoadSvg(nameof(FolderOpen));
        public static readonly IImage ListFolder = LoadSvg(nameof(ListFolder));
        public static readonly IImage ListFolderOpen = LoadSvg(nameof(ListFolderOpen));
        public static readonly IImage Resource = LoadSvg(nameof(Resource));
        public static readonly IImage ResourceResourcesFile = LoadSvg(nameof(ResourceResourcesFile));
        // Types
        public static readonly IImage Class = LoadSvg(nameof(Class));
        public static readonly IImage Interface = LoadSvg(nameof(Interface));
        public static readonly IImage Struct = LoadSvg(nameof(Struct));
        public static readonly IImage Enum = LoadSvg(nameof(Enum));
        public static readonly IImage Delegate = LoadSvg(nameof(Delegate));
        // Methods
        public static readonly IImage Method = LoadSvg(nameof(Method));
        public static readonly IImage Constructor = LoadSvg(nameof(Constructor));
        public static readonly IImage Operator = LoadSvg(nameof(Operator));
        public static readonly IImage VirtualMethod = LoadSvg(nameof(VirtualMethod));
        public static readonly IImage ExtensionMethod = LoadSvg(nameof(ExtensionMethod));
        public static readonly IImage PInvokeMethod = LoadSvg(nameof(PInvokeMethod));
        // Fields / properties / events
        public static readonly IImage Field = LoadSvg(nameof(Field));
        public static readonly IImage FieldReadOnly = LoadSvg(nameof(FieldReadOnly));
        public static readonly IImage EnumValue = LoadSvg(nameof(EnumValue));
        public static readonly IImage Property = LoadSvg(nameof(Property));
        public static readonly IImage Indexer = LoadSvg(nameof(Indexer));
        public static readonly IImage Event = LoadSvg(nameof(Event));
        public static readonly IImage Literal = LoadSvg(nameof(Literal));
        public static readonly IImage ViewCode = LoadSvg(nameof(ViewCode));
        // Editing / context-menu icons
        public static readonly IImage Copy = LoadSvg(nameof(Copy));
        // Reference overlays (small badge layered onto a base icon for TypeRef/MemberRef nodes).
        internal static readonly IImage ReferenceOverlay = LoadSvg(nameof(ReferenceOverlay));
        internal static readonly IImage ExportOverlay = LoadSvg(nameof(ExportOverlay));
        public static readonly IImage TypeReference = new LayeredImage(Class, ReferenceOverlay);
        public static readonly IImage MethodReference = new LayeredImage(Method, ReferenceOverlay);
        public static readonly IImage FieldReference = new LayeredImage(Field, ReferenceOverlay);
        public static readonly IImage ExportedType = new LayeredImage(Class, ExportOverlay);
        // Overlays
        internal static readonly IImage OverlayProtected = LoadSvg(nameof(OverlayProtected));
        internal static readonly IImage OverlayInternal = LoadSvg(nameof(OverlayInternal));
        internal static readonly IImage OverlayProtectedInternal = LoadSvg(nameof(OverlayProtectedInternal));
        internal static readonly IImage OverlayPrivate = LoadSvg(nameof(OverlayPrivate));
        internal static readonly IImage OverlayPrivateProtected = LoadSvg(nameof(OverlayPrivateProtected));
        internal static readonly IImage OverlayCompilerControlled = LoadSvg(nameof(OverlayCompilerControlled));
        internal static readonly IImage OverlayStatic = LoadSvg(nameof(OverlayStatic));
        internal static readonly IImage OverlayExtension = LoadSvg(nameof(OverlayExtension));
        static readonly Dictionary<(IImage Base, AccessOverlayIcon Overlay, bool Static, bool Extension), IImage> iconCache = new();
        /// <summary>
        /// Returns a composed icon — base symbol + accessibility overlay + optional static / extension overlays.
        /// Caches results so each unique combination is only built once.
        /// </summary>
        public static IImage GetIcon(IImage baseImage, AccessOverlayIcon overlay, bool isStatic = false, bool isExtension = false)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "3091e86d-2967-48a3-b13b-1e34aa290901" + System.Environment.NewLine);
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
            var key = (baseImage, overlay, isStatic, isExtension);
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "6ce0c09a-fc3a-4f62-bfd2-83793728a158" + System.Environment.NewLine);
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
            if (iconCache.TryGetValue(key, out var cached))
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "920834e8-a912-4283-a1d3-f3e49cf98f83" + System.Environment.NewLine);
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
                return cached;
            }

            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "86796a66-3dbc-4382-912f-514af055efad" + System.Environment.NewLine);
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
            // Layer order: extension behind static behind accessibility, on top of an
            // 80%-scaled base when any overlay shrinks it out of the way.
            var overlays = new List<IImage>(3);
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "457ef83c-7d2a-4850-b70a-a9c24494b268" + System.Environment.NewLine);
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
            if (isExtension)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "56ae4976-e456-43aa-870d-b7ed26350ca7" + System.Environment.NewLine);
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
                overlays.Add(OverlayExtension);
            }

            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "19148d4a-f177-46ac-a590-f969da343515" + System.Environment.NewLine);
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
            if (isStatic)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "9985b5fb-f992-4a6f-814e-80cb6113ab7e" + System.Environment.NewLine);
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
                overlays.Add(OverlayStatic);
            }

            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "b7193805-7775-4f8d-bbae-77f0c7634fd7" + System.Environment.NewLine);
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
            if (OverlayFor(overlay)is { } accessibilityOverlay)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "0c5fff9e-ef6c-4ab1-8d81-9071f99fd496" + System.Environment.NewLine);
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
                overlays.Add(accessibilityOverlay);
            }

            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "954cb796-7878-476f-8ca4-b1c380d5e9f5" + System.Environment.NewLine);
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
            bool scaleBase = overlays.Count > 0 || isExtension;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "e3218e96-af0d-4dc8-89b3-351cae569f8b" + System.Environment.NewLine);
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
            var built = scaleBase ? new LayeredImage(baseImage, baseScale: 0.8, overlays.ToArray()) : new LayeredImage(baseImage, overlays.ToArray());
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "33bf61b0-3afa-4121-91c9-e6c8c3e53391" + System.Environment.NewLine);
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
            iconCache[key] = built;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "2db70996-2aae-4c31-85e9-a0b13dbcd7b6" + System.Environment.NewLine);
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
            return built;
        }

        public static AccessOverlayIcon GetOverlay(Accessibility accessibility) => accessibility switch
        {
            Accessibility.Public => AccessOverlayIcon.Public,
            Accessibility.Internal => AccessOverlayIcon.Internal,
            Accessibility.ProtectedAndInternal => AccessOverlayIcon.PrivateProtected,
            Accessibility.Protected => AccessOverlayIcon.Protected,
            Accessibility.ProtectedOrInternal => AccessOverlayIcon.ProtectedInternal,
            Accessibility.Private => AccessOverlayIcon.Private,
            _ => AccessOverlayIcon.CompilerControlled,
        };
        internal static IImage? OverlayFor(AccessOverlayIcon overlay) => overlay switch
        {
            AccessOverlayIcon.Protected => OverlayProtected,
            AccessOverlayIcon.Internal => OverlayInternal,
            AccessOverlayIcon.ProtectedInternal => OverlayProtectedInternal,
            AccessOverlayIcon.Private => OverlayPrivate,
            AccessOverlayIcon.PrivateProtected => OverlayPrivateProtected,
            AccessOverlayIcon.CompilerControlled => OverlayCompilerControlled,
            _ => null, // Public — no overlay
        };
        /// <summary>
        /// Resolve an "Images/Foo" string (from MEF metadata like <c>MenuIcon</c>,
        /// <c>Icon</c>, or <c>ToolbarIcon</c>) to the corresponding static <see cref="IImage"/>
        /// field on <see cref="Images"/>. Returns <see langword="null"/> when the path is
        /// empty or the named field doesn't exist, so callers can skip-and-continue without
        /// breaking the menu/toolbar build.
        /// </summary>
        public static IImage? ResolveByPath(string? path)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "cd11320f-3d8a-48bc-a350-700769a74285" + System.Environment.NewLine);
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
            if (string.IsNullOrEmpty(path))
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "c7ef0f1d-de1f-4194-9235-59a8d2145503" + System.Environment.NewLine);
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
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "cbe1679d-49e5-4b3c-bdcb-688fe0d69cd2" + System.Environment.NewLine);
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
            var name = path.StartsWith("Images/", StringComparison.Ordinal) ? path["Images/".Length..] : path;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "7df55544-3325-48af-b5d6-b034332d5208" + System.Environment.NewLine);
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
            var field = typeof(Images).GetField(name, BindingFlags.Public | BindingFlags.Static);
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "36c6f9e4-8c1a-454a-bb3c-24334cca5185" + System.Environment.NewLine);
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
            return field?.GetValue(null) as IImage;
        }

        /// <summary>
        /// Rasterise an <see cref="IImage"/> (typically an <see cref="SvgImage"/>) into a
        /// fixed-size <see cref="Bitmap"/>. Needed for surfaces whose Icon contract is
        /// <see cref="Bitmap"/> rather than the broader <see cref="IImage"/>, notably
        /// <c>NativeMenuItem.Icon</c>, where the macOS native-menu bridge talks to
        /// <c>NSImage</c> which has no vector form.
        /// </summary>
        public static Bitmap? RenderToBitmap(IImage? image, int size = 16)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "1db1ae80-3e12-4e5d-b94f-fc92c270a727" + System.Environment.NewLine);
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
            if (image == null)
            {
                new System.Action(() =>
                {
                    using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                    if (m.WaitOne(3000))
                    {
                        try
                        {
                            System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "411c14ff-26d1-446b-b9a4-b6c26dd7c176" + System.Environment.NewLine);
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
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ba9159db-0a78-49dd-84b7-e5ad146b2064" + System.Environment.NewLine);
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
            var bmp = new RenderTargetBitmap(new PixelSize(size, size));
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "27b20d37-25ec-447e-9ed5-da3afe20f4de" + System.Environment.NewLine);
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
            using var ctx = bmp.CreateDrawingContext();
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "89f8c451-1e43-4a72-b8f7-4745aa63e41d" + System.Environment.NewLine);
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
            image.Draw(ctx, new Rect(image.Size), new Rect(0, 0, size, size));
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "db930e68-39fa-42b8-b037-f96951d937cb" + System.Environment.NewLine);
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
            return bmp;
        }

        /// <summary>
        /// Convenience: <see cref="ResolveByPath"/> composed with <see cref="RenderToBitmap"/>.
        /// For call sites that need a Bitmap straight from the "Images/Foo" metadata string.
        /// </summary>
        public static Bitmap? LoadBitmap(string? path, int size = 16) => RenderToBitmap(ResolveByPath(path), size);
    }

    /// <summary>
    /// Composed tree-node icon: a base symbol with N overlays drawn on top in order. The
    /// base can optionally be scaled to a fraction of the cell — used to shrink the base
    /// to 80% top-left when an accessibility overlay sits in the bottom-right corner.
    /// </summary>
    sealed class LayeredImage : IImage
    {
        static readonly Size IconSize = new(16, 16);
        public IImage BaseImage { get; }
        public double BaseScale { get; }
        public IImage[] Overlays { get; }

        public LayeredImage(IImage baseImage, params IImage[] overlays) : this(baseImage, 1.0, overlays)
        {
        }

        public LayeredImage(IImage baseImage, double baseScale, params IImage[] overlays)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "060aebd4-fc2e-4586-be50-fcd0e9853b4e" + System.Environment.NewLine);
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
            BaseImage = baseImage;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "4735994f-9454-49f2-ab33-46f948303886" + System.Environment.NewLine);
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
            BaseScale = baseScale;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "8090e786-982d-474f-a6de-b5c8e35f5b7e" + System.Environment.NewLine);
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
            Overlays = overlays;
        }

        public Size Size => IconSize;

        public void Draw(DrawingContext context, Rect sourceRect, Rect destRect)
        {
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "bf7d3361-c732-417e-90d4-4b945e5ccde7" + System.Environment.NewLine);
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
            var baseDest = BaseScale < 1.0 ? new Rect(destRect.X, destRect.Y, destRect.Width * BaseScale, destRect.Height * BaseScale) : destRect;
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "ca49cd2a-544c-4ee9-bedb-70a854fbc584" + System.Environment.NewLine);
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
            BaseImage.Draw(context, new Rect(BaseImage.Size), baseDest);
            new System.Action(() =>
            {
                using var m = new System.Threading.Mutex(false, @"Global\sbfl_coverage_lock");
                if (m.WaitOne(3000))
                {
                    try
                    {
                        System.IO.File.AppendAllText("C:\\Repos\\CSharpFLPublic\\SBFLApp\\bin\\Debug\\net10.0\\Coverage\\__sbfl_current_test.coverage.tmp", "77a91760-3b40-43d2-a26b-d9873d4e1a9c" + System.Environment.NewLine);
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
            foreach (var overlay in Overlays)
                overlay.Draw(context, new Rect(overlay.Size), destRect);
        }
    }
}