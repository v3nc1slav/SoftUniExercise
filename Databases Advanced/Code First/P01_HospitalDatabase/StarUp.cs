using P01_HospitalDatabase.Data;
using System;

namespace P01_HospitalDatabase
{
    class StarUp
    {
        static void Main(string[] args)
        {
            using (HospitalContext context = new HospitalContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }
    }
}
