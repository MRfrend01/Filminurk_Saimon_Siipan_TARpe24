using Filminurk.Core.Domain;
using Filminurk.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filminurk.Core.ServiceInterface
    {
    public interface IActorServices
    {
        Task<ActorDTO> CreateActorAsync(ActorDTO actorDto);
        Task<ActorDTO> GetActorByIdAsync(Guid actorId);
        Task<IEnumerable<ActorDTO>> GetAllActorsAsync();
        Task<ActorDTO> UpdateActorAsync(ActorDTO actorDto);
        Task<bool> DeleteActorAsync(Guid actorId);

    }
}