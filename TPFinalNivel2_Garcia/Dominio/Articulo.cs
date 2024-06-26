﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        public int Id { get; set; }

        public string Codigo {  get; set; }

        public string Nombre { get; set; }

        public string Descripcion {  get; set; }

        public string Precio {  get; set; }  

        public string ImagenUrl {  get; set; }  
         
        /*---Nueva propiedad categoria que va a ser la descripcion--.*/
        public Categoria Categoria { get; set; }

        public Marca Marca { get; set; }    
        


    }
}
