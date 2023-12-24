namespace Lilith.Utility;

public sealed class OperatingSystem {
    public enum ArchitectureType {
        Amd64,
        Arm64,
        Arm,
        X86,
        Ia64,
        Mips64,
        Mips,
        Ppc64,
        Sparc,
        Unknown
    }

    public enum OperatingSystemType {
        Windows,
        Linux,
        Mac,
        Solaris,
        Unknown
    }

    public static bool ArchIs64Bit { get; } = ArchType switch {
        ArchitectureType.Arm64  => true,
        ArchitectureType.Amd64  => true,
        ArchitectureType.Mips64 => true,
        ArchitectureType.Ppc64  => true,
        ArchitectureType.Sparc  => true,
        ArchitectureType.Ia64   => true,
        var _                   => false
    };

    public static string LibraryExtension { get; } = OsType switch {
        OperatingSystemType.Windows => "dll",
        OperatingSystemType.Mac     => "dylib",
        var _                       => "SO"
    };
		
		// @formatter:off
		public static string OsProp   { get; } = Environment.OSVersion.Platform.ToString().ToLower();
		public static string ArchProp { get; }  =
			Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE")?.ToLower() ?? "";

		public static OperatingSystemType OsType { get; } =
			OsProp.Contains("win") ? OperatingSystemType.Windows :

			OsProp.Contains("Mac") ||
			OsProp.Contains("osx") ?
			OperatingSystemType.Mac :

			OsProp.Contains("nix") ||
			OsProp.Contains("nux") ||
			OsProp.Contains("aix") ?
			OperatingSystemType.Linux :

			OsProp.Contains("Solaris") ? OperatingSystemType.Solaris :
			OperatingSystemType.Unknown;

		public static ArchitectureType ArchType { get; } = 
            ArchProp.Contains("amd64")   ? ArchitectureType.Amd64 :
            ArchProp.Contains("aarch64") ? ArchitectureType.Arm64 :
            ArchProp.Contains("armv7")   ? ArchitectureType.Arm :

            ArchProp.Contains("x86_64") ||
            ArchProp.Contains("x86-64") ?
            ArchitectureType.X86 :

            ArchProp.Contains("ia64")    ? ArchitectureType.Ia64   :
            ArchProp.Contains("mips64")  ? ArchitectureType.Mips64 :
            ArchProp.Contains("mips")    ? ArchitectureType.Mips   :
            ArchProp.Contains("ppc64")   ? ArchitectureType.Ppc64  :
            ArchProp.Contains("sparcv9") ? ArchitectureType.Sparc  :

            ArchitectureType.Unknown;
    // @formatter:on
}