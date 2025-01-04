namespace Barbershop.Contracts.Models;

public class ServiceDto : EntityDto
{
    public string Name { get; set; }

    public ServiceSkillLevelDto JuniorSkill
    {
        get => GetValue<ServiceSkillLevelDto>(nameof(JuniorSkill));
        set => SetValue(value, nameof(JuniorSkill));
    }

    public ServiceSkillLevelDto MiddleSkill
    {
        get => GetValue<ServiceSkillLevelDto>(nameof(MiddleSkill));
        set => SetValue(value, nameof(MiddleSkill));
    }

    public ServiceSkillLevelDto SeniorSkill
    {
        get => GetValue<ServiceSkillLevelDto>(nameof(SeniorSkill));
        set => SetValue(value, nameof(SeniorSkill));
    }

    public override string ToString()
        => Name;
}
