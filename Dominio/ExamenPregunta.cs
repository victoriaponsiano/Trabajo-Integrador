﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Trabajo_Integrador.Dominio
{


    /// <summary>
    /// Clase de asociacion que representa la relacion entre pregunta y examen
    /// </summary>
    public class ExamenPregunta
    {
        [Key, Column(Order = 0)]
        public int ExamenId { get; set; }
        
        [Key, Column(Order = 1)]
        public string PreguntaId  { get; set; }
        
        public virtual String OpcionElegida { get; set; }

    }
}