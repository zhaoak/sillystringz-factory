using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models;

public class Engineer
{
  public int EngineerId { get; set; }
  [Required(ErrorMessage = "An engineer must have a name.")]
  public string Name { get; set; }
  [Required(ErrorMessage = "An engineer must some supplementary data to distinguish them from others.")]
  public string Notes { get; set; }

  public List<EngineerMachine> JoinEntities { get; }
}
