namespace Barbershop.Domain.Models;

public class Service : Entity
{
    public string Name { get; set; }

    public virtual ICollection<ServiceSkillLevel> ServiceSkillLevels { get; set; }

    public Service()
    {
        ServiceSkillLevels = new HashSet<ServiceSkillLevel>();
    }
}