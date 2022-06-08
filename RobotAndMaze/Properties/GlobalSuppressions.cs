using System.Diagnostics.CodeAnalysis;
using System.Resources;

[assembly: SuppressMessage("Performance", "CA1814:Prefer jagged arrays over multidimensional", Justification = "The multidimensional array does not waste space", Scope = "member", Target = "~M:RobotAndMaze.Support.MatrixSeed.Create6X6Cells~RobotAndMaze.Domain.Models.Cell[,]")]
[assembly: SuppressMessage("Performance", "CA1814:Prefer jagged arrays over multidimensional", Justification = "The multidimensional array does not waste space", Scope = "member", Target = "~F:RobotAndMaze.Domain.Models.Matrix.cells")]
[assembly: SuppressMessage("Performance", "CA1814:Prefer jagged arrays over multidimensional", Justification = "The multidimensional array does not waste space", Scope = "member", Target = "~M:RobotAndMaze.Domain.Models.Matrix.#ctor(RobotAndMaze.Domain.Models.Cell[,],RobotAndMaze.Domain.Models.Coordinates)")]

[assembly: CLSCompliant(false)]
[assembly: NeutralResourcesLanguage("en")]