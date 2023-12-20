namespace Lilith.Utility {
	public sealed class OperatingSystem {
		public enum ArchitectureType { Amd64, Arm64, Arm, X86, Ia64, Mips64, Mips, Ppc64, Sparc, Unknown }
		public enum OperatingSystemType { Windows, Linux, Mac, Solaris, Unknown }
		
		// @formatter:off
		public static string OsProp   { get; } = Environment.OSVersion.Platform.ToString().ToLower();
		public static string ArchProp { get; }  =
			Environment.GetEnvironmentVariable(variable: "PROCESSOR_ARCHITECTURE")?.ToLower() ?? "";

		public static OperatingSystemType OsType { get; } =
			OsProp.Contains(value: "win") ? OperatingSystemType.Windows :

			OsProp.Contains(value: "Mac") ||
			OsProp.Contains(value: "osx") ?
			OperatingSystemType.Mac :

			OsProp.Contains(value: "nix") ||
			OsProp.Contains(value: "nux") ||
			OsProp.Contains(value: "aix") ?
			OperatingSystemType.Linux :

			OsProp.Contains(value: "Solaris") ? OperatingSystemType.Solaris :
			OperatingSystemType.Unknown;

		public static ArchitectureType ArchType { get; } = 
            ArchProp.Contains(value: "amd64")   ? ArchitectureType.Amd64 :
            ArchProp.Contains(value: "aarch64") ? ArchitectureType.Arm64 :
            ArchProp.Contains(value: "armv7")   ? ArchitectureType.Arm :

            ArchProp.Contains(value: "x86_64") ||
            ArchProp.Contains(value: "x86-64") ?
            ArchitectureType.X86 :

            ArchProp.Contains(value: "ia64")    ? ArchitectureType.Ia64   :
            ArchProp.Contains(value: "mips64")  ? ArchitectureType.Mips64 :
            ArchProp.Contains(value: "mips")    ? ArchitectureType.Mips   :
            ArchProp.Contains(value: "ppc64")   ? ArchitectureType.Ppc64  :
            ArchProp.Contains(value: "sparcv9") ? ArchitectureType.Sparc  :

            ArchitectureType.Unknown;
		// @formatter:on

		public static bool ArchIs64Bit { get; } = ArchType switch
		{ ArchitectureType.Arm64  => true,
		  ArchitectureType.Amd64  => true,
		  ArchitectureType.Mips64 => true,
		  ArchitectureType.Ppc64  => true,
		  ArchitectureType.Sparc  => true,
		  ArchitectureType.Ia64   => true,
		  var _                   => false };

		public static string LibraryExtension { get; } = OsType switch
		{ OperatingSystemType.Windows => "dll",
		  OperatingSystemType.Mac     => "dylib",
		  var _                       => "SO" };
	}
}