using Filminurk.Core.Domain;
using Filminurk.Core.Dto;
using Filminurk.Core.ServiceInterface;
using Filminurk.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filminurk.ApplicationServices.Services
{
    public class ActorServices : IActorServices
    {
        FilminurkTarpe24Context _context;
        public ActorServices(FilminurkTarpe24Context context)
        {
            _context = context;
        }

        public async Task<Actor> Create(ActorDTO dto)
        {
            Actor actor = new Actor();
            actor.ActorID = Guid.NewGuid();
            actor.FirstName = dto.FirstName;
            actor.LastName = dto.LastName;
            actor.NickName = dto.NickName;
            actor.PortraitID = dto.PortraitID;
            actor.MoviesActedFor = dto.MoviesActedFor;

            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();

            return actor;
        }

        public async Task<Actor> Delete(Guid id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(x => x.ActorID == id);

            _context.Actors.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }

        public async Task<Actor> Update(ActorDTO dto)
        {
            Actor actor = new Actor();
            actor.ActorID = dto.ActorID;
            actor.FirstName = dto.FirstName;
            actor.LastName = dto.LastName;
            actor.NickName = dto.NickName;
            actor.PortraitID = dto.PortraitID;
            actor.MoviesActedFor = dto.MoviesActedFor;
            _context.Actors.Update(actor);
            await _context.SaveChangesAsync();

            return actor;
        }

        public Task<ActorDTO> UpdateActorAsync(ActorDTO actorDto)
        {
            throw new NotImplementedException();
        }

        Task<ActorDTO> IActorServices.CreateActorAsync(ActorDTO actorDto)
        {
            throw new NotImplementedException();
        }

        Task<bool> IActorServices.DeleteActorAsync(Guid actorId)
        {
            throw new NotImplementedException();
        }

        Task<ActorDTO> IActorServices.GetActorByIdAsync(Guid actorId)
        {
            throw new NotImplementedException();
        }
        }
    }
