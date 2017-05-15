using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_de_Inventario_lista_circular_v2
{
    class Ruta
    {
        private Base inicio;

        public Ruta()
        {
            inicio = null;
        }

        public void agregarBase(Base baseNew)
        {
            bool sePuedeAgregar = true;
            
            if (inicio == null)//En caso de ser la primera base en agregar.
            {
                inicio = baseNew;
                //Al final une la base nueva con la base inicio.
                baseNew.siguiente = inicio;
            }
            else
            {
                Base temp = inicio;
                while (temp.siguiente != inicio && sePuedeAgregar != false)
                {
                    if (temp.nombre == baseNew.nombre)
                    {
                        sePuedeAgregar = false;
                    }
                    temp = temp.siguiente;
                }
                //Condición que permite agregar una base solo si su nombre es diferente.
                if (sePuedeAgregar == true && temp.nombre != baseNew.nombre)
                {
                    temp.siguiente = baseNew;
                    //Al final une la base nueva con la base inicio.
                    baseNew.siguiente = inicio;
                }
            }
        }

        public void agregarBaseInicio(Base baseNewInicio)
        {
            Base temp = inicio;
            bool sePuedeAgregar = true;

            if (inicio == null)//En caso de ser la primera base en agregar.
            {
                inicio = baseNewInicio;
                //Al final une la base nueva con la base inicio.
                baseNewInicio.siguiente = inicio;
            }
            else
            {
                //El ciclo while se hace para poder manejar la base final, que es guardada en temp.
                while (temp.siguiente != inicio && sePuedeAgregar != false)
                {
                    if (temp.nombre == baseNewInicio.nombre)
                    {
                        sePuedeAgregar = false;
                    }
                    temp = temp.siguiente;
                }
                //Condición que permite agregar una base solo si su nombre es diferente.
                if (sePuedeAgregar == true && temp.nombre != baseNewInicio.nombre)
                {
                    //Unión de la base nueva inicio.
                    baseNewInicio.siguiente = inicio;
                    inicio = baseNewInicio;
                    temp.siguiente = inicio;
                }
            }
        }

        public void insertarDespuesDe(string nombreB, Base baseNewInsertar)
        {
            //Variable temp regresa exactamente la base con el nombre que ingresamos.
            Base temp = buscarPorNombre(nombreB);

            baseNewInsertar.siguiente = temp.siguiente;
            temp.siguiente = baseNewInsertar;
        }

        public Base buscarPorNombre(string nombreB)
        {
            Base temp = inicio;

            if (temp != null)
            {
                while (temp.siguiente != inicio && temp.nombre != nombreB)
                {
                    temp = temp.siguiente;
                }
                //Variable temp regresa exactamente la base con el nombre que ingresamos.
                return temp;
            }
            else
            {
                return inicio;
            }
        }

        public void eliminarPorNombre(string nombreB)
        {
            Base temp = inicio;

            if (temp.nombre == nombreB)//Se quiere eliminar el inicio logico.
            {
                if (temp.siguiente == inicio)//Esto indica que solo hay una base.
                {
                    temp = null;
                    inicio = temp;
                }
                else//Si se desea eliminar el inicio logico pero hay mas bases.
                {
                    while (temp.siguiente != inicio)
                    {
                        temp = temp.siguiente;
                    }
                    temp.siguiente = inicio.siguiente;
                    inicio = inicio.siguiente;
                }
            }
            else//Si se quiere eliminar una base que no es el inicio logico.
            {
                while (temp.siguiente != inicio && temp.siguiente.nombre != nombreB)
                {
                    temp = temp.siguiente;
                }
                if (temp.siguiente.nombre == nombreB)//Comprueva que que sea la base a eliminar.
                {
                    temp.siguiente = temp.siguiente.siguiente;
                }
            }
        }

        public string recorrido(string nombreB, DateTime inicio, DateTime fin)
        {
            Base temp = buscarPorNombre(nombreB);
            string cadena = "";
            int minutosZero = 0;

            if (temp != null)
            {
                while (inicio < fin)
                {
                    inicio = inicio.AddMinutes(temp.siguiente.minutos);
                    cadena += temp.nombre + " -----> " + temp.siguiente.nombre + " Tiempo hecho: " + temp.siguiente.minutos + "\r\n" + "\r\n";
                    temp = temp.siguiente;
                    minutosZero += temp.minutos;
                }
                cadena += "Terminas en la base " + temp.nombre + "." + "\r\n" + "Hiciste un total de " + minutosZero + " minutos.";
                return cadena;
            }
            else
            {
                return "No existe esa base";
            }
        }

        public string reporteDeBases()
        {
            string cadena = "";
            Base temp = inicio;

            if (temp != null)
            {
                while (temp.siguiente != inicio)
                {
                    cadena += temp.ToString();
                    temp = temp.siguiente;
                }
                //Vulve a concatenar porque falta la ultima base, ya que el ciclo se para antes.
                //Al final temp termina siendo la ultima base.
                cadena += temp.ToString();
                return cadena;
            }
            else
            {
                return "";
            }
        }

    }
}
