using Barbershop.Contracts.Models;

namespace Barbershop.Contracts.Commands;

public class UpsertServiceCommand : IdentifiedCommand
{
    public string Name { get; set; }

    public ServiceSkillLevelDto? JuniorSkill { get; set; }
    public ServiceSkillLevelDto? MiddleSkill { get; set; }
    public ServiceSkillLevelDto? SeniorSkill { get; set; }
}
