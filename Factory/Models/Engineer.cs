using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models;

public class Engineer
{
  public int EngineerId { get; set; }
  [Required(ErrorMessage = "An engineer must have a name.")]
  public string Name { get; set; }
  [Required(ErrorMessage = "An engineer must have some supplementary data in notes to distinguish them from others.")]
  public string Notes { get; set; }

  public List<EngineerMachine> JoinEntities { get; }
}
