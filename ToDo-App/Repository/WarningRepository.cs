using Microsoft.EntityFrameworkCore;
using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Repository
{
    public class WarningRepository : IWarningRepository
    {
        private MyDbContext context;

        public WarningRepository(MyDbContext context)
        {
            this.context = context;

        }

        public Warning Add(Warning warning)
        {
            this.context.Warnings.Add(warning);
            this.context.SaveChanges();
            return warning;

        }

        public IEnumerable<Warning> GetAll()
        {
            return this.context.Warnings.ToList();
        }

        public Warning GetWarning(int warningId)
        {
            return this.context.Warnings.FirstOrDefault(w=>w.WarningId == warningId);
        }

        public void Remove(int warningId)
        {
            this.context.Warnings.Remove(this.context.Warnings.FirstOrDefault(t => t.WarningId == warningId));
            this.context.SaveChanges();
        }

        public void Update(Warning warning)
        {
            var existingWarning = this.context.Warnings.FirstOrDefault(w => w.WarningId == warning.WarningId);
            existingWarning.Days = warning.Days;
            existingWarning.Hours = warning.Hours;
            existingWarning.WarningId = warning.WarningId;
            this.context.SaveChanges();
        }
    }
}
