using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp
{
        public class Cliente
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public string AccNum { get; set; }
            public string Tel { get; set; }

        }

        public class Payment
        {
            public string AccNum { get; set; }
            public DateTime LastDate { get; set; }
            public string Price { get; set; }
            public string Owed { get; set; }
            public string Active { get; set; }
            public string Type { get; set; }
            public string Recurrent { get; set; }

            public DateTime StartDate { get; set; } = DateTime.Now;
            public string Recurrance { get; set; } = "1";
        }

        public class Ingress
        {
            public string AccNum { get; set; }
            public string Name { get; set; }
            public DateTime Date { get; set; }
            public bool IsDaily { get; set; }
        }
    }


