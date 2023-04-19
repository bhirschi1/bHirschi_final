using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bHirschi_final.Models
{
    public class EFEntertainersRepository : IEntertainersRepository
    {
        private EntertainersDbContext _context { get; set; }
        public EFEntertainersRepository (EntertainersDbContext temp)
        {
            _context = temp;
        }
        public IQueryable<Entertainer> Entertainers => _context.Entertainers;
        //this is for editing a record
        public void UpdateEntertainer(Entertainer entertainer)
        {
            _context.Entry(entertainer).State = EntityState.Modified;
            _context.SaveChanges();
        }

        //add an entertainer
        public void Add(Entertainer entertainer)
        {
            _context.Entertainers.Add(entertainer);
            _context.SaveChanges();
        }

        //Delete an entertainer
        public void Delete(Entertainer entertainer)
        {
            _context.Entertainers.Remove(entertainer);
            _context.SaveChanges();
        }

    }
}
