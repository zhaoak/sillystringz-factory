using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models;

public class Engineer
{
  public int EngineerId { get; set; }
  [Required(ErrorMessage = "An engineer must have a name.")]
  [StringLength(250, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 250 characters long.")]
  public string Name { get; set; }
  [Required(ErrorMessage = "An engineer must have some supplementary data in notes to distinguish them from others.")]
  [StringLength(2000, MinimumLength = 5, ErrorMessage = "Notes must be between 5 and 2000 characters long.")]
  public string Notes { get; set; }
  public string Status { get; set; } = "Idle";

  public List<EngineerMachine> JoinEntities { get; }
}
