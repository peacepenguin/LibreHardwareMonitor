﻿// This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0.
// If a copy of the MPL was not distributed with this file, You can obtain one at http://mozilla.org/MPL/2.0/.
// Copyright (C) LibreHardwareMonitor and Contributors.
// Partial Copyright (C) Michael Möller <mmoeller@openhardwaremonitor.org> and Contributors.
// All Rights Reserved.

using System;

namespace LibreHardwareMonitor.Software
{
    /// <summary>
    /// Contains basic information about the operating system.
    /// </summary>
    public static class OperatingSystem
    {
        /// <summary>
        /// Statically checks if the current system <see cref="Is64Bit"/> and <see cref="IsUnix"/>.
        /// </summary>
        static OperatingSystem()
        {
            // The operating system doesn't change during execution so let's query it just one time.
            PlatformID platform = Environment.OSVersion.Platform;
            IsUnix = platform == PlatformID.Unix || platform == PlatformID.MacOSX;

            if (Environment.Is64BitOperatingSystem)
                Is64Bit = true;
        }

        /// <summary>
        /// Gets information about whether the current system is 64 bit.
        /// </summary>
        public static bool Is64Bit { get; }

        /// <summary>
        /// Gets information about whether the current system is Unix based.
        /// </summary>
        public static bool IsUnix { get; }
    }
}
