using Project1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Repository
{
    public interface IWarningRepository
    {
        // Adds the Warning item to the table
        Warning Add(Warning warning);
        // Gets all Warnings
        IEnumerable<Warning> GetAll();
        // Gets a Warning obj from the table
        Warning GetWarning(int warningId);
        // edits Warning from the table
        void Update(Warning warning);
        // removes warning with warningId
        void Remove(int warningId);


    }
}
