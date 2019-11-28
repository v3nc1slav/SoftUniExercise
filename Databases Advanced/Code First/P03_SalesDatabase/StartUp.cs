﻿using P03_SalesDatabase.Data;
using System;


namespace P03_SalesDatabase
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using (SalesDatabaseContext context = new SalesDatabaseContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }
    }
}
