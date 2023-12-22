using VirtualPetCareApi.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace VirtualPetCareApi.Application.Repositories;
public interface IRepository<T> where T : BaseEntity
{
    DbSet<T> Table { get; }
}
