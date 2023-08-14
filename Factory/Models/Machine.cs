using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Factory.Models;

public class Machine
{
  public int MachineId { get; set; }
  [Required(ErrorMessage = "A machine must have a name.")]
  [StringLength(250, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 250 characters long.")]
  public string Name { get; set; }
  [Required(ErrorMessage = "A machine must have a description.")]
  [StringLength(2000, MinimumLength = 5, ErrorMessage = "Description must be between 1 and 2000 characters long.")]
  public string Description { get; set; }
  public string Status { get; set; } = "Operational";

  public List<EngineerMachine> JoinEntities { get; }
}
