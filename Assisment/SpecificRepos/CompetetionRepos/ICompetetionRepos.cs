using Assisment.DTOs;
using Assisment.GenericRepo;
using Assisment.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assisment.SpecificRepos.CompetetionRepos
{
    public interface ICompetetionRepos : IGeneric<Competition>
    {
        public Task<Competition> GetCompetetionById(int id);
        public Task<IEnumerable<competetionDTO>> GetTeamsCount();
    }
}
