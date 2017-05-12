using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_de_Inventario_lista_circular_v2
{
    class Base
    {
        public Base siguiente;

        private string _nombre;
        public string nombre
        {
            get { return _nombre; }
        }

        private int _minutos;
        public int minutos
        {
            get { return _minutos; }
        }

        public Base(string nombre, int minutos)
        {
            _nombre = nombre;
            _minutos = minutos;
        }
        
        public override string ToString()
        {
            string cadena = "";
            cadena += "BASE:            [ " + _nombre + " ]" + "\r\n" + "MINUTOS:     [ " + _minutos + " ]" + "\r\n" + "\r\n";
            return cadena;
        }

    }
}
