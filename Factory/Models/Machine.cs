using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models;

public class Machine
{
  public int MachineId { get; set; }
  [Required(ErrorMessage = "A machine must have a name.")]
  public string Name { get; set; }
  [Required(ErrorMessage = "A machine must have a description.")]
  public string Description { get; set; }

  public List<EngineerMachine> JoinEntities { get; }
}
