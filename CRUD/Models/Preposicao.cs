﻿using SQLite;
using System;

namespace CRUD.Models
{
    public class Preposicao
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String name { get; set; }
        public String lesson { get; set; }
    }
}
