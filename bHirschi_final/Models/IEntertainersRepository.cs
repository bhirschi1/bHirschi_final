using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bHirschi_final.Models
{
    public interface IEntertainersRepository
    {
        IQueryable<Entertainer> Entertainers { get; }
        //the following are for editing, adding, and deleting a record, respectively
        void UpdateEntertainer(Entertainer entertainer);
        void Add(Entertainer entertainer);
        void Delete(Entertainer entertainer);

    }
}
