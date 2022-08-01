using System;
using System.Collections.Generic;

namespace Models
{
    public partial class Alimento
    {
        public int? Idalimentos { get; set; }
        public string NombreAlimentos { get; set; }
        public int Precio { get; set; }
        public List <Ingrediente> Ingrediente { get; set; }
    }
}
