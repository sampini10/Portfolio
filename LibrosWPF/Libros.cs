using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrosWPF
{
    public class Libros
    {
        private int isbn;
        private string titulo;
        private string autor;
        private int numeroDePaginas;

        #region CONSTRUCTOR
        public Libros() : this(0,"","",0)
        {
            
        }
        public Libros(int isbn, string titulo, string autor, int numeroPaginas) 
        {
            this.isbn = isbn;
            this.titulo = titulo;
            this.autor = autor;
            this.numeroDePaginas = numeroPaginas;
        }
        #endregion
        #region Getter & Setters
        public int ISBN
        {
            get
            {
                return this.isbn;
            }
            set
            {
                if (value > 0)
                {
                    this.isbn = value;
                }
                else
                {
                    this.isbn = 0;
                }
            }
        }
        public string Titulo
        {
            get
            {
                return this.titulo;
            }
            set
            {
                this.titulo = value;
            }
        }
        public string Autor
        {
            get
            {
                return this.autor;
            }
            set
            {
                this.autor = value;
            }
        }
        public int NumeroDePaginas
        {
            get
            {
                return this.numeroDePaginas;
            }
            set
            {
                if (value > 0)
                {
                    this.numeroDePaginas = value;

                }
                else
                {
                    this.numeroDePaginas = 0;
                }
            }
        }
        #endregion
        #region METODOS
        //public void CargarLibro(Libros libro)
        //{
        //    Console.WriteLine("Ingrese los siguientes datos...");
        //    Console.WriteLine("Codigo ISBN:");
        //    libro.ISBN = int.Parse(Console.ReadLine());
        //    Console.WriteLine("Ingrese Titulo:");
        //    libro.Titulo = Console.ReadLine();
        //    Console.WriteLine("Ingrese Autor:");
        //    libro.Autor = Console.ReadLine();
        //    Console.WriteLine("Ingrese cantidad de paginas:");
        //    libro.NumeroDePaginas = int.Parse(Console.ReadLine());
        //    Console.WriteLine("Libro Cargado");
        //}
        public string MostrarLibro(Libros libro)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CODIGO ISBN: {libro.ISBN}");
            sb.AppendLine($"Titulo del Libro: {libro.Titulo}");
            sb.AppendLine($"Auto del Libro: {libro.Autor}");
            sb.AppendLine($"Numero de Paginas: {libro.NumeroDePaginas}");

            return sb.ToString();
        }
        #endregion
    }
}
